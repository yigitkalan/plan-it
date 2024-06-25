import { Item } from "./Item";

export interface Column{
    id: string;
    order: number;
    name: string;
    boardId: string;
    tasks: Item[] 

}