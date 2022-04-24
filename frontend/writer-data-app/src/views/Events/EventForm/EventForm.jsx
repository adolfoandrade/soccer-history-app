import React, { useEffect, useState } from "react";
import { Formik, Form } from "formik";
import { TextField, Stack, Autocomplete, Box, Container } from "@mui/material";
import LoadingButton from "@mui/lab/LoadingButton";
import SaveIcon from "@mui/icons-material/Save";

function EventForm() {
  const [loading, setLoading] = React.useState(false);

  const [soccerTeams, setSoccerTeams] = useState([]);
  const [homeTeam, setHomeTeam] = useState();
  const [outTeam, setOutTeam] = useState();

  const [competitions, setCompetitions] = useState([]);

  useEffect(() => {
    fetch("https://localhost:5001/api/SoccerTeams")
      .then((response) => response.json())
      .then((data) => setSoccerTeams(data));

    fetch("https://localhost:5001/api/Competitions/2022")
      .then((response) => response.json())
      .then((data) => setCompetitions(data));
  }, []);

  return (
    <Container maxWidth="sm">
      <Formik
        initialValues={{
          competitionId: "",
          matchNumber: "",
          homeTeamId: "",
          outTeamId: "",
          date: "",
          referee: "",
          venue: ""
        }}
        onSubmit={async (values) => {
          console.log(values);
          fetch('https://localhost:5001/api/Events', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(values)
          }).then(res => {
            console.log(res);
            if (res.created) {
              console.log(res);
              alert("File uploaded successfully.")
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
              <Autocomplete
                id="competition"
                name="competitionId"
                getOptionLabel={(option) => option.name}
                options={competitions}
                onChange={(e, value) =>
                  setFieldValue("competitionId", value.id)
                }
                sx={{ width: "100%" }}
                renderInput={(params) => (
                  <TextField {...params} label="Competition" />
                )}
              />

              <TextField
                id="match-number"
                label="Match Number"
                variant="outlined"
                onChange={(e, value) => setFieldValue("matchNumber", e.target.value)}
              />

              <Autocomplete
                id="home-team"
                name="homeTeamId"
                getOptionLabel={(option) => option.name}
                options={soccerTeams}
                onChange={(e, value) => setFieldValue("homeTeamId", value.id)}
                sx={{ width: "100%" }}
                renderOption={(props, option) => (
                  <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
                    <img
                      loading="lazy"
                      width="20"
                      src={`${option.image}`}
                      srcSet={`${option.image} 2x`}
                      alt=""
                    />
                    {option.name}
                  </Box>
                )}
                renderInput={(params) => (
                  <TextField {...params} label="Home Team" />
                )}
              />

              <Autocomplete
                id="out-team"
                name="outTeamId"
                getOptionLabel={(option) => option.name}
                options={soccerTeams}
                sx={{ width: "100%" }}
                onChange={(e, value) => setFieldValue("outTeamId", value.id)}
                renderOption={(props, option) => (
                  <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
                    <img
                      loading="lazy"
                      width="20"
                      src={`${option.image}`}
                      srcSet={`${option.image} 2x`}
                      alt=""
                    />
                    {option.name}
                  </Box>
                )}
                renderInput={(params) => (
                  <TextField {...params} label="Out Team" />
                )}
              />

              <TextField
                id="datetime-event"
                label="Event date"
                type="datetime-local"
                defaultValue="2022-01-01T10:30"
                onChange={(e, value) => setFieldValue("date", e.target.value)}
                sx={{ width: "100%" }}
                InputLabelProps={{
                  shrink: true,
                }}
              />

              <TextField
                id="referee"
                label="Referee"
                variant="outlined"
                onChange={(e, value) => setFieldValue("referee", e.target.value)}
              />

              <TextField
                id="venue"
                label="Venue"
                variant="outlined"
                onChange={(e, value) => setFieldValue("venue", e.target.value)}
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
    </Container>
  );
}

export default EventForm;
