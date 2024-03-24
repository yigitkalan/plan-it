import BoardCard from "@/app/components/BoardCard/BoardCard";
import { GetAllBoards } from "@/app/services/BoardService";

export default async function Home() {
    const boards = await GetAllBoards();
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