import ReservationCard from './ReservationCard';
import { ReservationGet } from '../../Models/Reservation';
import { v4 as uuidv4 } from "uuid";

interface Props {
    reservationValues: ReservationGet[];
}

const ReservationList = ({reservationValues}: Props) => {
    return (
        <div className="p-6">
            <h3 className="text-2xl font-bold mb-4">My Reservations</h3>
            <ul className="space-y-4">
            {reservationValues &&
                reservationValues.map((reservationValue) => (
                <ReservationCard key={uuidv4()} reservationValue={reservationValue} />
                ))}
            </ul>
        </div>
    );
};

export default ReservationList