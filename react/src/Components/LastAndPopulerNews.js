import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';


function LastAndPopulerNews() {
  const [news, setNews] = useState([]);

  useEffect(() => {
    fetchNews();
  }, []);

  const fetchNews = async () => {
    try {
      const response = await fetch('https://localhost:7223/newscast/News/GetMainOrderFavs');
      const data = await response.json();
      setNews(data);
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
            <div className='col-6'  >
          
  <div key={index} className="card"  style={{ width: '100%' }}>
    {item.multimediaUrl && <img src={item.multimediaUrl} className="card-img-top" alt="News Image"  style={{ width: '100%' }} />}
    <div className="card-body">
      <h5 className="card-title">{item.title}</h5>
      <p className="card-text">{item.text.slice(0,500)}...</p>
      <p className="card-text"> Category <b>{item.category}</b> </p>
      <p className="card-text">Corparation <b> {item.corpationName}</b></p>
     
      <hr />
       <Link to={`/details/${item.newsCastId}`} className="btn btn-primary">Go Detail</Link>
             

    </div>
  </div>
  </div>))}
        
        </div>
      </div>
 

    </div>
  );
}

export default LastAndPopulerNews;
