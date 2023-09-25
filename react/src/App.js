import Navbar from "./Components/Navbar";
import NewsDetails from "./Components/NewsDetails";
import NewsCastForm from "./Components/NewsCastAdd";
import Profile from "./Components/Profile";

import News from "./Components/NewsMainAll";
import { Route, Routes } from 'react-router-dom'
import Categories from "./Components/Categories";
import LastAndPopulerNews from "./Components/LastAndPopulerNews";
import React, { useState, useEffect } from 'react';
import CategoryDetail from "./Components/CategoryDetail";


function App() {

  const [category, setcategory] = useState([]);

  useEffect(() => {
    fetchcategory();
  }, []);

  const fetchcategory = async () => {
    try {
      const response = await fetch('https://localhost:7223/newscast/News/GetCategory');
      const data = await response.json();
      setcategory(data);
    } catch (error) {
      console.error(error);
    }
    };
  return (
    <div className="App">
      <Navbar />
      <div className="container-fluid">
        <div className="row">
          <div className="col-2">
            <Categories  categories={category} />

          </div>
          <div className="col-10">
            <Routes>
              <Route path="/" element={<News />} />
              <Route path="/favnews" element={<LastAndPopulerNews />} />
              <Route path="/addnews" element={<NewsCastForm />} />
              <Route path="/profile" element={<Profile />} />
             <Route path="/details/:newcastid"  element={<NewsDetails />} />
             <Route path="/categorydetail/:newcastid"  element={<CategoryDetail />} />
              
              

             
            </Routes>
          </div>

        </div>
      </div>
    </div>
  );
}

export default App;
