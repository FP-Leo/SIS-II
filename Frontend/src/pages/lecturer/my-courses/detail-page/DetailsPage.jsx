import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import { Box, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import CustomTabPanel from "@/components/CustomTabPanel";
import GeneralInfo from "./tab-components/GeneralInfo";
import { useSelector } from "react-redux";
import { selectUserToken } from "@/store/user/user.selector";

function a11yProps(index) {
  return {
    id: `vertical-tab-${index}`,
    "aria-controls": `vertical-tabpanel-${index}`,
  };
}

const DetailsPage = () => {
  const param = useParams();
  const theme = useTheme();
  const [value, setValue] = useState(0);
  const token = useSelector(selectUserToken);
  const [courseDetails, setCourseDetails] = useState({});

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <Box
      sx={{
        marginX: 6,
        marginY: 6,
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          display: "grid",
          gridTemplateColumns: "1fr 3fr",
        }}
      >
        <Box
          sx={{
            marginRight: 6,
            paddingBottom: 2,
            borderRight: `1px solid ${theme.palette.divider}`,
          }}
        >
          <Tabs
            sx={{
              marginTop: 0,
            }}
            orientation="vertical"
            variant="scrollable"
            value={value}
            onChange={handleChange}
            aria-label="vertical tabs"
            TabIndicatorProps={{
              style: {
                left: 0,
              },
            }}
          >
            <Tab
              data-variant="settings"
              iconPosition="start"
              label="General Information"
              {...a11yProps(0)}
            />
            <Tab
              data-variant="settings"
              iconPosition="start"
              label="Students List"
              {...a11yProps(1)}
            />{" "}
          </Tabs>
        </Box>
        <Box
          sx={{
            marginTop: 3,
          }}
        >
          <CustomTabPanel value={value} index={0}>
            <GeneralInfo details={courseDetails} />
          </CustomTabPanel>
        </Box>
      </Box>
    </Box>
  );
};

export default DetailsPage;
