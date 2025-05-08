import Ders from "../Course";
import { Data } from "@/data";

import { useTheme } from "@mui/material/styles";
import { Box, Typography } from "@mui/material";

import SelectSubjectsTableHeader from "@/components/SelectSubjectsTableHeader";

const MandatoryCourses = ({ courses }) => {
  const theme = useTheme();
  const { required, failed } = courses;
  console.log("required", required);
  console.log("failed", failed);
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
          Under the mandatory courses tab, there are courses that are included
          in your semester or that you have experienced in previous semesters.
          (If the previous all-region course was held in the semester you are
          currently enrolled in, it will be automatically registered and you
          cannot remove that course.) These are compulsory courses to be
          completed in order to graduate.
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
        {failed
          ? failed.map((item, index) => (
              <Ders state="failed" key={index} data={item} />
            ))
          : null}
        {required ? (
          required.map((item, index) => (
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

export default MandatoryCourses;
