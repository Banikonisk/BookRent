import React, { useEffect, useState } from 'react'
import { ReservationGet } from '../../Models/Reservation';
import { getReservations, postReservation } from '../../Services/ReservationService';
import ReservationList from '../../Components/Reservations/ReservationList';

interface Props {}

const ReservationsPage = (props: Props) => {

    const [reservationValues, setReservationValues] = useState<ReservationGet[]>([]);

    const getReservationsInit = async () => {
        const result = await getReservations();
        setReservationValues(result!.data);
    }

    useEffect(() => {
        getReservationsInit();
      }, []);

    return (
        <ReservationList reservationValues={reservationValues}/>
    )
}

export default ReservationsPage