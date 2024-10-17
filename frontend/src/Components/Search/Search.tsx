import React, { ChangeEvent, useState, SyntheticEvent } from 'react'

interface Props {
  onSearchSubmit: (e: SyntheticEvent) => void;
  search: string | undefined;
  handleSearchChange: (e: ChangeEvent<HTMLInputElement>) => void;
  placeholder: string;
};

const Search: React.FC<Props> = ( {onSearchSubmit, search, handleSearchChange, placeholder}: Props): JSX.Element  => {
  return (
    <>
      <form onSubmit={onSearchSubmit} className="flex items-center space-x-2">
        <input value={search} onChange={handleSearchChange} placeholder={placeholder} 
        className="px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-darkBlue focus:border-transparent"/>
      </form>
    </>
  );
};

export default Search