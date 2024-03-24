import { Board } from "../models/Board";

const boards: Board[] = [
    { id: 1, name: "My First Board", ownerId: 1},
    { id: 2, name: "My Second Board", ownerId: 1},
    { id: 3, name: "My Third Board", ownerId: 1},
    { id: 4, name: "My Fourth Board", ownerId: 1},
    { id: 5, name: "My Fifth Board", ownerId: 1},
];

export async function GetAllBoards(){
    return boards;

}