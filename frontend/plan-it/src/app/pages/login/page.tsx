"use client";
import { LoginUser, SetInterceptors } from "@/app/services/AuthService";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState } from "react";

export default function Login() {
    const [email, setemail] = useState('');
    const [password, setPassword] = useState('');

    const router = useRouter();
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await LoginUser({ email, password });
        SetInterceptors();
        console.log(localStorage.getItem('userId'));
        router.push('/pages/home');
    };

    return (
        <div className="container mt-5">
            <div className="d-flex justify-content-center align-items-center">
                <div className="col-5">
                    <h2>Login</h2>
                    <form onSubmit={handleSubmit} className="row">
                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="email" className="form-label">email</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="email"
                                    placeholder="Enter email"
                                    value={email}
                                    onChange={(e) => setemail(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="password" className="form-label">Password</label>
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
                        <div className="col-12 d-flex flex-row justify-content-between mt-3">
                            <button type="submit" className="btn btn-primary">
                                Login
                            </button>
                            <Link href="/pages/register" className="align-self-center">Dont have an account? </Link>
                        </div>
                    </form>

                </div>
            </div>

        </div>
    );
}