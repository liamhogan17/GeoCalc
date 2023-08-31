import React, { useState, useEffect } from 'react';

const ClassList = () => {
    const [items, setItems] = useState([]);
    const grade = "1";

    useEffect(() => {
        fetch(`class/${grade}`)
        .then((results) => {
            return results.json();
        })
        .then(data => { 
            setItems(data);
        })
    }, []);

    return (
        <main>
            {
                (items != null) ? items.map((item) => <h3>{item.name}</h3>) : <div>Loading . . .</div>
            }
        </main>    
    )
}
export default ClassList;