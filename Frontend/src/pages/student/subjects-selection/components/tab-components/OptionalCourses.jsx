import Ders from "../Course";
import { Data } from "@/data";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import SelectSubjectsTableHeader from "@/components/SelectSubjectsTableHeader";

const OptionalCourses = ({ courses }) => {
  console.log("courses", courses);
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
          Your optional courses are included in the elective courses tab. It is
          not mandatory for graduation, but you must take elective courses to
          complete the credits required for graduation.
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
        {courses.length !== 0 ? (
          courses.map((item, index) => (
            <Ders state="success" key={index} data={item} />
          ))
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

export default OptionalCourses;
