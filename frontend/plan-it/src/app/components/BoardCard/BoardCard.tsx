"use client";
import { Board } from "@/app/models/Board";
import { useRouter } from "next/navigation";

export default function BoardCard({ board }: { board: Board }) {
    const router = useRouter();
    const handleClick = () => {
        router.push(`/pages/board/${board.id}`)
    }
    return (
        <div className="card col-lg-2 col-sm-8 m-4">
            <div className="card-body">
                <div className="d-flex flex-column ">
                    <h5 className="card-title pb-4">{board.name}</h5>
                    <button onClick={handleClick} className="btn btn-primary align-self-end">Open</button>
                </div>
            </div>
        </div>
    );
}
