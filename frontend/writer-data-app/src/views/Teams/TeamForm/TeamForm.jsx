import React, { useEffect, useState } from "react";
import { Formik, Form } from "formik";
import { useParams } from "react-router-dom";
import { TextField, Stack, Autocomplete, Box, Container } from "@mui/material";
import LoadingButton from "@mui/lab/LoadingButton";
import SaveIcon from "@mui/icons-material/Save";
import { Link } from "react-router-dom";
import Grid from '@mui/material/Grid';
import { styled } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
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
import DeleteIcon from '@mui/icons-material/Delete';
import SearchIcon from '@mui/icons-material/Search';
import MoreIcon from '@mui/icons-material/MoreVert';
import PhotoCamera from '@mui/icons-material/PhotoCamera';
import Button from '@mui/material/Button';

const Input = styled('input')({
  display: 'none',
});

const StyledFab = styled(Fab)({
  position: 'absolute',
  zIndex: 1,
  top: -30,
  left: 0,
  right: 0,
  margin: '0 auto',
});

function TeamForm() {
  const [soccerTeam, setSoccerTeam] = useState([]);
  const [soccerImage, setImage] = useState("");
  const [loading, setLoading] = React.useState(false);
  const { id } = useParams();

  function onFileChangeHandler(e) {
    e.preventDefault();
    const formData = new FormData();
    formData.append('files', e.target.files[0]);
    var file = e.target.files[0];
    fetch('https://soccer-app-api.azurewebsites.net/api/SoccerTeams/UploadFile', {
      method: 'post',
      body: formData
    }).then(res => {
      if (res.ok) {
        setImage(`https://soccer.blob.core.windows.net/teams/${file.name}`);
        alert("File uploaded successfully.")
      }
    });
  };

  useEffect(() => {
    if (id !== "0") {
      fetch(`https://soccer-app-api.azurewebsites.net/api/SoccerTeams/${id}`)
        .then((response) => response.json())
        .then((data) => setSoccerTeam(data));
    }
  }, []);

  return (
    <>
      <Container maxWidth="sm">
        <Formik
          initialValues={{
            image: soccerImage,
            name: "",
            country: ""
          }}
          onSubmit={async (values) => {
            //alert(JSON.stringify(values, null, 2));
            console.log(values);
            fetch('https://soccer-app-api.azurewebsites.net/api/SoccerTeams', {
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

                <label htmlFor="contained-button-file">
                  <Input accept="image/*" id="contained-button-file" multiple type="file" onChange={(e) => onFileChangeHandler(e)} />
                  <Button variant="contained" component="span">
                    Upload Image
                  </Button>
                </label>

                <TextField
                  id="name"
                  label="Name"
                  variant="outlined"
                  onChange={(e, value) => { 
                    setFieldValue("name", e.target.value) 
                    setFieldValue("image", soccerImage) 
                  }}
                />

                <TextField
                  id="country"
                  label="Country"
                  variant="outlined"
                  onChange={(e, value) => setFieldValue("country", e.target.value)}
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
      <AppBar position="fixed" color="primary" sx={{ top: 'auto', bottom: 0 }}>
        <Toolbar>
          <IconButton color="inherit" aria-label="open drawer">
            <MenuIcon />
          </IconButton>
          <StyledFab component={Link} to="/soccer/team/form/0" color="secondary" aria-label="add">
            <DeleteIcon />
          </StyledFab>
          <Box sx={{ flexGrow: 1 }} />
        </Toolbar>
      </AppBar>
    </>
  );
}

export default TeamForm;