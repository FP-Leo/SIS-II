import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

const WeekContents = () => {
  const theme = useTheme();

  return (
    <Box
      sx={{
        backgroundColor: theme.palette.common.white,
        boxShadow: theme.customShadows.z4,
        borderRadius: 1,
        display: "flex",
        flexDirection: "column",
        marginBottom: 3,
      }}
    >
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
        }}
      >
        <Box
          sx={{
            paddingLeft: 3,
            width: "100%",
            height: "50px",
            display: "flex",
            alignItems: "center",
            borderBottom: `1px solid ${theme.palette.divider}`,
          }}
        >
          <Typography variant="subtitle2">Course Contents</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            p: 3,
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Typography color="error" variant="caption">
            No course contents has been added yet.
          </Typography>
        </Box>
      </Box>
    </Box>
  );
};

export default WeekContents;
