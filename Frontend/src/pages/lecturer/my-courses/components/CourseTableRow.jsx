import {
  Button,
  Menu,
  MenuItem,
  TableCell,
  TableRow,
  Typography,
} from "@mui/material";
import { styled, alpha } from "@mui/system";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import ViewIcon from "@/assets/view-icon";
import ExamIcon from "@/assets/exam-icon";
import ListIcon from "@/assets/list-icon";
import ListIcon2 from "@/assets/list-icon2";

const StyledMenu = styled((props) => (
  <Menu
    elevation={0}
    anchorOrigin={{
      vertical: "bottom",
      horizontal: "right",
    }}
    transformOrigin={{
      vertical: "top",
      horizontal: "right",
    }}
    {...props}
  />
))(({ theme }) => ({
  "& .MuiPaper-root": {
    borderRadius: 6,
    marginTop: theme.spacing(1),
    minWidth: 180,
    color:
      theme.palette.mode === "light"
        ? "rgb(55, 65, 81)"
        : theme.palette.grey[300],
    boxShadow:
      "rgb(255, 255, 255) 0px 0px 0px 0px, rgba(0, 0, 0, 0.05) 0px 0px 0px 1px, rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px",
    "& .MuiMenu-list": {
      padding: "4px 0",
    },
    "& .MuiMenuItem-root": {
      "& .MuiSvgIcon-root": {
        fontSize: 18,
        color: theme.palette.text.secondary,
        marginRight: theme.spacing(1.5),
      },
      "&:active": {
        backgroundColor: alpha(
          theme.palette.primary.main,
          theme.palette.action.selectedOpacity
        ),
      },
    },
  },
}));

const CourseTableRow = ({ course }) => {
  console.log(course);
  const { faculty, courseName, courseCode, courseSemester, schoolYear } =
    course;
  const navigate = useNavigate();
  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };
  return (
    <TableRow>
      <TableCell
        sx={{
          width: "20%",
        }}
      >
        {faculty ? faculty : "BM"}
      </TableCell>
      <TableCell>{courseCode}</TableCell>
      <TableCell
        sx={{
          width: "30%",
        }}
      >
        {courseName}
      </TableCell>
      <TableCell>{schoolYear}</TableCell>
      <TableCell>{courseSemester}</TableCell>
      <TableCell align="center">
        <Button onClick={handleClick} variant="outlined">
          Details
        </Button>
        <StyledMenu
          id="demo-customized-menu"
          MenuListProps={{
            "aria-labelledby": "demo-customized-button",
          }}
          anchorEl={anchorEl}
          open={open}
          onClose={handleClose}
        >
          <MenuItem
            onClick={() => {
              navigate(`/home/my-courses/details/${courseCode}`);
              handleClose();
            }}
            disableRipple
          >
            <ViewIcon />
            <Typography marginLeft={1} variant="inherit">
              Details
            </Typography>
          </MenuItem>
          <MenuItem
            onClick={() => {
              navigate(`/home/my-courses/exams/${courseCode}`);
              handleClose();
            }}
            disableRipple
          >
            <ExamIcon />
            <Typography marginLeft={1} variant="inherit">
              Exam Grades
            </Typography>
          </MenuItem>
          <MenuItem
            onClick={() => {
              navigate(`/home/my-courses/list/${courseCode}`);
              handleClose();
            }}
            disableRipple
          >
            <ListIcon2 />
            <Typography marginLeft={1} variant="inherit">
              Class List
            </Typography>
          </MenuItem>
        </StyledMenu>
      </TableCell>
    </TableRow>
  );
};

export default CourseTableRow;
