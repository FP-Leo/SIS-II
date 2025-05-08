import { useTheme } from "@mui/material/styles";
import { Avatar, Box, Typography } from "@mui/material";

const StudentInfo = () => {
  const theme = useTheme();

  return (
    <Box
      sx={{
        width: "70%",
        backgroundColor: theme.palette.common.white,
        boxShadow: theme.customShadows.z4,
        borderRadius: "5px",
        margin: 2,
      }}
    >
      <Box
        sx={{
          height: "40px",
          backgroundColor: theme.palette.grey[300],
          display: "flex",
          alignItems: "center",
          borderRadius: "5px 5px 0 0",
          paddingX: 2,
        }}
      >
        {" "}
        <Typography variant="caption">Students Information</Typography>
      </Box>
      <Box
        sx={{
          display: "grid",
          paddingY: 4,
          gridTemplateColumns: "1.3fr 1fr 1.5fr 0.7fr",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
          }}
        >
          <Avatar
            sx={{
              margin: 3,
            }}
          />
          <Box sx={{ display: "flex", flexDirection: "column" }}>
            <Typography variant="caption">Name Surname:</Typography>
            <Typography variant="caption">Student No:</Typography>
            <Typography variant="caption">ID No:</Typography>
          </Box>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <Typography variant="caption">Year:</Typography>
          <Typography variant="caption">Semester:</Typography>
          <Typography variant="caption">Max AKTS:</Typography>
          <Typography variant="caption">Min AKTS:</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <Typography variant="caption">Registration Year:</Typography>
          <Typography variant="caption">Registration Semester:</Typography>
          <Typography variant="caption">Registration Year Semester:</Typography>
          <Typography variant="caption">State:</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <Typography variant="caption">GNO:</Typography>
          <Typography variant="caption">YANO:</Typography>
        </Box>
      </Box>
    </Box>
  );
};

export default StudentInfo;
