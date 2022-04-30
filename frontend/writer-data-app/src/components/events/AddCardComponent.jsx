import React, { useEffect, useState } from "react";
import { TextField, Stack, Box } from "@mui/material";
import { Formik, Form } from "formik";
import LoadingButton from "@mui/lab/LoadingButton";
import SaveIcon from "@mui/icons-material/Save";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";

function AddCardComponent(props) {
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

    const [loading, setLoading] = React.useState(false);

    return (
        <Box sx={style}>
            <Formik
                initialValues={{
                    player: "",
                    minute: "",
                    color: "",
                    half: "",
                    soccerTeamId: "",
                    eventId: props.item?.id,
                }}
                onSubmit={async (values) => {
                    console.log(values);
                    fetch("https://localhost:5001/api/Statistics/cards", {
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
                                    <MenuItem value={props.item?.home?.id}>
                                        {props.item?.home?.name}
                                    </MenuItem>
                                    <MenuItem value={props.item?.out?.id}>
                                        {props.item?.out?.name}
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

                            <FormControl fullWidth>
                                <InputLabel id="color">Color</InputLabel>
                                <Select
                                    labelId="color"
                                    id="color"
                                    label="Color"
                                    onChange={(e, value) => {
                                        setFieldValue("color", e.target.value);
                                    }}
                                >
                                    <MenuItem value="YELLOW">YELLOW</MenuItem>
                                    <MenuItem value="RED">RED</MenuItem>
                                </Select>
                            </FormControl>

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
    );
}

export default AddCardComponent;