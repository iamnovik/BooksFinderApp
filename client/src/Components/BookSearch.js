import React, { useState } from "react";
import axios from "axios";
import BookSlider from "./BookSlider";

const BookSearch = () => {
  const [query, setQuery] = useState("");
  const [books, setBooks] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const API_BASE_URL='http://localhost:5067/api/books/search';

  const handleSearch = async () => {
    setLoading(true);
    setError("");
    try {
      const response = await axios.get(`${API_BASE_URL}?query=${query}`);
      console.log(response.data)
      setBooks(response.data);
    } catch (err) {
      setError("An error occurred while fetching data.");
    }
    setLoading(false);
  };

  return (
    <div className="book-search">
      <h1>Book Finder</h1>
      <input
        type="text"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        placeholder="Search for books by title, author, etc."
      />
      <button onClick={handleSearch}>Search</button>

      {loading && <p>Loading...</p>}
      {error && <p>{error}</p>}
      {books.length > 0 && <BookSlider books={books} />}
    </div>
  );
};

export default BookSearch;
