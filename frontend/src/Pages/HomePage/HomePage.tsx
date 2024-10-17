import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from 'react'
import { Book } from '../../Models/Book';
import { getBooks, searchBooksByName, searchBooksByYear } from '../../Services/BookService';
import Search from '../../Components/Search/Search';
import CardList from '../../Components/CardList/CardList';

interface Props {}

const HomePage = (props: Props) => {

  const [search, setSearch] = useState<string>("");
  const [searchYears, setSearchYears] = useState<string>("");
  const [searchResult, setSearchResult] = useState<Book[]>([]);

  const getBooksInit = async () => {
    const result = await getBooks();
    setSearchResult(result!.data);
  }

  useEffect(() => {
    getBooksInit();
  }, []);

    const handleSearchNameChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    };

    const handleSearchYearChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearchYears(e.target.value);
    };

    const onSearchNameSubmit = async (e: SyntheticEvent) => {
      e.preventDefault();
      const result = await searchBooksByName(search);

      if (typeof search === "string") {
        setSearchResult(result!.data);
      }
    };

    const onSearchYearSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const result = await searchBooksByYear(searchYears);
  
        if (typeof searchYears === "string") {
          setSearchResult(result!.data);
        }
      };

  return <>
    <div className="flex flex-col items-center p-4">
      <div className="mb-4 w-full max-w-md">
        <Search 
          onSearchSubmit={onSearchNameSubmit} 
          search={search} 
          handleSearchChange={handleSearchNameChange} 
          placeholder="Search by name" 
        />
      </div>
      <div className="mb-4 w-full max-w-md">
        <Search 
          onSearchSubmit={onSearchYearSubmit} 
          search={searchYears} 
          handleSearchChange={handleSearchYearChange} 
          placeholder="Search by year" 
        />
      </div>
      <CardList searchResults={searchResult} />
    </div>
  </>
}

export default HomePage