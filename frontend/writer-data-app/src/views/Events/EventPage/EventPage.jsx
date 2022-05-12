import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { Container } from '@mui/material';

function EventPage() {
  const [events, setEvents] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    fetch(`https://localhost:5001/api/Events/seasoning/${id}/2022`)
      .then((response) => response.json())
      .then((data) => setEvents(data));
  }, []);

  return (
    <Container maxWidth="sm">
      {events?.matches?.map((item) => (
        item?.events?.map((theEvent) => (
          <>
            <div style={{ borderTopLeftRadius: "12px", borderTopRightRadius: "12px", color: "#fff", display: "flex", justifyContent: "space-between", padding: "10px", backgroundColor: theEvent.home.colorTheme }}>
              <div>{theEvent.home.name}</div>
              <div>0 (0)</div>
            </div>
            <div style={{ borderBottomLeftRadius: "12px", borderBottomRightRadius: "12px", color: "#fff", display: "flex", justifyContent: "space-between", marginBottom: "10px", padding: "10px", backgroundColor: theEvent.out.colorTheme }}>
              <div>{theEvent.out.name}</div>
              <div>0 (0)</div>
            </div>
          </>
        ))
      ))}
    </Container>
  );
}

export default EventPage;