import axios from "axios";
import { Board } from "../models/Board";
import { BACKEND_URL } from "../utils/config";

const controllerUrl = `${BACKEND_URL}api/Board`;


export async function GetAllBoards(): Promise<Board[]> {
    const response = await axios.get(`${controllerUrl}/GetAll`);
    const boardsData = response.data.boards;
    const boards = boardsData.map((board: any): Board => {
        return {
            id: board.id,
            name: board.name,
            ownerId: board.ownerId
        }
    })
    return boards;
}

export async function GetBoardById(id: string): Promise<Board> {
    const response = await axios.get(`${controllerUrl}/GetById/${id}`);
    const boardData = response.data.board;
    const board: Board = {
        id: boardData.id,
        name: boardData.name,
        ownerId: boardData.ownerId
    }
    return board;
}

export async function GetBoardsByUserId(userId: string): Promise<Board[]> {
    const response = await axios.get(`${controllerUrl}/GetByUser/${userId}`);
    const boardsData = response.data.boards;
    const boards = boardsData.map((board: any): Board => {
        return {
            id: board.id,
            name: board.name,
            ownerId: board.ownerId
        }
    })
    return boards;
}

export async function CreateBoard(name: string, ownerId: string): Promise<Board> {
    const response = await axios.post(`${controllerUrl}/Create`, { name: name, ownerId: ownerId });
    const boardData = response.data.board;
    const newBoard: Board = {
        id: boardData.id,
        name: boardData.name,
        ownerId: boardData.ownerId
    }
    return newBoard;
}

export async function UpdateBoard(id: string, name: string): Promise<Board> {
    const response = await axios.put(`${controllerUrl}/Update`, {id, name});
    const boardData = response.data.board;
    const updatedBoard: Board = {
        id: boardData.id,
        name: boardData.name,
        ownerId: boardData.ownerId
    }
    return updatedBoard;
}

export async function DeleteBoard(id: string): Promise<void> {
    await axios.delete(`${controllerUrl}/Delete/${id}`);
}   

export async function JoinBoard(boardId: string, userId: string): Promise<void> {
    await axios.post(`${controllerUrl}/adduser`, { boardId, userId });
}

export async function LeaveBoard(boardId: string, userId: string): Promise<void> {
    await axios.post(`${controllerUrl}/removeuser`, { boardId, userId });
}
