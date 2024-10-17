import React, { SyntheticEvent } from 'react';
import Card from '../Card/Card';
import { Book } from '../../Models/Book';
import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: Book[];
}

const CardList: React.FC<Props> = ({searchResults}: Props): JSX.Element => {
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6 p-4">
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return <Card id={result.id} key={uuidv4()} searchResult={result}/>;
        })
      ) : (
        <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
          No results!
        </p>
      )}
    </div>
  )
}

export default CardList