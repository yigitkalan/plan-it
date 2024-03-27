import axios from "axios";
import { Item } from "../models/Item";


import { BACKEND_URL } from "../utils/config";

const controllerUrl = `${BACKEND_URL}api/Item`;


export async function GetAllItems(): Promise<Item[]> {
    const response = await axios.get(`${controllerUrl}/GetAll`);
    const itemsData = response.data.items;
    const items = itemsData.map((item: any): Item => {
        return {
            id: item.id,
            order: item.order,
            title: item.name,
            description: item.description,
            columnId: item.columnId
        }
    })
    return items;
}

export async function GetItemById(id: string): Promise<Item> {
    const response = await axios.get(`${controllerUrl}/GetById/${id}`);
    const itemData = response.data.item;
    const item: Item = {
        id: itemData.id,
        order: itemData.order,
        title: itemData.name,
        description: itemData.description,
        columnId: itemData.columnId
    }
    return item;
}

export async function GetByColumnId(columnId: string): Promise<Item[]> {
    const response = await axios.get(`${controllerUrl}/GetByColumnId/${columnId}`);
    const itemsData = response.data.items;
    const items = itemsData.map((item: any): Item => {
        return {
            id: item.id,
            order: item.order,
            title: item.name,
            description: item.description,
            columnId: item.columnId
        }
    })
    return items;
}

export async function CreateItem(title: string, description: string, columnId: string, order: number): Promise<Item> {
    const response = await axios.post(`${controllerUrl}/Create`,
        { title: title, description: description, columnId: columnId, order: order });

    const itemData = response.data.item;
    const newItem: Item = {
        id: itemData.id,
        order: itemData.order,
        title: itemData.name,
        description: itemData.description,
        columnId: itemData.columnId
    }
    return newItem;
}

export async function UpdateItem(id: string, title: string, description: string
    , order: number, columnId: string): Promise<Item> {
    const response = await axios.put(`${controllerUrl}/Update`,
        { id: id, title: title, description: description, order: order, columnId: columnId });

            //TODO DATA.ITEM ne bilmiyoruz
    const itemData = response.data.item;
    const updatedItem: Item = {
        id: itemData.id,
        order: itemData.order,
        title: itemData.name,
        description: itemData.description,
        columnId: itemData.columnId
    }
    return updatedItem;
}

export async function DeleteItem(id: string): Promise<void> {
    await axios.delete(`${controllerUrl}/Delete/${id}`);
}