import { Column } from "../models/Column";

const columns: Column[] = [
    { id: 1, boardId: 1, name: "To Do"},
    { id: 2, boardId: 1, name: "In Progress"},
    { id: 3, boardId: 1, name: "Done"},
    { id: 4, boardId: 2, name: "Groceries"},
];

export function GetColumnsByBoardId(boardId: number){
    return columns.filter(column => column.boardId === boardId);
}