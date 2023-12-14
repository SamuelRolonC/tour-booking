import React, { useEffect } from "react";
import { useState } from "react";
import './GridTour.css';
import { useNavigate } from "react-router-dom";
import { useAppParameters } from "../Utils/useAppParameters";

function GridTour() {
    const [data, setData] = useState([]);
    const navigate = useNavigate();
    const { getApiTourAllUrl, getAppTourIdNavigate, getAppBookingGridNavigate } = useAppParameters();

    const getData = () => {
        fetch(getApiTourAllUrl(), {
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

    useEffect(() => {
        getData();
    }, []);

    const onClickNewTour = (id) => {
        navigate(getAppTourIdNavigate(id));
    }

    const onClickBookings = () => {
        navigate(getAppBookingGridNavigate());
    }

    return (
        <div className='Grid'>
            <h2>Tours</h2>
            <button onClick={() => onClickBookings()}>Reservas</button>
            <button onClick={() => onClickNewTour(0)}>Nuevo</button>
            <table className="tableGrid center">
                <tr className="tableHeader">
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Destino</th>
                    <th>Inicio</th>
                    <th>Fin</th>
                    <th>Precio</th>
                    <th></th>
                </tr>
                {data.map((item, index) => (
                    <tr className="tableRow" key={index}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.destination}</td>
                        <td>{item.startDate}</td>
                        <td>{item.endDate}</td>
                        <td>{item.price}</td>
                    </tr>
                ))}
            </table>
        </div>
    );
}

export { GridTour };