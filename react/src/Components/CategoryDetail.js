import { useParams } from 'react-router-dom';
import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';

export default function CategoryDetail() {
  const { newcastid } = useParams();
  const [news, setNews] = useState([]);

  useEffect(() => {
    if (newcastid) {
      fetchNews();
    }
  }, [newcastid]);

  const fetchNews = async () => {
    try {
      const response = await fetch(`https://localhost:7223/newscast/News/category/${newcastid}`);
      if (response.ok) {
        const data = await response.json();
        setNews(data);
      } else {
        throw new Error("Failed to fetch news details");
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h3>News</h3>
      <div className='container-fluid'>
        <div className='row'>
          {news.map((item, index) => (
            <div className='col-6' key={index}>
              <div className="card" style={{ width: '100%' }}>
                {item.multimediaUrl && <img src={item.multimediaUrl} className="card-img-top" alt="News Image" style={{ width: '100%' }} />}
                <div className="card-body">
                  <h5 className="card-title">{item.title}</h5>
                  <p className="card-text">{item.text.slice(0, 500)}...</p>
                  <p className="card-text">Category <b>{item.category}</b></p>
                  <p className="card-text">Corporation <b>{item.corpationName}</b></p>
                  <hr />
                  <Link to={`/details/${item.newsCastId}`} className="btn btn-primary">Go Detail</Link>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
