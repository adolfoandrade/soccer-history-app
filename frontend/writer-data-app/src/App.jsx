import './App.css';

import React, { Fragment, useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import { TextField, Stack, Autocomplete, Box, Container } from '@mui/material';
import LoadingButton from '@mui/lab/LoadingButton';
import SaveIcon from '@mui/icons-material/Save';

function App() {
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
            match: {
              number: '',
              competitionId: ''
            },
            homeTeamId: '',
            outTeamId: '',
          }}
          onSubmit={async (values) => {
            await new Promise((r) => setTimeout(r, 500));
            alert(JSON.stringify(values, null, 2));
          }}
        >
          <Form>
            <Stack spacing={2} sx={{ width: '100%' }}>
              <Autocomplete
                id="competition"
                name="match.competitionId"
                getOptionLabel={(option) => option.name}
                options={competitions}
                onChange={(e, value) => setHomeTeam(value.id)}
                sx={{ width: '100%' }}
                renderInput={(params) => <TextField {...params} label="Competition" />}
              />

              <TextField id="match-number" label="Match Number" variant="outlined" />

              <Autocomplete
                id="home-team"
                name="homeTeamId"
                getOptionLabel={(option) => option.name}
                options={soccerTeams}
                onChange={(e, value) => setHomeTeam(value.id)}
                sx={{ width: '100%' }}
                renderInput={(params) => <TextField {...params} label="Home Team" />}
              />

              <Autocomplete
                id="out-team"
                name="outTeamId"
                getOptionLabel={(option) => option.name}
                options={soccerTeams}
                sx={{ width: '100%' }}
                onChange={(e, value) => setOutTeam(value.id)}
                renderInput={(params) => <TextField {...params} label="Out Team" />}
              />

              <TextField
                id="datetime-event"
                label="Event date"
                type="datetime-local"
                defaultValue="2022-01-01T10:30"
                sx={{ width: '100%' }}
                InputLabelProps={{
                  shrink: true,
                }}
              />

              <TextField id="referee" label="Referee" variant="outlined" />

              <TextField id="venue" label="Venue" variant="outlined" />

              <LoadingButton
                loading={loading}
                loadingPosition="start"
                startIcon={<SaveIcon />}
                variant="outlined"
                type='submit'
              >
                Save
              </LoadingButton>
            </Stack>
          </Form>
        </Formik>
      </Container>
  );
}

export default App;


