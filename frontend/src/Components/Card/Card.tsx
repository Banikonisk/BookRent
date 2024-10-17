import React, { SyntheticEvent } from 'react'
import "./Card.css"
import { Book } from '../../Models/Book';
import { Link } from 'react-router-dom';

interface Props {
  id: number;
  searchResult: Book;
}

const Card: React.FC<Props> = ({id, searchResult}: Props): JSX.Element => {
  return (
    <div className="w-72 h-80 mx-auto bg-white shadow-lg rounded-lg overflow-hidden transition-transform transform hover:scale-105 flex flex-col">
        <Link to={`/book/${id}`} className="flex-grow">
          <img
              src={searchResult.imageUrl}
              alt="Book image"
              className="w-full h-48 object-cover"
          />
          <div className="p-4 flex-grow" >
              <h2 className="text-lg font-semibold text-gray-800">{searchResult.name}</h2>
              <p className="text-gray-600">{searchResult.year}</p>
          </div>
        </Link>
    </div>
  );
}

export default Card