import logo from './logo.svg';
import { useState, useEffect } from 'react';
import { flushSync } from 'react-dom';
import './App.css';

function App() {
    const [calc, setCalc] = useState("");
    const [result, setResult] = useState("");

    const ops = ["/", "*", "+", "-", "."];

    let savedItem = JSON.parse(localStorage.getItem("history"));
    if (!savedItem) {
        savedItem = [];
    }
    const [items, setItems] = useState(savedItem);



    const addEntry = (entry) => {
        setItems([...items, entry]);
    };

    useEffect(() => {
        localStorage.setItem("history", JSON.stringify(items));
    }, [items]);


    let calculation = "";

    const updateCalc = value => {

        if (ops.includes(value) && calc === '' || ops.includes(value) && ops.includes(calc.slice(-1))) {
            return
        } else {
            setCalc(calc + value);
        }   
    }

    const deleteLast = () => {
        if (calc == '') {
            return
        } else {
            const value = calc.slice(0, -1);
            setCalc(value)
        }
    }

    const clear = () => {
        setCalc('')
    }

    function handleSubmit(e) {
        // avoid refreshing
        e.preventDefault()

        fetch("http://localhost:5000/calculate", {
            headers: { "Content-Type": "application/json" },
            method: "POST",
            body: JSON.stringify({
                "calc": calc,
            })
        }).then(res => res.json())
            .then(json => {
                setCalc(json.solution);
                addEntry(json.history)
                
            }).catch = (err) => {
                setCalc("ERROR");
            }
    }
    

    return (
        <div className="App">
            <div className="calculator">
                <div className="display">
                    {calc || "0"}
                </div>


                
                <div className="functions">
                    <button>Sqrt</button>
                    <button>^2</button>
                    <button onClick={() => deleteLast()}>DEL</button>
                    <button onClick={() => clear()}>C</button>
                </div>

                <div className="inputs">
                    <div className="operators">
                        <button onClick={() => updateCalc('/')}>/</button>
                        <button onClick={() => updateCalc('*')}>*</button>
                        <button onClick={() => updateCalc('-')}>-</button>
                        <button onClick={() => updateCalc('+')}>+</button>
                    </div>

                    <div className="digits">
                        <button onClick={() => updateCalc('7')}>7</button>
                        <button onClick={() => updateCalc('8')}>8</button>
                        <button onClick={() => updateCalc('9')}>9</button>
                        <button onClick={() => updateCalc('4')}>4</button>
                        <button onClick={() => updateCalc('5')}>5</button>
                        <button onClick={() => updateCalc('6')}>6</button>
                        <button onClick={() => updateCalc('1')}>1</button>
                        <button onClick={() => updateCalc('2')}>2</button>
                        <button onClick={() => updateCalc('3')}>3</button>
                        <button onClick={() => updateCalc('0')}>0</button>
                        <button onClick={() => updateCalc('.')}>.</button>
                        <button onClick={e => handleSubmit(e)}>=</button>
                    </div>
                </div>

            </div>
            <div className="history">
                <ul className="historyList">
                    {items.map(entry =>
                        <li>{entry}</li>
                    )}
                </ul>
            </div>
        </div>
    );
}

export default App;
