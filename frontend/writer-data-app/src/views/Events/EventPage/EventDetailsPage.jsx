import * as React from "react";
import { styled } from "@mui/material/styles";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import Paper from "@mui/material/Paper";
import Fab from "@mui/material/Fab";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import ListItemText from "@mui/material/ListItemText";
import ListSubheader from "@mui/material/ListSubheader";
import Avatar from "@mui/material/Avatar";
import MenuIcon from "@mui/icons-material/Menu";
import AddIcon from "@mui/icons-material/Add";
import SearchIcon from "@mui/icons-material/Search";
import MoreIcon from "@mui/icons-material/MoreVert";
import SportsSoccerIcon from '@mui/icons-material/SportsSoccer';
import SportsIcon from '@mui/icons-material/Sports';
import EqualizerIcon from '@mui/icons-material/Equalizer';

function EventDetailsPage() {
  const StyledFabAddGoal = styled(Fab)({
    position: "absolute",
    zIndex: 1,
    top: -30,
    left: -120,
    right: 0,
    margin: "0 auto",
  });

  const StyledFabAddCard = styled(Fab)({
    position: "absolute",
    zIndex: 1,
    top: -30,
    left: 0,
    right: 0,
    margin: "0 auto",
  });

  const StyledFabAddStatistic = styled(Fab)({
    position: "absolute",
    zIndex: 1,
    top: -30,
    left: 120,
    right: 0,
    margin: "0 auto",
  });

  return (
    <div>
      <AppBar position="fixed" color="primary" sx={{ top: "auto", bottom: 0 }}>
        <Toolbar>
          <IconButton color="inherit" aria-label="open drawer">
            <MenuIcon />
          </IconButton>
          <StyledFabAddGoal color="secondary" aria-label="add">
            <SportsSoccerIcon />
          </StyledFabAddGoal>
          <StyledFabAddCard color="secondary" aria-label="add">
            <SportsIcon />
          </StyledFabAddCard>
          <StyledFabAddStatistic color="secondary" aria-label="add">
            <EqualizerIcon />
          </StyledFabAddStatistic>
          <Box sx={{ flexGrow: 1 }} />
          <IconButton color="inherit">
            <SearchIcon />
          </IconButton>
          <IconButton color="inherit">
            <MoreIcon />
          </IconButton>
        </Toolbar>
      </AppBar>
    </div>
  );
}

export default EventDetailsPage;
