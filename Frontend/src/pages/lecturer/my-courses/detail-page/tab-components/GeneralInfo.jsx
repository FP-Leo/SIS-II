import { useTheme } from "@mui/material/styles";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { selectUserToken } from "@/store/user/user.selector";
import { Box, Typography } from "@mui/material";

const GeneralInfo = () => {
  const token = useSelector(selectUserToken);
  const params = useParams();
  const theme = useTheme();
  const [data, setData] = useState([]);

  console.log(data);

  return (
    <Box
      sx={{
        backgroundColor: theme.palette.common.white,
        boxShadow: theme.customShadows.z4,
        borderRadius: "10px",
        paddingY: 2,
        height: "200px",
        display: "grid",
        gridTemplateColumns: "1fr 4fr",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          gridColumn: "1/3",
          marginLeft: 3,
        }}
      >
        <Typography variant="subtitle1">General Information</Typography>
      </Box>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "flex-end",
        }}
      >
        <Typography variant="caption">Course Code:</Typography>
        <Typography variant="caption">AKTS:</Typography>
        <Typography variant="caption">Credits:</Typography>
        <Typography variant="caption">Year:</Typography>
        <Typography variant="caption">Semester:</Typography>
        <Typography variant="caption">Students Number:</Typography>
      </Box>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "flex-start",
          marginLeft: 1.5,
        }}
      >
        <Typography variant="caption2">BML-2001</Typography>
        <Typography variant="caption2">5</Typography>
        <Typography variant="caption2">4</Typography>
        <Typography variant="caption2">2024</Typography>
        <Typography variant="caption2">Spring</Typography>
        <Typography variant="caption2">148</Typography>
      </Box>
    </Box>
  );
};
export default GeneralInfo;
