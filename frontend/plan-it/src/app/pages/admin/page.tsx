import Link from "next/link"

export default function AdminPage() {
    return (
        <div className="container d-flex flex-row mt-4 pt-4">
            <ul>
                <li className="mb-3">
                    <Link className="fs-2 text-decoration-none fst-italic " href={"/pages/admin/users"}>Users</Link>
                </li>
                <li>
                    <Link className="fs-2 text-decoration-none fst-italic " href={"/pages/admin/users"}>Boards</Link>

                </li>

            </ul>

        </div>
    );
}
