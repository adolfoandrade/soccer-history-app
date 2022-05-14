import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { Container } from '@mui/material';
import { styled } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Fab from '@mui/material/Fab';
import MenuIcon from '@mui/icons-material/Menu';
import AddIcon from '@mui/icons-material/Add';

import EventListItemComponent from "../../../components/events/EventListItemComponent";

const StyledFab = styled(Fab)({
  position: 'absolute',
  zIndex: 1,
  top: -30,
  left: 0,
  right: 0,
  margin: '0 auto',
});

const StyledEventPageHeader = {
  color: "#212121",
  backgroundColor: "#f5f5f5",
  textAlign: "center",
  padding: "10px",
  fontWeight: "500",
  marginBottom: "20px"
};

function EventPage() {
  const [events, setEvents] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    fetch(`https://soccer-app-api.azurewebsites.net/api/Events/seasoning/${id}/2022`)
      .then((response) => response.json())
      .then((data) => setEvents(data));
  }, [id]);

  return (
    <>
      <Container maxWidth="lg" style={{ marginBottom: "200px" }}>
        <div style={StyledEventPageHeader}>
          <img alt="" src={`${events.season?.image}`} />
          <p>{events.season?.name}</p>
          <p>{events.season?.year}</p>
          <p>{events.season?.country}</p>
        </div>
        {events?.matches?.map((item) => (
          <EventListItemComponent key={item.match.number} item={item} />
        ))}
      </Container>

      <AppBar position="fixed" color="primary" sx={{ top: 'auto', bottom: 0 }}>
        <Toolbar>
          <IconButton color="inherit" aria-label="open drawer">
            <MenuIcon />
          </IconButton>
          <StyledFab component={Link} to="/soccer/team/form/0" color="secondary" aria-label="add">
            <AddIcon />
          </StyledFab>
          <Box sx={{ flexGrow: 1 }} />
        </Toolbar>
      </AppBar>
    </>
  );
}

export default EventPage;