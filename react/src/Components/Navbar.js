import React from "react";
import {
  Nav,
  NavItem,
  NavLink,
  
} from "reactstrap";
import { Link } from "react-router-dom";
export default class Navbar extends React.Component {
  render() {
    return (
      <div
        style={{
          textDecoration: "none",
          color: "black",
          border: "1px solid black",
          borderRadius: " 10px",
          margin: "20px",
          padding: "20px",
        }}>
        <h3>
          News Portal <i class="fa-regular fa-newspaper"></i>
        </h3>

        <Nav>
          <NavItem>
            <NavLink
              className="btn "
              style={{
                textDecoration: "none",
                color: "white",
                border: "1px solid black",
                borderRadius: "3px",
                marginRight: "20px",
                padding: "12px",
              }}
              href="#">
              <Link style={{ textDecoration: "none", color: "black" }} to="/">
                All News <i class="fa-solid fa-house"></i>
              </Link>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink
              className="btn "
              style={{
                textDecoration: "none",
                color: "white",
                border: "1px solid black",
                borderRadius: "3px",
                marginRight: "20px",
                padding: "12px",
              }}
              href="#">
              <Link
                style={{ textDecoration: "none", color: "black" }}
                to="/addnews">
              Add News  <i class="fa-solid fa-plus"></i>
              </Link>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink
              className="btn "
              style={{
                textDecoration: "none",
                color: "white",
                border: "1px solid black",
                borderRadius: "3px",
                marginRight: "20px",
                padding: "12px",
              }}
              href="#">
              <Link
                style={{ textDecoration: "none", color: "black" }}
                to="/favnews">
                 Last Populer Fav News <i class="fa-solid fa-light fa-heart"></i>
              </Link>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink
              className="btn "
              style={{
                textDecoration: "none",
                color: "white",
                border: "1px solid black",
                borderRadius: "3px",
                marginRight: "20px",
                padding: "12px",
              }}
              href="#">
              <Link
                style={{ textDecoration: "none", color: "black" }}
                to="/profile">
                Profile <i class="fa-solid fa-user"></i>
              </Link>
            </NavLink>
                </NavItem>
                <form className="d-flex" role="search">
                 <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
        <button className="btn btn-outline-success" type="submit">Search</button>
      </form>
        </Nav>
      </div>
    );
  }
}
