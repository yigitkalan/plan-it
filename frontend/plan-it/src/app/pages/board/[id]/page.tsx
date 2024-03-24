import ColumnCard from "@/app/components/ColumnCard/ColumnCard";
import { GetColumnsByBoardId } from "@/app/services/ColumnService";
import { GetTasksByColumnId } from "@/app/services/TaskService";

export default async function Board({params}: {params: {id: string}}){
    const columns = await GetColumnsByBoardId(parseInt(params.id));
    return (
        <div className="p-4 d-flex flex-row h-100">
            <div className="col-2 d-flex flex-column p-3 pt-5">
                <div className="p-3">Board Settings</div>
                <div className="p-3">Members</div>
            </div>
            <div className="col-10 d-flex flex-row ">
                {columns.map(async (column, index) => (
                    <ColumnCard tasks={await GetTasksByColumnId(column.id) } key={column.id | index} column={column} />
                ))}
            </div>
        </div>
    ); 
}