import axios from "axios";

import { useEffect, useState } from "react";

import { Box, Button, CircularProgress } from "@mui/material";

import { useSelector } from "react-redux";
import { selectProgram } from "@/store/program/program.selector";

import SubjectsTable from "./SubjectsTable";
import { selectUserToken } from "@/store/user/user.selector";

import { useStudentSubjects } from "@/hooks/useStudentSubjects";

const Subjects = () => {
  const program = useSelector(selectProgram);
  const token = useSelector(selectUserToken);
  const [open, setOpen] = useState(false);
  const { getStudentSubjects } = useStudentSubjects();
  const { data: subjects, isLoading: loading } = getStudentSubjects;

  const result = Object.groupBy(subjects, ({ schoolYear }) => schoolYear);

  Object.keys(result).forEach((year) => {
    const subjectsForYear = result[year];
    let firstSemester = [];
    let secondSemester = [];
    subjectsForYear.forEach((subject) => {
      if (subject.semester % 2 === 1) {
        firstSemester.push(subject);
      } else {
        secondSemester.push(subject);
      }
    });
    result[year] = {
      firstSemester,
      secondSemester,
    };
  });

  return (
    <Box
      sx={{
        width: "100%",
        height: "auto",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      {loading ? (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "200px",
          }}
        >
          <CircularProgress />
        </Box>
      ) : (
        <>
          {Object.keys(result)?.map((year, index) => {
            const subjectsForYear = result[year];
            if (index === 0 || open) {
              return (
                <>
                  <SubjectsTable
                    key={`${year}-2`}
                    subjects={subjectsForYear.secondSemester}
                    getSemester={{
                      year: year,
                      semester: "Spring",
                    }}
                  />
                  <SubjectsTable
                    key={`${year}-1`}
                    subjects={subjectsForYear.firstSemester}
                    getSemester={{
                      year: year,
                      semester: "Fall",
                    }}
                  />
                </>
              );
            }
          })}

          <Box sx={{ margin: "50px" }}>
            <Button
              onClick={() => setOpen(!open)}
              type="submit"
              size="large"
              variant="contained"
              style={{
                height: "50px",
                borderRadius: "12px",
                marginTop: "60px",
              }}
              fullWidth={true}
            >
              {" "}
              {open
                ? "Hide Previous Year Subjects"
                : "Show Previous Year Subjects"}
            </Button>
          </Box>
        </>
      )}
    </Box>
  );
};

export default Subjects;
