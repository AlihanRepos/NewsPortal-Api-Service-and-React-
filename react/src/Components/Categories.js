import { ListGroupItem, ListGroup, Button } from 'reactstrap';
import { Link } from 'react-router-dom';

export default function Categories({ categories }) {
  return (
    
    <ListGroup>
      <ListGroupItem style={{ backgroundColor: "white" }}>
        <h4>Categories <i class="fa-solid fa-compass"></i></h4>
 

      {categories.map(category => (
        <div><Link
        to={`/categorydetail/${category.newsCategoryId}`}
          style={{ backgroundColor: "white",color:"black",textAlign:"center",textDecoration:"none",fontSize:"20px" }}
          key={category.newsCategoryId}
        >
          {category.category}
        </Link></div>
      ))}
             </ListGroupItem>
    </ListGroup>
  );
}

