import React, { useState, useEffect } from 'react';

const ClassList = () => {
    const [items, setItems] = useState([]);
    const grade = "10";

    useEffect(() => {
        fetch(`Class/GetAllClasses/Grade/${grade}`)
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
                (items != null) ?
                    <table class="table table-hover">
                        <thead class="table-dark">
                            <tr>
                                <th>Name</th>
                                <th>Subject</th>
                                <th>Grade</th>
                            </tr>
                        </thead>
                        <tbody>
                            {items.map((item, key) => {
                                return (
                                    <tr key={key}>
                                        <td>{item.name}</td>
                                        <td>{item.subject}</td>
                                        <td>{item.grade}</td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                : <div>Loading . . .</div>
            }
        </main>
    )
}
export default ClassList;