"use client";
import { User } from "@/app/models/User";
import { GetById, UpdateUser } from "@/app/services/UserService";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";

export default function EditUser({ params }: { params: { id: string } }) {

    const [userData, setUserData] = useState<User>({} as User);
    const [username, setUsername] = useState<string>("");
    const [email, setEmail] = useState<string>("");

    const router = useRouter();

    useEffect(() => {
        const fetchUser = async (userId: string) => {
            try {
                const user = await GetById(userId);
                console.log("USSERRR", user);
                setUserData(user);
                setUsername(user.userName);
                setEmail(user.email);
            } catch (error: Error | any) {
                throw new Error("Error fetching user from backend", error);
            }
        };
        fetchUser(params.id);
    }, []);

    const handleSave = async () => {
        try {
            const newUser: User = {
                id: userData.id,
                userName: username,
                email: email,
            };
            const updatedUser = await UpdateUser(newUser);
            router.back();
        } catch (error) {
            console.error("Error saving user:", error);
        }
    };

    return (
        <div className="container">
            <h1>Edit User</h1>
            <div className="form-group">
                <label htmlFor="username">Username</label>
                <input
                    type="text"
                    className="form-control"
                    id="username"
                    name="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
            </div>
            <div className="form-group">
                <label htmlFor="email">Email</label>
                <input
                    type="email"
                    className="form-control"
                    id="email"
                    name="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>
            <button className="btn btn-primary mt-3" onClick={handleSave}>
                Save
            </button>
        </div>
    );
};