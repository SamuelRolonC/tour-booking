import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { GridTour } from '../GridTour';
import { GridBooking } from '../GridBooking';
import './App.css';
import { Tour } from '../Tour';
import { Booking } from '../Booking';

function AppUI() {

  return (
    <div className='App'>
        <Routes>    
            <Route path='/' element={<GridTour />} />
            <Route path='/Tour' element={<GridTour />} />
            <Route path='/Tour/:id' element={<Tour />} />
            <Route path='/Booking' element={<GridBooking />} />
            <Route path='/Booking/:id' element={<Booking />} />
        </Routes>
    </div>
  );
}

export { AppUI };
