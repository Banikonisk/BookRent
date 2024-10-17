export type ReservationGet = {
    id: number;
    typeAudio: boolean;
    quickPickUp: boolean;
    days: number;
    cost: number;
    bookId: number;
};

export type ReservationPost = {
    typeAudio: boolean;
    quickPickUp: boolean;
    days: number;
    bookId: number;
};