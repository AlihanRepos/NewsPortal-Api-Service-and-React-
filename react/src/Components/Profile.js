import React, { useState, useEffect } from 'react';

function Profile() {
  const [profile, setProfile] = useState([]);

  useEffect(() => {
    fetchNews();
  }, []);

  const fetchNews = async () => {
    try {
      const response = await fetch('https://localhost:7223/profile/User/GetProfile');
      const data = await response.json();
      setProfile(data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h3>Profile</h3>
     
      
        <div className="card" style={{ width: '100%' }}>
          <img src={profile.imageUrl} className="card-img-top" alt="News Image" style={{ width: '20%' }} />
          <div className="card-body">
            <h5 className="card-title">Name: {profile.name}</h5>
            <h5 className="card-text">Surname: {profile.surname}</h5>
            <p className="card-text">Email: {profile.email}</p>
            <p className="card-text">Age: {profile.age}</p>
          </div>
        </div>
      
    </div>
  );
}

export default Profile;
