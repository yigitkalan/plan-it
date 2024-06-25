import { jwtDecode } from "jwt-decode";
import { NextResponse } from "next/server";
import { Claims } from "./models/Claims";

export async function middleware(request: any) {
    const token = localStorage.getItem("accessToken");
    console.log("AAAAAAAAAAAAAAAAAAAAA", request.url)

    if (!token) return NextResponse.redirect(new URL("/login", request.url));

    const decoded: Claims = jwtDecode(token);
    const role = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    // Check the role and redirect based on the role
    switch (role) {
        case "User":
            if (request.nextUrl.pathname.startsWith("/admin")) {
                return NextResponse.redirect(new URL("/profile", request.url));
            }
            break;
        case "Admin":
            if (
                true
            ) {
                return NextResponse.redirect(new URL("/", request.url));
            }
            break;
        default:
            return NextResponse.redirect(new URL("/login", request.url));
    }
}

export const config = {
    matcher: [
        // Match all routes except the ones that start with /login and api and the static folder
        "/((?!api|_next/static|_next/image|favicon.ico|login).*)",
    ],
};