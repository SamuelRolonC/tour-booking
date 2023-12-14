import React, { useEffect } from "react";
import { useState } from "react";
import './GridBooking.css';
import { useNavigate } from "react-router-dom";
import { useAppParameters } from "../Utils/useAppParameters";

function GridBooking() {
    const [data, setData] = useState([]);
    const navigate = useNavigate();
    const { getApiBookingAllUrl, getApiBookingRemoveUrl, getAppBookingIdNavigate, getAppTourGridNavigate, getAppBookingGridNavigate } = useAppParameters();

    const getData = () => {
        fetch(getApiBookingAllUrl(), {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(json => {
            console.log('Success');
            setData(json.data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    const deleteItem = (id) => {
        fetch(getApiBookingRemoveUrl(id), {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(json => {
            if (json.successful) {
                console.log('Success');
            } else {
                let message = 'Error: ' + json.messages[0];
                console.log(message);
                alert(message);
            }
            navigate(0);
        })
        .catch((error) => {
            console.error('Server error: ', error);
            alert('Server error: ', error);
        });
    }

    useEffect(() => {
        getData();
    }, []);

    const onClickNewBooking = (id) => {
        navigate(getAppBookingIdNavigate(id));
    }

    const onClickDeleteBooking = (id) => {
        deleteItem(id);
    }

    const onClickTours = () => {
        navigate(getAppTourGridNavigate());
    }

    return (
        <div className='Grid'>
            <h2>Reservas</h2>
            <button onClick={() => onClickTours()}>Tours</button>
            <button onClick={() => onClickNewBooking(0)}>Nuevo</button>
            <table className="tableGrid center">
                <tr className="tableHeader">
                    <th>ID</th>
                    <th>Cliente</th>
                    <th>Fecha</th>
                    <th>Tour</th>
                    <th></th>
                </tr>
                {data.map((item, index) => (
                    <tr className="tableRow" key={index}>
                        <td>{item.id}</td>
                        <td>{item.customer}</td>
                        <td>{item.date}</td>
                        <td>{item.tourName}</td>
                        <td>
                            <button onClick={() => onClickDeleteBooking(item.id)}>Eliminar</button>
                        </td>
                    </tr>
                ))}
            </table>
        </div>
    );
}

export { GridBooking };