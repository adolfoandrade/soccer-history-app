import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Container } from '@mui/material';
import Grid from '@mui/material/Grid';
import { styled } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import CssBaseline from '@mui/material/CssBaseline';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import Paper from '@mui/material/Paper';
import Fab from '@mui/material/Fab';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ListItemText from '@mui/material/ListItemText';
import ListSubheader from '@mui/material/ListSubheader';
import Avatar from '@mui/material/Avatar';
import MenuIcon from '@mui/icons-material/Menu';
import AddIcon from '@mui/icons-material/Add';
import SearchIcon from '@mui/icons-material/Search';
import MoreIcon from '@mui/icons-material/MoreVert';

import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';

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
      <Container maxWidth="sm">
        <ul style={{ listStyleType: 'none' }}>
          {competitions.map((item) => (
            <li key={item.image} style={{ margin: "0 auto", display: "inline-block", padding: "20px" }}>
                <Link to="/events">
                <img style={{ border: "#ccc 1px solid", borderRadius: "5px" }}
                    src={`${item.image}?w=248&fit=crop&auto=format`}
                    srcSet={`${item.image}?w=248&fit=crop&auto=format&dpr=2 2x`}
                    alt={item.title}
                    loading="lazy"
                />
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