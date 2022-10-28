
export default function HistoryArea(props) {

    //Clear items and local storage
    const clearHistory = () => {
        console.log("Clearing history");
        props.dataSetItems([]);
        fetch('https://localhost:7166/api/History', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
        });
    }

    return (
        <div className="history">
            <ul className="historyList">
                {props.dataItems.map(entry =>
                    <li key={entry }>{entry}</li>
                )}
            </ul>
            <button className="reset" onClick={() => clearHistory()}> Reset</button>
        </div>
    )
}
