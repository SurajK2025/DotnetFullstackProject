import { useState } from "react";
import axios from 'axios';

const UpdateData = (props) => {
    const [id, setId] = useState({ userid: "" });
    const [apiData, setApiData] = useState({ username: "", course: "", purchasedate: "" });

    const savedata = (event) => {
        event.preventDefault();
        axios.put(`http://localhost:5213/api/users/${id.}`, apiData);
    }

    const handleChange = (event) => {
        const { name, value } = event.target
        setApiData({ ...apiData, [name]: value })

    }

    const handleChangedId = (event) => {
        const { name, value } = event.target
        setId({ ...id, [name]: value })

    }

    return (
        <>
            <br /><br />
            <h4>Update user</h4>
            <form method="POST" onSubmit={savedata}>
                <input type="text" name="userid" onChange={handleChangedId} placeholder="Id" />
                <input type="text" name="username" onChange={handleChange} placeholder="UserName" />
                <input type="text" name="course" onChange={handleChange} placeholder="Course" />
                <input type="text" name="purchasedate" onChange={handleChange} placeholder="PurchaseDate" />
                <input type="Submit" value="Update" />
            </form>
        </>
    );

}
export default UpdateData;