import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router'
import { Book } from '../../Models/Book';
import { getBook } from '../../Services/BookService';
import AddReservation from '../../Components/Reservations/AddReservation';
import { postReservation } from '../../Services/ReservationService';
import Checkbox from '../../Components/Checkbox/Checkbox';

interface Props {}

const BookPage = (props: Props) => {
  let { id } = useParams();
  const [book, setBook] = useState<Book>();
  const [typeAudio, setTypeAudio] = useState<boolean>(false);
  const [quickPickUp, setQuickPickUp] = useState<boolean>(false);
  const [days, setDays] = useState<number>(1);
  const navigate = useNavigate();

  useEffect(() => {
    const getBookInit = async () => {
      const result = await getBook(id!);
      setBook(result?.data);
    }
    getBookInit();
  }, [])

  const navigateToReservations = () => {
    navigate("/reservations");
  }

  const handleTypeAudioChange = (checked: boolean) => {
    setTypeAudio(checked);
  };

  const handleQuickPickUpChange = (checked: boolean) => {
    setQuickPickUp(checked);
  };

  const handleDaysChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const result = parseInt(e.target.value, 10);
    if(result >= 1){
      setDays(result);
    }
  }

  const onReservationCreate = async (e: any) => {
    e.preventDefault();
    console.log(e.target[0].value);
    await postReservation(typeAudio, quickPickUp, days, e.target[0].value);
    navigateToReservations();
  }

  return (
    <>
      {book ? (
        <div className="flex flex-col md:flex-row items-center justify-center p-6 space-x-6">
          <div className="flex-1">
            <h2 className="text-2xl font-bold mb-2">{book.name}</h2>
            <p className="text-lg text-gray-700 mb-4">{book.year}</p>
            <p className="text-lg text-gray-700 mb-4">Book ID: {book.id}</p>
            <Checkbox isChecked={typeAudio}
              onCheckboxChange={handleTypeAudioChange}
              label="Check for Audio type book" />
            <div className="mt-2">
              <Checkbox isChecked={quickPickUp}
                onCheckboxChange={handleQuickPickUpChange}
                label="Check for quick pick up" />
            </div>
            <label className="block mt-4">
              Enter a number of days
              <input
                type="number"
                value={days}
                onChange={handleDaysChange}
                min="1"
                className="ml-2 border border-gray-300 rounded-md p-1"
              />
            </label>
            <AddReservation onReservationCreate={onReservationCreate} id={id!} />
          </div>
          <div className="flex justify-center">
            <img
              src={book.imageUrl}
              alt="Book image"
              className="max-w-[500px] max-h-[500px] w-full h-auto object-cover rounded-lg shadow-md"
            />
          </div>
        </div>
      ) : (
        <h2 className="text-xl text-red-500">Book not found!</h2>
      )}
    </>
  )
}

export default BookPage