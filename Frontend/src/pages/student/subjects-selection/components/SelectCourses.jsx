import { useState } from "react";

import { alpha } from "@mui/material/styles";
import { Box, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import CustomTabPanel from "@/components/CustomTabPanel";
import Explanation from "./tab-components/Explanation";
import OptionalCourses from "./tab-components/OptionalCourses";
import MandatoryCourses from "./tab-components/MandatoryCourses";
import UpperTermCourses from "./tab-components/UpperTermCourses";
import ExtracurricularCourses from "./tab-components/ExtracurricularCourses";
import SucceededCourses from "./tab-components/SucceededCourses";

const SelectCourses = ({ data }) => {
  const theme = useTheme();
  const [value, setValue] = useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  const {
    currentSemesterCourses,
    failedCourses,
    overHeadCourses,
    partiallyPassedCourses,
    passedCourses,
  } = data;
  const optionalCourses = currentSemesterCourses?.filter(
    (course) => course.courseType === "Optional"
  );
  const requiredCourses = currentSemesterCourses?.filter(
    (course) => course.courseType === "Mandatory"
  );

  return (
    <Box
      sx={{
        paddingBottom: "15px",
        maxWidth: "1000px",
        minWidth: "1000px",
        marginLeft: "15px",
        marginY: "15px",
        borderRadius: "10px",
        backgroundColor: "white",
        height: "auto",
        boxShadow: theme.customShadows.card,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          width: "100%",
          marginY: "5px",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Tabs
          TabIndicatorProps={{
            style: {
              height: "100%",
              borderRadius: "10px",
              backgroundColor: alpha(theme.palette.primary.main, 0.1),
            },
          }}
          value={value}
          onChange={handleChange}
        >
          <Tab label="Explanation" />
          <Tab label="Mandatory Courses" />
          <Tab label="Upper Term Courses" />
          <Tab label="Succeeded Courses" />
          <Tab label="Optional Courses" />
          <Tab label="Extracurricular Courses" />
        </Tabs>
        <CustomTabPanel value={value} index={0}>
          <Explanation />
        </CustomTabPanel>{" "}
        <CustomTabPanel value={value} index={1}>
          <MandatoryCourses
            courses={{ required: requiredCourses, failed: failedCourses }}
          />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={2}>
          <UpperTermCourses courses={overHeadCourses} />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={3}>
          <SucceededCourses courses={passedCourses} />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={4}>
          <OptionalCourses courses={optionalCourses} />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={5}>
          <ExtracurricularCourses />
        </CustomTabPanel>
      </Box>
    </Box>
  );
};

export default SelectCourses;
