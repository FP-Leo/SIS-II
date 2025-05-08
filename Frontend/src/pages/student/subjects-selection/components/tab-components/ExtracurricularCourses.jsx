import Ders from "../Course";
import { Data } from "@/data";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import SelectSubjectsTableHeader from "@/components/SelectSubjectsTableHeader";

const ExtracurricularCourses = ({ courses }) => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          minWidth: "95%",
          marginY: "20px",
          height: "auto",
          maxWidth: "95%",
          borderRadius: "10px",
          display: "flex",
          backgroundColor: theme.palette.info.light,
          padding: "10px",
        }}
      >
        <Typography
          sx={{
            textAlign: "center",
          }}
          variant="caption2"
          color="info.darker"
        >
          The selected courses panel on the left is automatically filled with
          mandatory courses that you have previously taken but failed to pass.
          You can select and add the courses you want to take on top of these
          courses according to your ECTS/AKTS from the courses in the tables
          above.
        </Typography>
      </Box>
      <SelectSubjectsTableHeader />
      <Box
        sx={{
          backgroundColor: "background.neutral",
          width: "100%",
          display: "flex",
          flexDirection: "column",
        }}
      >
        {courses ? (
          courses.map((item) => <Ders data={item} />)
        ) : (
          <Typography
            padding={3}
            color="error"
            textAlign="center"
            variant="subtitle2"
          >
            No courses found!
          </Typography>
        )}
      </Box>
    </Box>
  );
};

export default ExtracurricularCourses;
