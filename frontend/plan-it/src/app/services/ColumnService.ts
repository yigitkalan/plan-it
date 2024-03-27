import axios from "axios";
import { Column } from "../models/Column";
import { BACKEND_URL } from "../utils/config";

const controllerUrl = `${BACKEND_URL}api/Column`;


export async function GetAllColumns(): Promise<Column[]> {
    const response = await axios.get(`${controllerUrl}/GetAll`);
    const columnsData = response.data.columns;
    const columns = columnsData.map((column: any): Column => {
        return {
            id: column.id,
            order: column.order,
            name: column.name,
            boardId: column.boardId,
            tasks: column.tasks
        }
    })
    return columns;
}

export async function GetColumnById(id: string): Promise<Column> {
    const response = await axios.get(`${controllerUrl}/GetById/${id}`);
    const columnData = response.data.column;
    const column: Column = {
        id: columnData.id,
        order: columnData.order,
        name: columnData.name,
        boardId: columnData.boardId,
        tasks: columnData.tasks
    }
    return column;
}

export async function GetColumnsByBoardId(boardId: string): Promise<Column[]> {
    const response = await axios.get(`${controllerUrl}/GetByBoardId/${boardId}`);
    const columnsData = response.data.columns;
    const columns = columnsData.map((column: any): Column => {
        return {
            id: column.id,
            order: column.order,
            name: column.name,
            boardId: column.boardId,
            tasks: column.tasks
        }
    })
    return columns;
}

export async function CreateColumn(name: string, boardId: string, order: number): Promise<Column> {
    const response = await axios.post(`${controllerUrl}/Create`, { name: name, boardId: boardId, order: order });
    const columnData = response.data.column;
    const newColumn: Column = {
        id: columnData.id,
        order: columnData.order,
        name: columnData.name,
        boardId: columnData.boardId,
        tasks: columnData.tasks
    }
    return newColumn;
}

export async function UpdateColumn(columnId: string, name: string, order: number): Promise<Column> {
    const response = await axios.put(`${controllerUrl}/Update`, { columnId: columnId, name: name, order: order });
    const columnData = response.data.column;
    const updatedColumn: Column = {
        id: columnData.id,
        order: columnData.order,
        name: columnData.name,
        boardId: columnData.boardId,
        tasks: columnData.tasks
    }
    return updatedColumn;
}

export async function DeleteColumn(columnId: string): Promise<void> {
    await axios.delete(`${controllerUrl}/Delete/${columnId}`);
}