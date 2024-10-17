import { Book } from "../Models/Book";
import axios from "axios";


const api = "http://localhost:5034/api/book/";

export const getBooks = async () => {
    try {
      const data = await axios.get<Book[]>(api);
      return data;
    } 
    catch (error: any) {
        console.log("Error message: ", error.message);
    }
};

export const getBook = async (id: string) => {
  try {
    const data = await axios.get<Book>(api + `${id}`);
    return data;
  } 
  catch (error: any) {
      console.log("Error message: ", error.message);
  }
};

export const searchBooksByName = async (query: string) => {
    try {
      const data = await axios.get<Book[]>(api + `?Name=${query}`);
      return data;
    } 
    catch (error: any) {
        console.log("Error message: ", error.message);
    }
};

export const searchBooksByYear = async (query: string) => {
  try {
    const data = await axios.get<Book[]>(api + `?Year=${query}`);
    return data;
  } 
  catch (error: any) {
      console.log("Error message: ", error.message);
  }
};