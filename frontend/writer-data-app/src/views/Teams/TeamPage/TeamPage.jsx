import React, { useEffect, useState } from "react";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import Checkbox from '@mui/material/Checkbox';
import Avatar from '@mui/material/Avatar';

function TeamPage() {

    const [teams, setTeams] = useState([]);

    useEffect(() => {
        fetch("https://localhost:5001/api/SoccerTeams")
          .then((response) => response.json())
          .then((data) => setTeams(data));
      }, []);

    return (
        <List dense sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
          {teams.map((value) => {
            const labelId = `checkbox-list-secondary-label-${value}`;
            return (
              <ListItem
                key={value}
                disablePadding
              >
                <ListItemButton>
                  <ListItemAvatar>
                    <Avatar
                      alt={`${value.name}`}
                      src={`/static/images/avatar/${value.name}.jpg`}
                    />
                  </ListItemAvatar>
                  <ListItemText id={labelId} primary={`${value.name}`} />
                </ListItemButton>
              </ListItem>
            );
          })}
        </List>
      );
}

export default TeamPage;