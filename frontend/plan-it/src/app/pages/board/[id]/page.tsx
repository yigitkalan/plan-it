import ColumnCard from "@/app/components/ColumnCard/ColumnCard";
import { Board } from "@/app/models/Board";
import { Column } from "@/app/models/Column";
import { GetByColumnId } from "@/app/services/ItemService";

export default async function Board({ params }: { params: { id: string } }) {
    const dummyColumnData: Column[] = [
        {
            id: "col_123",
            order: 1,
            name: "To Do",
            boardId: "board_abc",
            tasks: [
                {
                    id: "task_456",
                    title: "Write unit tests",
                    description: "Ensure code functionality",
                    columnId: "col_123",
                    order: 1,
                },
                {
                    id: "task_789",
                    title: "Fix critical bug",
                    description: "Top priority issue",
                    columnId: "col_123",
                    order: 2,
                },
            ],
        },
        {
            id: "col_456",
            order: 2,
            name: "In Progress",
            boardId: "board_abc",
            tasks: [],
        },
        {
            id: "col_789",
            order: 3,
            name: "Done",
            boardId: "board_abc",
            tasks: [],
        },
    ];
    return (
        <div className="p-4 d-flex flex-row h-100">
            <div className="col-2 d-flex flex-column p-3 pt-5">
                <div className="p-3">Board Settings</div>
                <div className="p-3">Members</div>
            </div>
            <div className="col-10 d-flex flex-row ">
                {dummyColumnData.map((column, index) => (
                    <ColumnCard tasks={
                        [
                            {
                                id: "task_456",
                                title: `Task ${column.id}`,
                                description: "Ensure code functionality",
                                columnId: "col_123",
                                order: 1,
                            },
                            {
                                id: "task_789",
                                title: `Bug  + ${column.id}`,
                                description: "Top priority issue",
                                columnId: "col_123",
                                order: 2,
                            },
                        ]
                    } key={column.id} column={column} />
                ))}
            </div>
        </div>
    );
}