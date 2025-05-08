import Calendar from "@/pages/student/calendar/Calendar";
import Subjects from "@/pages/student/subjects/subjects";
import EditProfile from "@/pages/edit-profile/EditProfile";
import MainScreenCategories from "@/pages/MainScreenCategories";
import SubjectsSelection from "@/pages/student/subjects-selection/SubjectsSelection";

import BelgeTablebi from "@/pages/student/belge-talebi/BelgeTalebi";
import SubjectDetails from "@/pages/student/subjects/SubjectDetails.jsx/SubjectDetails.jsx";

// ==============================|| Student Routing ||============================== //

const StudentRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "my-courses",
    element: <Subjects />,
  },
  {
    path: "my-courses/:courseCode/:id",
    element: <SubjectDetails />,
  },
  {
    path: "course-selection",
    element: <SubjectsSelection />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
  {
    path: "calendar",
    element: <Calendar />,
  },
  {
    path: "document-request",
    element: <BelgeTablebi />,
  },
];

export default StudentRoutes;
