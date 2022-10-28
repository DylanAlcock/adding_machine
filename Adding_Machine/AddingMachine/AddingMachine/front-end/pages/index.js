import Head from 'next/head'
import Image from 'next/image'
import { useState, useEffect } from 'react';
import HistoryArea from './../components/HistoryArea'
import Calculator from './../components/Calculator'

export default function Home() {
    
    const [items, setItems] = useState([]);


    
    async function getHistory() {
        try {
            
            const response = await fetch('https://localhost:7166/api/AddMachine');

            if (!response.ok) {
                throw new Error(`Error! status: ${response.status}`);
            }

            var arr = new Array();
            const result = await response.json();
            result.data.forEach((entry) => arr.push(entry.equation));
            console.log(arr);
            setItems(arr)
            return result;
        } catch (err) {
            console.log(err);
        }
    }

    //Used to call getHistory once when the page loads
    useEffect(() => {
        getHistory();
    }, [""]);


    return (
        <div className="App">
            <div className="title">
                <h1>LegacyX Virtual Adding Machine</h1>
            </div>
            
            <Calculator dataItems={items} dataSetItems={setItems}/>
            <HistoryArea dataItems={items} dataSetItems={setItems} />
        </div>
    );
}