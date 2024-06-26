"use client";
import { Column } from "@/app/models/Column";
import { Item } from "@/app/models/Item";
import { useState } from "react";

export default function ColumnCard({ column, tasks }: { column: Column, tasks:Item[] }) {
    const [items, setItems] = useState<Item[]>(tasks)
    const [newTaskTitle, setNewTaskTitle] = useState("");


    const handleAddClick = () => {
        if (!newTaskTitle.trim()) {
            return; // Prevent creating empty tasks
        }
        const item: Item = {
            id: "",
            title: newTaskTitle,
            columnId: column.id,
            description: "",
            order: 2
        }
        setItems([...items, item]);

        // const newTask: TaskAddDto = {
        //     title: newTaskTitle,
        //     description: "", // Replace with default description if needed
        //     columnId: column.id,
        // };

        // setItems([...items, newTask]);
        setNewTaskTitle(""); // Clear input field after adding task
    };

    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewTaskTitle(event.target.value);
    };

    return (
        <div className="card p-2 m-2 h-100 col-2">
            <h4>{column.name}</h4>
            <div className="d-flex flex-column">
                {items.map((item , index) => (
                    <div key={index} className="card p-2 m-2">
                        <p>{item.title}</p>
                    </div>
                ))}
                <div className="m-2">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Add a task..."
                        value={newTaskTitle}
                        onChange={handleTitleChange}
                    />
                </div>
                <button onClick={handleAddClick} className="btn btn-primary align-self-end mt-3 m-2" style={{ fontSize: "0.8rem" }}>Add Task</button>
            </div>
        </div>
    );
}