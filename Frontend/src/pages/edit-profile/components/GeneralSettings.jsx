import axios from "axios";

import { useState } from "react";

import { useSelector, useDispatch } from "react-redux";

import TextField from "@mui/material/TextField";
import InputAdornment from "@mui/material/InputAdornment";
import LocalPhoneIcon from "@mui/icons-material/LocalPhone";
import CircularProgress from "@mui/material/CircularProgress";
import { Box, Snackbar, Alert, Avatar, Button } from "@mui/material";

import { setUserData } from "@/store/user/user.action";
import { selectUserData } from "@/store/user/user.selector";

import { ROLE_TYPES } from "@/utils/constants";
import { getToken } from "@/utils/helper-functions";

import avatar2 from "@/assets/avatar2.png";

const GeneralSettings = () => {
  const currentUser = useSelector(selectUserData);
  const { role, personalMail, phone, schoolMail } = currentUser;

  const token = getToken();
  const dispatch = useDispatch();

  const [error, setError] = useState(false);
  const [success, setSuccess] = useState(false);
  const [loading, setLoading] = useState(false);
  const [newData, setNewData] = useState({
    email: personalMail,
    phoneNr: phone,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setNewData({
      ...newData,
      [name]: value,
    });
  };

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setSuccess(false);
    setError(false);
  };

  const isAdvisor = role === ROLE_TYPES.ADVISOR;
  const isStudent = role === ROLE_TYPES.STUDENT;
  const isLecturer = role === ROLE_TYPES.LECTURER;
  const isAdministrator = role === ROLE_TYPES.ADMINISTRATOR;

  const apiLink = isStudent
    ? "/api/User/Student/Account/Details"
    : isLecturer
    ? "/api/User/Lecturer/Account/Details"
    : isAdministrator
    ? "/api/User/Administrator/Account/Details"
    : isAdvisor
    ? "/api/User/Advisor/Account/Details"
    : null;

  const handleSubmit = async () => {
    try {
      setLoading(true);
      const response = await axios.put(
        `http://localhost:5158${apiLink}`,
        {
          phone: newData.phoneNr,
          personalMail: newData.email,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      setSuccess(true);
      dispatch(setUserData(response.data));
      localStorage.setItem("userData", JSON.stringify(response.data));
    } catch (error) {
      setError(true);
    }
    setLoading(false);
  };
  return (
    <Box
      sx={{
        marginTop: "40px",
      }}
    >
      <Snackbar open={success} autoHideDuration={6000} onClose={handleClose}>
        <Alert
          onClose={handleClose}
          severity="success"
          variant="filled"
          sx={{ width: "100%", color: "white" }}
        >
          Changes saved successfully!
        </Alert>
      </Snackbar>
      <Snackbar open={error} autoHideDuration={6000} onClose={handleClose}>
        <Alert
          onClose={handleClose}
          severity="error"
          variant="filled"
          sx={{ width: "100%", color: "white" }}
        >
          An error occurred. Please try again later.
        </Alert>
      </Snackbar>
      <Box sx={{ display: "flex", alignItems: "center" }}>
        <Avatar
          src={avatar2}
          sx={{ width: "80px", height: "80px", marginRight: "20px" }}
        />
        <Button sx={{ height: "40px" }} variant="caption1">
          CHANGE
        </Button>
      </Box>

      <form>
        <Box
          sx={{
            marginTop: "40px",
            display: "flex",
            flexDirection: "column",
          }}
        >
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Kurumsal e-posta"
            type="email"
            value={schoolMail}
            disabled
          />{" "}
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            onChange={handleChange}
            label="Kişisel e-posta"
            value={newData.email}
            name="email"
            type="email"
          />{" "}
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              startAdornment: (
                <InputAdornment position="start">
                  <LocalPhoneIcon />
                </InputAdornment>
              ),
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Cep Telefonu"
            onChange={handleChange}
            value={newData.phoneNr}
            name="phoneNr"
            type="text"
          />{" "}
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Ikamet Adresi"
            type="text"
          />
          <Button
            sx={{
              width: "20%",
              margin: "20px 0",
              borderRadius: "10px",
            }}
            color="primary"
            size="large"
            onClick={handleSubmit}
            variant="contained"
          >
            {loading ? (
              <CircularProgress color="inherit" size={24} />
            ) : (
              "Save Changes"
            )}
          </Button>
        </Box>
      </form>
    </Box>
  );
};

export default GeneralSettings;
