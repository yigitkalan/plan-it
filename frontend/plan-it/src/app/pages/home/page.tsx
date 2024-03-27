"use client";
import BoardCard from "@/app/components/BoardCard/BoardCard";
import { Board } from "@/app/models/Board";
import { GetAllBoards } from "@/app/services/BoardService";
import { useEffect, useState } from "react";

export default function Home() {
    const [boards, setBoards] = useState<Board[]>([]);

    useEffect(() => {
        const fetchBoards = async () => {
            var boardsData = await GetAllBoards();
            setBoards(boardsData);
        }
        fetchBoards();
    });
    return (
        <div className="p-5">
            <h1>My Boards</h1>
            <div className="d-flex flex-row flex-wrap p-4">
                {boards.map((board, index) => (
                    <BoardCard key={board.id | index} board={board} />
                ))}
            </div>
        </div>

    );
}