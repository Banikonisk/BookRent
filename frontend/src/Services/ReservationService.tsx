import axios from "axios";
import { ReservationGet, ReservationPost } from "../Models/Reservation";

const api = "http://localhost:5034/api/reservation/";

export const getReservations = async () => {
    try {
      const data = await axios.get<ReservationGet[]>(api);
      return data;
    } 
    catch (error: any) {
        console.log("Error message: ", error.message);
    }
};

export const postReservation = async (
    typeAudio: boolean,
    quickPickUp: boolean,
    days: number,
    bookId: number
) => {
    try {
      const data = await axios.post<ReservationPost[]>(api + `${bookId}`, {
        typeAudio: typeAudio,
        quickPickUp: quickPickUp,
        days: days
      });
      return data;
    }
    catch (error: any) {
        console.log("Error message: ", error.message);
    }
};