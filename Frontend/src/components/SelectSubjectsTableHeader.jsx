import { Box, Typography } from "@mui/material";

const SelectSubjectsTableHeader = () => {
  return (
    <Box
      sx={{
        width: "100%",
        height: "50px",
        backgroundColor: "#E9E9EA",
        display: "grid",
        gridTemplateColumns: "1fr 2fr 5fr 1fr 4fr 2fr ",
      }}
    >
      <Typography
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        Select
      </Typography>
      <Typography
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        Course Code
      </Typography>
      <Typography
        variant="subtitle2"
        sx={{
          marginLeft: "20px",
          display: "flex",
          justifyContent: "flex-start",
          alignItems: "center",
        }}
      >
        Name
      </Typography>
      <Typography
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        AKTS
      </Typography>
      <Typography
        variant="subtitle2"
        sx={{
          marginLeft: "20px",
          display: "flex",
          justifyContent: "flex-start",
          alignItems: "center",
        }}
      >
        Class
      </Typography>
      <Typography
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        Description
      </Typography>
    </Box>
  );
};

export default SelectSubjectsTableHeader;
