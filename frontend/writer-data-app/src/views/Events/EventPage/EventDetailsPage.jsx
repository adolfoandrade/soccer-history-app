import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { styled } from "@mui/material/styles";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Fab from "@mui/material/Fab";
import MenuIcon from "@mui/icons-material/Menu";
import SearchIcon from "@mui/icons-material/Search";
import MoreIcon from "@mui/icons-material/MoreVert";
import SportsSoccerIcon from "@mui/icons-material/SportsSoccer";
import SportsIcon from "@mui/icons-material/Sports";
import EqualizerIcon from "@mui/icons-material/Equalizer";
import { Box, Container } from "@mui/material";
import Modal from "@mui/material/Modal";

import TimeLineGoalComponent    from "../../../components/events/TimeLineGoalComponent";
import TimeLineCardComponent    from "../../../components/events/TimeLineCardComponent";
import AddGoalComponent         from "../../../components/events/AddGoalComponent";
import AddCardComponent         from "../../../components/events/AddCardComponent";
import StatisticDetailsComponent from "../../../components/events/StatisticDetailsComponent";

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
    marginBottom: "1rem",
  };

  const { id } = useParams();

  const [soccerEvent, setSoccerEvent] = useState({});
  const [statistics, setStatistic] = useState([]);

  const [openGoal, setOpenGoal] = React.useState(false);
  const [openCard, setOpenCard] = React.useState(false);

  const handleOpenCard = () => setOpenCard(true);
  const handleCloseAddCard = () => setOpenCard(false);
  const handleOpenGoal = () => setOpenGoal(true);
  const handleCloseAddGoal = () => setOpenGoal(false);

  useEffect(() => {
    function getEvents() {
      fetch(`https://soccer-app-api.azurewebsites.net/api/Events/${id}`)
        .then((response) => response.json())
        .then((data) => {
          setSoccerEvent(data);
          setStatistic(data.statistics);
        });
    }
    getEvents();
  }, [id]);

  return (
    <div>
      <Modal
        open={openCard}
        onClose={handleCloseAddCard}
        aria-labelledby="modal-modal-card"
        aria-describedby="modal-modal-add-cards"
      >
        <AddCardComponent item={soccerEvent} />
      </Modal>

      <Modal
        open={openGoal}
        onClose={handleCloseAddGoal}
        aria-labelledby="modal-modal-goal"
        aria-describedby="modal-modal-add-goals"
      >
        <AddGoalComponent item={soccerEvent} />
      </Modal>

      <Container key="game-score-header">
        <div className="flex-container" style={StyledGameScore}>
          <div>
            <img alt="" src={soccerEvent?.home?.image} />
          </div>
          <div
            style={{
              fontSize: "2rem",
              display: "flex",
              flexDirection: "row",
              alignItems: "center",
              width: "300px",
            }}
          >
            <div style={{ margin: "0 auto", fontWeight: "600" }}>
              {soccerEvent?.home?.goals}
            </div>
            <div style={{ margin: "0 auto", color: "#757575", textAlign: "center" }}>
              <p style={{ fontSize: "12px", padding: "0", margin: "0", fontWeight: 500 }}>{soccerEvent.date}</p>
              <p style={{ padding: "0", margin: "0", textAlign: "center" }}>x</p>
              <p style={{ fontSize: "12px", padding: "0", margin: "0", fontWeight: 500 }}>ROUND 2</p>
            </div>
            <div style={{ margin: "0 auto", fontWeight: "600" }}>
              {soccerEvent?.out?.goals}
            </div>
          </div>
          <div>
            <img alt="" src={soccerEvent?.out?.image} />
          </div>
        </div>
      </Container>
      <Container>
        <StatisticDetailsComponent item={{ 
          theEvent: soccerEvent, 
          homeFullStatistic: statistics?.filter(x => x.half === "FULL").find(x => x.soccerTeam.id === soccerEvent.home.id), 
          awayFullStatistic: statistics?.filter(x => x.half === "FULL").find(x => x.soccerTeam.id === soccerEvent.out.id),
          title: "TEAM STATS"
          }} />
      </Container>
      <Container>
        <StatisticDetailsComponent item={{ 
          theEvent: soccerEvent, 
          homeFullStatistic: statistics?.filter(x => x.half === "FIRST_HALF").find(x => x.soccerTeam.id === soccerEvent.home.id), 
          awayFullStatistic: statistics?.filter(x => x.half === "FIRST_HALF").find(x => x.soccerTeam.id === soccerEvent.out.id),
          title: "1 HALF TEAM STATS"
          }} />
      </Container>
      <Container>
        <StatisticDetailsComponent item={{ 
          theEvent: soccerEvent, 
          homeFullStatistic: statistics?.filter(x => x.half === "SECOND_HALF").find(x => x.soccerTeam.id === soccerEvent.home.id), 
          awayFullStatistic: statistics?.filter(x => x.half === "SECOND_HALF").find(x => x.soccerTeam.id === soccerEvent.out.id),
          title: "2 HALF TEAM STATS"
          }} />
      </Container>
      <Container style={{ marginBottom: "300px" }} key="game-time-line">
        {soccerEvent?.timeLine?.map((item) => (
          (item?.item?.type === "CARD") ?
            <TimeLineCardComponent item={item} />
            :
            <TimeLineGoalComponent item={item} />
        ))}
      </Container>
      <AppBar position="fixed" color="primary" sx={{ top: "auto", bottom: 0, background: '#212121' }}>
        <Toolbar>
          <IconButton color="inherit" aria-label="open drawer">
            <MenuIcon />
          </IconButton>
          <StyledFabAddGoal
            color="#616161"
            aria-label="add"
            onClick={handleOpenGoal}
          >
            <SportsSoccerIcon />
          </StyledFabAddGoal>
          <StyledFabAddCard
            color="#616161"
            aria-label="add"
            onClick={handleOpenCard}
          >
            <SportsIcon />
          </StyledFabAddCard>
          <Link
            to={`/statistic/common/add/${id}`}
          >
            <StyledFabAddStatistic
              color="#616161"
              aria-label="add"

            >
              <EqualizerIcon />
            </StyledFabAddStatistic>
          </Link>
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
