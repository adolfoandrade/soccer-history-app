import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { styled } from "@mui/material/styles";
import AppBar from "@mui/material/AppBar";
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
import { TextField, Stack, Autocomplete, Box, Container } from "@mui/material";

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

  const StyledGameScore = {
    display: "flex",
    justifyContent: "center",
    padding: "20px",
    borderBottom: "solid 1px #bdbdbd",
    marginBottom: "1rem"
  };

  const StyledTimeLineCard = {
    border: "solid 1px #bdbdbd",
    borderRadius: "10px",
    maxWidth: "500px",
    margin: "0 auto 1rem auto"
  };


  const { id } = useParams();
  const [soccerEvent, setSoccerEvent] = useState({});

  useEffect(() => {
    fetch(`https://localhost:5001/api/Events/${id}`)
      .then((response) => response.json())
      .then((data) => setSoccerEvent(data));
  }, []);

  return (
    <div>
      <Container>
        <div className="flex-container" style={StyledGameScore}>
          <div><img alt="" src={soccerEvent?.home?.image} /></div>
          <div style={{ fontSize: "2rem", display: "flex", flexDirection: "row", alignItems: "center", width: "300px" }}>
            <div style={{ margin: "0 auto", fontWeight: "600" }}>3</div>
            <div style={{ margin: "0 auto", color: "#757575" }}>x</div>
            <div style={{ margin: "0 auto", fontWeight: "600" }}>1</div>
          </div>
          <div><img alt="" src={soccerEvent?.out?.image} /></div>  
        </div>
      </Container>
      <Container style={{ marginBottom: "300px" }}>
        { soccerEvent?.cards?.map((item) => (
          <div className="time-line-card" style={StyledTimeLineCard}>
              <div className="time-line-card-header" style={{ borderBottom: "solid 1px #bdbdbd", display: "flex", flexDirection: "row", alignItems: "center", padding: "20px", flexWrap: "wrap" }}>
                <div style={{ margin: "0 auto", fontWeight: "600", flexGrow: 1 }}>
                  <img alt="" src="https://ssl.gstatic.com/onebox/sports/game_feed/yellow_card_icon.svg" />
                </div>
                <div style={{ margin: "0 auto", fontWeight: "500", flexGrow: 10 }}>{item?.card?.color} CARD</div>
                <div style={{ margin: "0 auto", fontWeight: "500", color: "#757575", flexGrow: 1 }}>{item?.card?.minute}'</div>
              </div>
              <div style={{ display: "flex", alignItems: "center", }}>
                 <div style={{ margin: "0 auto", fontWeight: "600", flexGrow: 1, padding: "20px" }}>{item?.card.player}</div>
                 <div style={{ margin: "0 auto", fontWeight: "600", flexGrow: 1, padding: "20px" }}>
                   <img alt="" src={item?.soccerTeam?.image} width="56" height="56" style={{ float: "right" }} />
                 </div>
              </div>
          </div>
        ))}
      </Container>
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
