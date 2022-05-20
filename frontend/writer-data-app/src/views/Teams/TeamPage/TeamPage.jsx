import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Container } from '@mui/material';
import Fab from '@mui/material/Fab';
import AddIcon from '@mui/icons-material/Add';

import { styled, alpha } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import InputBase from '@mui/material/InputBase';
import MenuIcon from '@mui/icons-material/Menu';
import SearchIcon from '@mui/icons-material/Search';

const StyledFab = styled(Fab)({
  position: 'absolute',
  zIndex: 1,
  top: -30,
  left: 0,
  right: 0,
  margin: '0 auto'
});

const Search = styled('div')(({ theme }) => ({
  position: 'relative',
  borderRadius: '12px',
  border: '1px solid #212121',
  marginTop: '0.5rem',
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  '&:hover': {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginLeft: 0,
  width: '100%',
  [theme.breakpoints.up('sm')]: {
    marginLeft: theme.spacing(1),
    width: 'auto',
  },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: '100%',
  position: 'absolute',
  pointerEvents: 'none',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: 'inherit',
  '& .MuiInputBase-input': {
    padding: theme.spacing(1, 1, 1, 0),
    // vertical padding + font size from searchIcon
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create('width'),
    width: '100%',
    [theme.breakpoints.up('sm')]: {
      width: '12ch',
      '&:focus': {
        width: '20ch',
      },
    },
  },
}));

function TeamPage() {
  
  const [teams, setTeams] = useState([]);

  useEffect(() => {
    fetch("https://soccer-app-api.azurewebsites.net/api/SoccerTeams")
      .then((response) => response.json())
      .then((data) => setTeams(data));
  }, []);

  return (
    <>
      <Container maxWidth="lg" style={{ marginBottom: '100px' }}>
      <Search>
          <SearchIconWrapper>
            <SearchIcon />
          </SearchIconWrapper>
          <StyledInputBase
            placeholder="Search…"
            inputProps={{ 'aria-label': 'search' }}
          />
        </Search>

        <ul style={{ listStyleType: 'none' }}>
          {teams.map((item) => (
            <li key={item.image} style={{ 
              margin: "0 auto", 
              display: "inline-block", 
              padding: "20px", 
              textAlign: "center", 
               }}>
                <Link to={`/events/${item.id}`} style={{ textDecoration: 'none' }}>
                  <img style={{ width: '96px' }}
                      src={`${item.image}?w=124&fit=crop&auto=format`}
                      srcSet={`${item.image}?w=124&fit=crop&auto=format&dpr=2 2x`}
                      alt={item.title}
                      loading="lazy"
                  />
                  <p style={{ color: "#212121", textTransform: 'uppercase', fontWeight: '500', margin: '0', fontSize: '8px' }}>{item.name}</p>
                </Link>
            </li>
          ))}
        </ul>
      </Container>

      <AppBar position="fixed" color="primary" sx={{ top: 'auto', bottom: 0, background: '#212121' }}>
        <Toolbar>
          <IconButton color="inherit" aria-label="open drawer">
            <MenuIcon />
          </IconButton>
          <StyledFab component={Link} to="/soccer/team/form/0" color="#212121" aria-label="add">
            <AddIcon />
          </StyledFab>
          <Box sx={{ flexGrow: 1 }} />
          <IconButton color="inherit">
            <SearchIcon />
          </IconButton>
        </Toolbar>
      </AppBar>
    </>
  );
}

export default TeamPage;