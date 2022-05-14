import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Container } from '@mui/material';
import { styled } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Fab from '@mui/material/Fab';
import MenuIcon from '@mui/icons-material/Menu';
import AddIcon from '@mui/icons-material/Add';

const StyledFab = styled(Fab)({
  position: 'absolute',
  zIndex: 1,
  top: -30,
  left: 0,
  right: 0,
  margin: '0 auto',
});

function TournamentPage() {
  
  const [competitions, setCompetition] = useState([]);

  useEffect(() => {
    fetch("https://soccer-app-api.azurewebsites.net/api/Competitions/2022")
      .then((response) => response.json())
      .then((data) => setCompetition(data));
  }, []);

  return (
    <>
      <Container maxWidth="lg">
        <ul style={{ listStyleType: 'none' }}>
          {competitions.map((item) => (
            <li key={item.image} style={{ margin: "0 auto", display: "inline-block", padding: "20px", textAlign: "center" }}>
                <Link to={`/events/${item.id}`}>
                <img style={{  }}
                    src={`${item.image}?w=248&fit=crop&auto=format`}
                    srcSet={`${item.image}?w=248&fit=crop&auto=format&dpr=2 2x`}
                    alt={item.title}
                    loading="lazy"
                />
                <p>{item.name}</p>
                </Link>
            </li>
          ))}
        </ul>
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

export default TournamentPage;