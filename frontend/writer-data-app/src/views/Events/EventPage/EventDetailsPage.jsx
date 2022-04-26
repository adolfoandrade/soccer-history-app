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
import SportsSoccerIcon from "@mui/icons-material/SportsSoccer";
import SportsIcon from "@mui/icons-material/Sports";
import EqualizerIcon from "@mui/icons-material/Equalizer";
import { TextField, Stack, Autocomplete, Box, Container } from "@mui/material";
import Modal from "@mui/material/Modal";
import { Formik, Form } from "formik";
import LoadingButton from "@mui/lab/LoadingButton";
import SaveIcon from "@mui/icons-material/Save";
import FormControl from "@mui/material/FormControl";
import Select, { SelectChangeEvent } from "@mui/material/Select";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  border: "1px solid #bdbdbd",
  boxShadow: 24,
  p: 4,
};

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

  const StyledTimeLineCard = {
    border: "solid 1px #bdbdbd",
    borderRadius: "10px",
    maxWidth: "500px",
    margin: "0 auto 1rem auto",
  };

  const { id } = useParams();
  const [loading, setLoading] = React.useState(false);
  const [soccerEvent, setSoccerEvent] = useState({});
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  useEffect(() => {
    fetch(`https://localhost:5001/api/Events/${id}`)
      .then((response) => response.json())
      .then((data) => setSoccerEvent(data));
  }, []);

  return (
    <div>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Formik
            initialValues={{
              player: "",
              minute: "",
              assist: null,
              half: "",
              soccerTeamId: "",
              eventId: soccerEvent.id,
            }}
            onSubmit={async (values) => {
              console.log(values);
              fetch("https://localhost:5001/api/Statistics/goals", {
                method: "POST",
                headers: {
                  "Content-Type": "application/json",
                },
                body: JSON.stringify(values),
              }).then((res) => {
                console.log(res);
                if (res.created) {
                  console.log(res);
                  alert("File uploaded successfully.");
                }
              });
            }}
          >
            {({
              values,
              errors,
              touched,
              handleChange,
              setFieldValue,
              handleSubmit,
              isSubmitting,
            }) => (
              <Form>
                <Stack spacing={2} sx={{ width: "100%" }}>
                  <FormControl fullWidth>
                    <InputLabel id="demo-simple-select-label">Team</InputLabel>
                    <Select
                      labelId="demo-simple-select-label"
                      id="demo-simple-select"
                      label="Soccer Team"
                      onChange={(e, value) =>
                        setFieldValue("soccerTeamId", e.target.value)
                      }
                    >
                      <MenuItem value={soccerEvent?.home?.id}>
                        {soccerEvent?.home?.name}
                      </MenuItem>
                      <MenuItem value={soccerEvent?.out?.id}>
                        {soccerEvent?.out?.name}
                      </MenuItem>
                    </Select>
                  </FormControl>

                  <FormControl fullWidth>
                    <InputLabel id="half">Period</InputLabel>
                    <Select
                      labelId="half"
                      id="half"
                      label="Period"
                      onChange={(e, value) =>
                        setFieldValue("half", e.target.value)
                      }
                    >
                      <MenuItem value="FIRST_HALF">1º HALF</MenuItem>
                      <MenuItem value="SECOND_HALF">2º HALF</MenuItem>
                    </Select>
                  </FormControl>

                  <TextField
                    id="player"
                    label="Player"
                    variant="outlined"
                    onChange={(e, value) =>
                      setFieldValue("player", e.target.value)
                    }
                  />

                  <TextField
                    id="minute"
                    label="Minute"
                    variant="outlined"
                    onChange={(e, value) =>
                      setFieldValue("minute", e.target.value)
                    }
                  />

                  <TextField
                    id="assist"
                    label="Assist"
                    variant="outlined"
                    onChange={(e, value) =>
                      setFieldValue("assist", e.target.value)
                    }
                  />

                  <LoadingButton
                    loading={loading}
                    loadingPosition="start"
                    startIcon={<SaveIcon />}
                    variant="outlined"
                    type="submit"
                  >
                    Save
                  </LoadingButton>
                </Stack>
              </Form>
            )}
          </Formik>
        </Box>
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
            <div style={{ margin: "0 auto", color: "#757575" }}>x</div>
            <div style={{ margin: "0 auto", fontWeight: "600" }}>
              {soccerEvent?.out?.goals}
            </div>
          </div>
          <div>
            <img alt="" src={soccerEvent?.out?.image} />
          </div>
        </div>
      </Container>
      <Container style={{ marginBottom: "300px" }} key="game-time-line">
        {soccerEvent?.cards?.map((item) => (
          <div className="time-line-card" style={StyledTimeLineCard}>
            <div
              className="time-line-card-header"
              style={{
                borderBottom: "solid 1px #bdbdbd",
                display: "flex",
                flexDirection: "row",
                alignItems: "center",
                padding: "20px",
                flexWrap: "wrap",
              }}
            >
              <div style={{ margin: "0 auto", fontWeight: "600", flexGrow: 1 }}>
                <img
                  alt=""
                  src="https://ssl.gstatic.com/onebox/sports/game_feed/yellow_card_icon.svg"
                />
              </div>
              <div
                style={{ margin: "0 auto", fontWeight: "500", flexGrow: 10 }}
              >
                {item?.card?.color} CARD
              </div>
              <div
                style={{
                  margin: "0 auto",
                  fontWeight: "500",
                  color: "#757575",
                  flexGrow: 1,
                }}
              >
                {item?.card?.minute}'
              </div>
            </div>
            <div style={{ display: "flex", alignItems: "center" }}>
              <div
                style={{
                  margin: "0 auto",
                  fontWeight: "600",
                  flexGrow: 1,
                  padding: "20px",
                }}
              >
                {item?.card.player}
              </div>
              <div
                style={{
                  margin: "0 auto",
                  fontWeight: "600",
                  flexGrow: 1,
                  padding: "20px",
                }}
              >
                <img
                  alt=""
                  src={item?.soccerTeam?.image}
                  width="56"
                  height="56"
                  style={{ float: "right" }}
                />
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
          <StyledFabAddGoal
            color="secondary"
            aria-label="add"
            onClick={handleOpen}
          >
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
