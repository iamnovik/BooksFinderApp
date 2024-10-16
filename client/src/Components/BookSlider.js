import React from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import "./BookSlide.css"
const BookSlider = ({ books }) => {
  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 1,
  };

  return (
    <div>
      <h2>Books</h2>
      <Slider {...settings}>
        {books.map((book, index) => (
          <div key={index} className="book-slide" >
            {book.pictureUrl && <img src={book.pictureUrl} alt={book.title} />}
            <h3>{book.title}</h3>
            <p>Author: {book.author}</p>
            <p>Published Date: {book.publishedDate}</p>
            <a href={book.infoLink} target="_blank" rel="noopener noreferrer">
              More Info
            </a>
          </div>
        ))}
      </Slider>
    </div>
  );
};

export default BookSlider;
