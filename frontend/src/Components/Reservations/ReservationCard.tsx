import React from 'react'
import { ReservationGet } from '../../Models/Reservation';

interface Props {
    reservationValue: ReservationGet;
}

const ReservationCard = ({reservationValue}: Props) => {
    return (
    <div className="border rounded-lg p-4 shadow-md bg-white">
        <h4 className="text-xl font-semibold mb-2">Reservation of Book ID - {reservationValue.bookId}</h4>
        <p className="text-gray-700">Audio: {reservationValue.typeAudio.toString()}</p>
        <p className="text-gray-700">Quick Pick Up: {reservationValue.quickPickUp.toString()}</p>
        <p className="text-gray-700">Days: {reservationValue.days}</p>
        <p className="text-gray-700">Cost: {reservationValue.cost.toFixed(2)} €</p>
    </div>
    );
};

export default ReservationCard