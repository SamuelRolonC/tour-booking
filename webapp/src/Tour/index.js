import React, { useState } from "react";
import './Tour.css';
import { useNavigate, useParams } from "react-router-dom";
import { useAppParameters } from "../Utils/useAppParameters";

function Tour() {
    const navigate = useNavigate();
    const [ formData, setFormData ] = useState({ name: '', destination: '', email: '', startDate: '', endDate: '',price: '' });
    const [ validation, setValidation ] = useState([]);
    const [ displayValidation, setDisplayValidation ] = useState('none');
    const { id } = useParams();
    const { getApiTourGetUrl, getApiTourPostUrl, getAppTourGridNavigate } = useAppParameters();
    
    // fetch data from API
    const getTourData = (id) => {
        fetch(getApiTourGetUrl(id), {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success');

            if (data.startDate != null) {
                data.startDate = data.startDate.substring(0, 10);
            }

            if (data.endDate != null) {
                data.endDate = data.endDate.substring(0, 10);
            }

            setFormData(data);
        })
        .catch((error) => {
            console.error('Error:', error);
            alert('Error al obtener los datos.');
        });
    }

    React.useEffect(() => {
        if (id > 0) {
            getTourData(id);
        }
    }, [id]);

    const onSubmit = (e) => {
        e.preventDefault();
        console.log(id);
        console.log(formData);

        fetch(getApiTourPostUrl(), {
            method: id > 0 ? 'PUT' : 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                id: id,
                name: formData.name,
                destination: formData.destination,
                startDate: formData.startDate,
                endDate: formData.endDate,
                price: formData.price ? formData.price : 0,
            }),
        })
        .then(response => response.json())
        .then(json => {
            if (json.successful) {
                console.log('Success');
                navigate(getAppTourGridNavigate());
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
        navigate(getAppTourGridNavigate());
    }

    const onChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
    };

    return (
        <div className='Tour'>
            <h2>Tour</h2>
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
                    <label>Nombre</label>
                    <input type="text" name="name" value={formData.name} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Destino</label>
                    <input type="text" name="destination" value={formData.destination} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Inicio</label>
                    <input type="date" name="startDate" value={formData.startDate} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Fin</label>
                    <input type="date" name="endDate" value={formData.endDate} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Price</label>
                    <input type="number" name="price" value={formData.price} onChange={onChange} className="form-control" />
                </div>
                <button type="submit" className="button-primary">Guardar</button>
            </form>
        </div>
    );
}

export { Tour };