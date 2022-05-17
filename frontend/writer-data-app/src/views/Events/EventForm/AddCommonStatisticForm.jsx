import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { TextField, Stack, Container } from "@mui/material";
import { Formik, Form } from "formik";
import LoadingButton from "@mui/lab/LoadingButton";
import SaveIcon from "@mui/icons-material/Save";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";

function AddCommonStatisticComponent(props) {

    const { id } = useParams();
    const [loading, setLoading] = React.useState(false);
    const [soccerEvent, setSoccerEvent] = useState({});

    useEffect(() => {
        fetch(`https://soccer-app-api.azurewebsites.net/api/Events/${id}`)
            .then((response) => response.json())
            .then((data) => setSoccerEvent(data));
    }, []);

    return (
        <>
            <Container maxWidth="sm">
                <Formik
                    initialValues={{
                        ballPossession: 0,
                        goalAttempts: 0,
                        shotsOnGoal: 0,
                        shotsOffGoal: 0,
                        blockedShots: 0,
                        cornerKicks: 0,
                        freeKicks: 0,
                        offsides: 0,
                        throwin: 0,
                        goalkeeperSaves: 0,
                        fouls: 0,
                        yellowCards: 0,
                        redCards: 0,
                        totalPasses: 0,
                        completedPasses: 0,
                        trackles: 0,
                        attacks: 0,
                        dangerousAttacks: 0,
                        half: "",
                        soccerTeamId: "",
                        eventId: id,
                    }}
                    onSubmit={async (values) => {
                        console.log(values);
                        fetch("https://soccer-app-api.azurewebsites.net/api/Statistics/common", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json",
                            },
                            body: JSON.stringify(values),
                        }).then((res) => {
                            if (res.created) {

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
                                        onChange={(e, value) => {
                                            setFieldValue("half", e.target.value);
                                        }}
                                    >
                                        <MenuItem value="FIRST_HALF">1º HALF</MenuItem>
                                        <MenuItem value="SECOND_HALF">2º HALF</MenuItem>
                                    </Select>
                                </FormControl>

                                <TextField
                                    id="ballPossession"
                                    label="Ball Possession"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("ballPossession", e.target.value)
                                    }
                                />

                                <TextField
                                    id="goalAttempts"
                                    label="Goal Attempts"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("goalAttempts", e.target.value)
                                    }
                                />

                                <TextField
                                    id="shotsOnGoal"
                                    label="Shots On Goal"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("shotsOnGoal", e.target.value)
                                    }
                                />

                                <TextField
                                    id="shotsOffGoal"
                                    label="Shots Off Goal"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("shotsOffGoal", e.target.value)
                                    }
                                />

                                <TextField
                                    id="blockedShots"
                                    label="Blocked Shots"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("blockedShots", e.target.value)
                                    }
                                />

                                <TextField
                                    id="freeKicks"
                                    label="Free Kicks"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("freeKicks", e.target.value)
                                    }
                                />

                                <TextField
                                    id="cornerKicks"
                                    label="Corner Kicks"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("cornerKicks", e.target.value)
                                    }
                                />

                                <TextField
                                    id="offsides"
                                    label="Offsides"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("offsides", e.target.value)
                                    }
                                />

                                <TextField
                                    id="throwin"
                                    label="Throwin"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("throwin", e.target.value)
                                    }
                                />

                                <TextField
                                    id="goalkeeperSaves"
                                    label="Goalkeeper Saves"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("goalkeeperSaves", e.target.value)
                                    }
                                />

                                <TextField
                                    id="fouls"
                                    label="Fouls"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("fouls", e.target.value)
                                    }
                                />

                                <TextField
                                    id="yellowCards"
                                    label="Yellow Cards"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("yellowCards", e.target.value)
                                    }
                                />

                                <TextField
                                    id="redCards"
                                    label="Red Cards"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("redCards", e.target.value)
                                    }
                                />

                                <TextField
                                    id="totalPasses"
                                    label="Total Passes"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("totalPasses", e.target.value)
                                    }
                                />

                                <TextField
                                    id="completedPasses"
                                    label="Completed Passes"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("completedPasses", e.target.value)
                                    }
                                />

                                <TextField
                                    id="trackles"
                                    label="Trackles"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("trackles", e.target.value)
                                    }
                                />

                                <TextField
                                    id="attacks"
                                    label="Attacks"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("attacks", e.target.value)
                                    }
                                />

                                <TextField
                                    id="dangerousAttacks"
                                    label="Dangerous Attacks"
                                    variant="outlined"
                                    onChange={(e, value) =>
                                        setFieldValue("dangerousAttacks", e.target.value)
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
            </Container>
        </>
    );
}

export default AddCommonStatisticComponent;