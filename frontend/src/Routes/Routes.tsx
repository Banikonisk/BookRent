import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import BookPage from "../Pages/BookPage/BookPage";
import ReservationsPage from "../Pages/ReservationsPage/ReservationsPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {path: "", element: <HomePage />},
            {path: "book/:id", element: <BookPage />},
            {path: "reservations", element: <ReservationsPage />}
        ]
    }
])