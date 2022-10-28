import { useState, useEffect } from 'react';

export default function Calculator(props) {
    const ops = ["/", "*", "+", "-", "."];
    const [calc, setCalc] = useState("");

    //Updates local storage after changed to items


    /*useEffect(() => {
        localStorage.setItem("history", JSON.stringify(items));
    }, [items]);
    */


    const addEntry = (entry) => {
        props.dataSetItems([...props.dataItems, entry]);
        fetch('https://localhost:7166/api/History', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: "\"" + entry + "\""
        });
    };

    //Check to make sure input selected is valid, no initial operator before number or double operators
    const updateCalc = value => {
        if ((ops.includes(value) && calc=== '') || (ops.includes(value) && ops.includes(calc.slice(-1)))) {
            return
        } else if (calc=== 'ERROR') {
            setCalc(value);
        } else {
            setCalc(calc+ value);
        }
    }

    //Deletes last input in calc
    const deleteLast = () => {
        if (calc=== '') {
            return
        } else {
            const value = calc.slice(0, -1);
            setCalc(value)
        }
    }

    const clear = () => {
        setCalc('')
    }

    //Api handler sends calc and gets response with solution and history
    function handleSubmit(e) {
        // avoid refreshing
        e.preventDefault()

        console.log(calc);
        fetch('https://localhost:7166/api/Operator', {
            headers: { "Content-Type": "application/json" },
            method: "POST",
            body: "\"" + calc+ "\"",
        }).then(res => {
            if (!res.okay) {
                setCalc("ERROR")

            }
            return res.json();
        })
            .then(json => {
                console.log(calc+ " = " + json.calc),
                addEntry(calc+ " = " + json.calc),
                setCalc(json.calc)
            }).catch = (err) => {
                return;
        }   
    }

    //Api handler sends calcand gets response with solution and history
    function squareSubmit(e) {
        // avoid refreshing
        e.preventDefault()

        console.log(calc);
        fetch('https://localhost:7166/api/Operator/square', {
            headers: { "Content-Type": "application/json" },
            method: "POST",
            body: "\"" + calc+ "\"",
        }).then(res => res.json())
            .then(json => {
                console.log(calc+ "² = " + json.calc);
                addEntry(calc+ "² = " + json.calc);
                setCalc(json.calc);

            }).catch = (err) => {
                setCalc("ERROR");
            }
    }

    //Api handler sends calcand gets response with solution and history
    function sqrtSubmit(e) {
        // avoid refreshing
        e.preventDefault()

        console.log(calc);
        fetch('https://localhost:7166/api/Operator/sqrt', {
            headers: { "Content-Type": "application/json" },
            method: "POST",
            body: "\"" + calc+ "\"",
        }).then(res => res.json())
            .then(json => {
                console.log("√(" + calc+ ") = " + json.calc);
                addEntry("√(" + calc+ ") = " + json.calc);
                setCalc(json.calc);

            }).catch = (err) => {
                setCalc("ERROR");
            }
    }

    return (
        <div className="calculator">
            <div className="display">
                {calc || "0"}
            </div>

            <div className="functions">
                <button className="button" onClick={e => sqrtSubmit(e)}>√x</button>
                <button className="button" onClick={e => squareSubmit(e)}>x²</button>
                <button className="button" onClick={() => deleteLast()}>DEL</button>
                <button className="button" onClick={() => clear()}>C</button>
            </div>

            <div className="inputs">
                <div className="operators">
                    <button className="button" onClick={() => updateCalc('/')}>/</button>
                    <button className="button" onClick={() => updateCalc('*')}>*</button>
                    <button className="button" onClick={() => updateCalc('-')}>-</button>
                    <button className="button" onClick={() => updateCalc('+')}>+</button>
                </div>

                <div className="digits">
                    <button className="button" onClick={() => updateCalc('7')}>7</button>
                    <button className="button" onClick={() => updateCalc('8')}>8</button>
                    <button className="button" onClick={() => updateCalc('9')}>9</button>
                    <button className="button" onClick={() => updateCalc('4')}>4</button>
                    <button className="button" onClick={() => updateCalc('5')}>5</button>
                    <button className="button" onClick={() => updateCalc('6')}>6</button>
                    <button className="button" onClick={() => updateCalc('1')}>1</button>
                    <button className="button" onClick={() => updateCalc('2')}>2</button>
                    <button className="button" onClick={() => updateCalc('3')}>3</button>
                    <button className="button" onClick={() => updateCalc('0')}>0</button>
                    <button className="button" onClick={() => updateCalc('.')}>.</button>
                    <button className="button" onClick={e => handleSubmit(e)}>=</button>
                </div>
            </div>

        </div>
    )
}