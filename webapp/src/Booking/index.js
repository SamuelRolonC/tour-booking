import React, { useState } from "react";
import './Booking.css';
import { useNavigate, useParams } from "react-router-dom";
import { useAppParameters } from "../Utils/useAppParameters";

function Booking() {
    const navigate = useNavigate();
    const [ formData, setFormData ] = useState({ name: '', destination: '', email: '', startDate: '', endDate: '',price: '' });
    const [ tourSelectData, setTourSelectData ] = useState([]);
    const [ validation, setValidation ] = useState([]);
    const [ displayValidation, setDisplayValidation ] = useState('none');
    const { id } = useParams();
    const { getApiBookingPostUrl, getApiTourAllUrl, getAppBookingGridNavigate } = useAppParameters();

    const getTourSelectData = () => {
        fetch(getApiTourAllUrl(), {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(json => {
            console.log('Success');
            setTourSelectData(json.data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    React.useEffect(() => {
        getTourSelectData();
    }, [id]);

    const onSubmit = (e) => {
        e.preventDefault();
        console.log(id);
        console.log(formData);

        fetch(getApiBookingPostUrl(), {
            method: id > 0 ? 'PUT' : 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                id: id,
                customer: formData.customer,
                date: formData.date,
                tourId: formData.tourId,
            }),
        })
        .then(response => response.json())
        .then(json => {
            if (json.successful) {
                console.log('Success');
                navigate(getAppBookingGridNavigate());
            }
            else if (json.messages != null && json.messages.length > 0) {   
                console.log(json.messages);
                setValidation(json.messages);
                setDisplayValidation('inline-block');
            }
            else {
                console.log('Error: ', json);
                alert('Error al guardar los datos.');
            }
        })
        .catch((error) => {
            console.error('Error:', error);
            alert('Error al guardar los datos.');
        });
    }

    const onClickBack = () => {
        navigate(getAppBookingGridNavigate());
    }

    const onChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
    };

    return (
        <div className='Booking'>
            <h2>Booking</h2>
            <div>
                <button type="button" onClick={onClickBack}>Volver</button>
            </div>
            <div>
                <ul id="validation-list" style={{display: displayValidation}}>
                    {validation.map((element, index) => (
                        <li key={index}>{element}</li>
                    ))}
                </ul>
            </div>
            <form onSubmit={onSubmit}>
                <div className="form-group">
                    <label>Cliente</label>
                    <input type="text" name="customer" value={formData.customer} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Fecha</label>
                    <input type="date" name="date" value={formData.date} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Tour</label>
                    <select name="tourId" value={formData.tourId} onChange={onChange} className="form-control" >
                        {tourSelectData.map((option, index) => (
                            <option key={index} value={option.id}>{option.name}</option>
                        ))}
                    </select>
                </div>
                <button type="submit" className="button-primary">Guardar</button>
            </form>
        </div>
    );
}

export { Booking };