import { useParams } from 'react-router-dom';
import React, { useState, useEffect } from "react";
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';


export default function NewsDetails() {
  const { newcastid } = useParams();
  const [news, setNews] = useState({});
  //----------------------------------------------------------------
  const [formData, setFormData] = useState({
    Comment: "",
    CommentDate: new Date().toISOString().slice(0, 10),
    IsActive: true,
    UserId:1,
    NewsCastId: newcastid,

  });
  console.log(newcastid)

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };
  const handleSubmit = () => {

    window.location.reload()

    // JSON verisini oluştur
    const jsonData = JSON.stringify(formData);

    // Sunucuya HTTP isteği gönder
    fetch("https://localhost:7223/api/comment", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: jsonData,
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      })
      .catch((error) => {
        console.error("Hata mesajı:", error);
      });
  };


  //----------------------------------------------------------------
  
  
 

  useEffect(() => {
    if (newcastid) {
      fetchNews();
    }
  }, [newcastid]);

  const fetchNews = async () => {
    try {
      const response = await fetch(`https://localhost:7223/newscast/News/details/${newcastid}`);
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
      
      
      {news.length > 0 && (
  <div className="card" style={{ width: '100%' }}>
          {news.map((item, index) => (
            <div className='col-12'  >
          
  <div >
    {item.multimediaUrl && <img src={item.multimediaUrl} className="card-img-top" alt="News Image"  style={{ width: '100%' }} />}
    <div className="card-body">
      <h5 className="card-title">{item.title}</h5>
                  <p className="card-text">{item.text}</p>
                  <p className="card-text"> Category <b>{item.category}</b> </p>
      <p className="card-text">Corparation <b> {item.corpationName}</b></p>
                  <hr />
                  <h5>Comments</h5>
                  <p>
                    {item.comments.length > 0 && (
                      <div>
                        {item.comments.map((comment, commentIndex) => (
            <div key={commentIndex}>
              <p className="card-text"> <b>{comment.userName}</b>  {comment.comment}</p>
              </div>
                        
                          
          ))}
                        
                        
                      </div>
                    )
                      
                     }
                  </p>                     

    </div>
  </div>
            </div>))}
           
          
     

  </div>
      )}
      <Form onSubmit={handleSubmit}>
   <FormGroup controlId="formText">
    <Label>Comment:</Label>
    <Input
      type="textarea"
      name="Comment"
      value={formData.Comment}
      onChange={handleChange}
      required
    />
  </FormGroup>
  <Button type="submit">Add Comment</Button>
    </Form>

    
    
    
   
    </div>
    
    


    
  );
}
