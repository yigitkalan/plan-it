import { Task } from "../models/Task";

const tasks: Task[] = [
    { id: 1, title: "Task 1", description: "Description 1", columnId: 1},
    { id: 2, title: "Task 2", description: "Description 2", columnId: 1},
    { id: 3, title: "Task 3", description: "Description 3", columnId: 2},
    { id: 4, title: "Task 4", description: "Description 4", columnId: 2},
    { id: 5, title: "Task 5", description: "Description 5", columnId: 3},
    { id: 6, title: "Task 6", description: "Description 6", columnId: 3},
    { id: 7, title: "Task 6", description: "Description 6", columnId: 3},
];

export async function GetTasksByColumnId(columnId: number){
    return tasks.filter(task => task.columnId === columnId);
}