"use client";

import { RegisterCredentials } from "@/app/models/RegisterCredentials";
import { Register } from "@/app/services/AuthService";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState } from "react";

export default function RegisterPage() {

    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [passwordAgain, setPasswordAgain] = useState('');
    const router = useRouter();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        const cred: RegisterCredentials = {
            email: email,
            username: username,
            password: password,
        };

        await Register(cred);
        router.push('/pages/login');
        
    };
    return (
        <div className="container mt-5">
            <div className="d-flex justify-content-center align-items-center">
                <div className="col-5">
                    <h2>Register</h2>
                    <form onSubmit={handleSubmit} className="row">
                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="email" className="form-label mt-3">email</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="email"
                                    placeholder="Enter email"
                                    value={email}
                                    onChange={(e) => setEmail(e.target.value)}
                                />
                            </div>
                        </div>

                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="username" className="form-label mt-3">username</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="username"
                                    placeholder="Enter username"
                                    value={username}
                                    onChange={(e) => setUsername(e.target.value)}
                                />
                            </div>
                        </div>

                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="password" className="form-label mt-3">Password</label>
                                <input
                                    type="password"
                                    className="form-control"
                                    id="password"
                                    placeholder="Password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                />
                            </div>
                        </div>

                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="repeatPassword" className="form-label mt-3 mt-3">repeatPassword</label>
                                <input
                                    type="password"
                                    className="form-control"
                                    id="repeatPassword"
                                    placeholder="Enter repeatPassword"
                                    value={passwordAgain}
                                    onChange={(e) => setPasswordAgain(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="col-12 d-flex flex-row justify-content-between mt-3">
                            <button type="submit" className="btn btn-primary">
                                Register
                            </button>
                            <Link href="/pages/login" className="align-self-center">Already have an account</Link>
                        </div>
                    </form>

                </div>
            </div>

        </div>
    );
}