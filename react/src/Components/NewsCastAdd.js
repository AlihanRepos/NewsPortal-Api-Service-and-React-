import React, { useState ,useEffect} from "react";
import { Form, Button, Container } from 'react-bootstrap';




const NewsCastForm = () => {


  const [source, setSource] = useState([]);
  const [category, setCategory] = useState([]);


  useEffect(() => {
    fetchNews();
  }, []);

  
  useEffect(() => {
    fetchNewsCategory();
  }, []);
  
  const fetchNews = async () => {
    try {
      const response = await fetch('https://localhost:7223/news/Source/GetSource');
      const data = await response.json();
      setSource(data);
    } catch (error) {
      console.error(error);
    }
  };
  const fetchNewsCategory = async () => {
    try {
      const response = await fetch('https://localhost:7223/newscast/News/GetCategory');
      const data = await response.json();
      setCategory(data);
    } catch (error) {
      console.error(error);
    }
  };




  const [formData, setFormData] = useState({
    Title: "",
    Text: "",
    MultimediaUrl: "",
    NewsDate: new Date().toISOString().slice(0, 10),
    IsActive: true,
    NewsSourceId: 1,
    NewsCategoryId: 1,
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    // JSON verisini oluştur
    const jsonData = JSON.stringify(formData);

    // Sunucuya HTTP isteği gönder
    fetch("https://localhost:7223/newscast/News", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: jsonData,
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        // Başarılı işlem durumunda yapılabilecekler
      })
      .catch((error) => {
        console.error("Hata mesajı:", error);
        // Hata durumunda yapılabilecekler
      });
  };

  return (
    <Container>
  <Form onSubmit={handleSubmit}>
    <Form.Group controlId="formTitle">
      <Form.Label>Title:</Form.Label>
      <Form.Control
        type="text"
        name="Title"
        value={formData.Title}
        onChange={handleChange}
        required
      />
    </Form.Group>

    <Form.Group controlId="formText">
      <Form.Label>Text:</Form.Label>
      <Form.Control
        as="textarea"
        name="Text"
        value={formData.Text}
        onChange={handleChange}
        required
      />
    </Form.Group>

    <Form.Group controlId="formMultimediaUrl">
      <Form.Label>Multimedia URL:</Form.Label>
      <Form.Control
        type="text"
        name="MultimediaUrl"
        value={formData.MultimediaUrl}
        onChange={handleChange}
      />
    </Form.Group>

    <Form.Group controlId="formNewsDate">
      <Form.Label>News Date:</Form.Label>
      <Form.Control
        type="date"
        name="NewsDate"
        value={formData.NewsDate}
        onChange={handleChange}
      />
    </Form.Group>

 

    <Form.Group controlId="formNewsSourceId">
      <Form.Label> Source </Form.Label>
      <Form.Control
        as="select"
        name="NewsSourceId"
        value={formData.NewsSourceId}
        onChange={handleChange}
        required
          >
             {source.map((item, index) => (

<option value={item.newsSourceId}>{ item.corpationName}</option>


))}
      </Form.Control>
    </Form.Group>
    <Form.Group controlId="formNewsCategoryId">
  <Form.Label>Category</Form.Label>
  <Form.Control
    as="select"
    name="NewsCategoryId"
    value={formData.NewsCategoryId}
    onChange={handleChange}
    required
          >
            {category.map((item, index) => (

              <option value={item.NewsCategoryId}>{ item.category}</option>

              
            ))}
   
   
  </Form.Control>
</Form.Group>


    <Button type="submit">Add NewsCast</Button>
  </Form>
</Container>

  );
};

export default NewsCastForm;
