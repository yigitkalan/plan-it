import axios from "axios";
import { BACKEND_URL } from "../utils/config";
import { LoginCredentials } from "../models/LoginCredentials";
import { RegisterCredentials } from "../models/RegisterCredentials";
import { jwtDecode } from "jwt-decode";
import { Claims } from "../models/Claims";

const NAME_IDENTIFIER = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
const EMAIL_ADDRESS = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
const ROLE = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

const authControllerUrl = `${BACKEND_URL}api/authentication`;

export async function LoginUser(cred: LoginCredentials) {
    const { email, password } = cred;
    const response = await axios.post(`${authControllerUrl}/login`, { email, password });
    if (response.status == 200) {
        const jwtAccessToken = response.data.accessToken;
        const decoded: Claims = jwtDecode(jwtAccessToken);

        localStorage.setItem("accessToken", jwtAccessToken);
        localStorage.setItem("userId", decoded[NAME_IDENTIFIER]);
    }
    else {
        throw new Error('Failed to login');
    }
}

export async function Register(cred: RegisterCredentials) {
    const { email, password, username } = cred;
    const response = await axios.post(`${authControllerUrl}/register`, { email, password, username });
}

export async function Logout(email: string) {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('userId');
    await axios.post(`${authControllerUrl}/revoke`, {email: email});

}
export async function LogoutAll(){
    localStorage.removeItem('accessToken');
    localStorage.removeItem('userId');
    await axios.post(`${authControllerUrl}/revokeall`);
}

export async function RefreshToken(): Promise<string> {
    const accessToken = localStorage.getItem('accessToken');
    const response = await axios.post(`${authControllerUrl}/refreshtoken`, { accessToken });
    if (response.status !== 200) {
        throw new Error('Failed to refresh token');
    }
    return response.data.accessToken;
}

export function SetInterceptors() {

    axios.interceptors.request.use(
        async (config) => {
            if (!isAccessTokenValid()) {
                // Refresh token logic (call your refresh token endpoint)
                const newAccessToken = await RefreshToken();
                localStorage.setItem('accessToken', newAccessToken);
                config.headers.Authorization = `Bearer ${newAccessToken}`;
            }
            return config;
        },
        (error) => Promise.reject(error)
    );

}

function isAccessTokenValid(): boolean {
    const storedToken = localStorage.getItem('accessToken');
    if (!storedToken) {
        return false; // No token stored
    }

    try {
        const decodedToken: Claims = jwtDecode(storedToken);
        const expirationTime = decodedToken.exp * 1000;
        const currentTime = Date.now();
        return expirationTime > currentTime;
    } catch (error) {
        console.error('Error decoding token:', error);
        return false; // Handle decoding errors conservatively
    }
}
