import logo from './logo.svg';
import './App.css';
import TodoForm from './components/TodoForm';
import GetTodos from './components/GetTodos';

function App() {
  return (
    <div className="App">
      <TodoForm/>
      <hr/>
      <GetTodos/>
    </div>
  );
}

export default App;
