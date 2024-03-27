"use client";
import { User } from "@/app/models/User";
import { DeleteUser, GetAll } from "@/app/services/UserService";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";

export default function Users() {
    const [users, setUsers] = useState<User[]>([]);
    const router = useRouter();

    const handleEditUser = async (id: string) => {
        router.push(`/pages/admin/users/edit/${id}`);
    }

    const [showConfirmation, setShowConfirmation] = useState(false);
    const [deleteId, setDeleteId] =  useState<string>("");

    const handleDelete = async (userId: string) => {
        setDeleteId(userId);
        if (showConfirmation) {
            // Call the onDelete function to delete the user
            await DeleteUser(userId);
            //reload window
            window.location.reload();
            // Hide the confirmation dialog
            setShowConfirmation(false);
        } else {
            // Show the confirmation dialog
            setShowConfirmation(true);
        }
    };

    useEffect(() => {
        const fetchUsers = async () => {
            const response = await GetAll();
            setUsers(response);
        }
        fetchUsers();
    }, []);

    return (<div className="container">
        <div className="d-flex justify-content-between">
            <h1>Users Page</h1>
        </div>
        <table className="table table-striped">
            <thead>
                <tr>
                    <th>User ID</th>
                    <th>Full Name</th>
                    <th>Email</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {users.map((user) => (
                    <tr key={user.id}>
                        <td>{user.id}</td>
                        <td>{user.userName}</td>
                        <td>{user.email}</td>
                        <td>
                            <button
                                className="btn btn-primary me-2"
                                onClick={() => handleEditUser(user.id)}
                            >
                                Edit
                            </button>
                            <button
                                className="btn btn-danger"
                                onClick={() => handleDelete(user.id)}
                            >
                                Delete
                            </button>
                            {(showConfirmation && (deleteId == user.id)) ? (
                                <div>
                                    <p>Are you sure you want to delete this user?</p>
                                    <button onClick={() => handleDelete(user.id)}>Yes</button>
                                    <button onClick={() => setShowConfirmation(false)}>
                                        No
                                    </button>
                                </div>
                            ) : null}
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
    );


}