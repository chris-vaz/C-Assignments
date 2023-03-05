import { useEffect, useState } from "react";
import axios from 'axios';
import TodoForm from "./TodoForm";
const GetTodos = props => {
    const [allTasks, setAllTasks] = useState(null);
    const [update, setUpdate] = useState(false);
    useEffect(() => {
        axios.get("https://localhost:7257/api/todoitems")
            .then(res => setAllTasks(res.data))
    }, [update])
    // This will be what tells the list of all todos to update
    const triggerUpdate = () => {
        setUpdate(!update);
    }
    return (
        <>
            <h2>My Todo List</h2>
            {
                allTasks ? allTasks.map((item, i) => <div key={i}>
                    <h4>
                        {item.name}
                        <input type="checkbox" name="isComplete" checked={item.isComplete} />
                    </h4>
                </div>)
                    : <h3>Loading...</h3>
            }
            <TodoForm triggerUpdate={triggerUpdate} />
        </>
    );
}
export default GetTodos;