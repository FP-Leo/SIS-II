import { ROLE_TYPES } from "@/router/role.types";

import ListIcon from "@/assets/list-icon";
import BelgeIcon from "@/assets/belge-icon";
import StudentIcon from "@/assets/student-icon";
import CalendarIcon from "@/assets/calendar-icon";
import DerslerimIcon from "@/assets/derslerim-icon";

const STUDENT_PAGES = [
  { title: "Subjects", link: "my-courses", icon: <DerslerimIcon /> },
  { title: "Calendar", link: "calendar", icon: <CalendarIcon /> },
  {
    title: "Course Selection",
    link: "course-selection",
    icon: <DerslerimIcon />,
  },
  { title: "Documents", link: "document-request", icon: <BelgeIcon /> },
];

const ADVISOR_PAGES = [
  {
    title: "Students I Advise",
    link: "advisor-students",
    icon: <StudentIcon />,
  },
];

const ADMINISTRATOR_PAGES = [
  {
    title: "Lecturers",
    link: "lecturers",
    icon: <ListIcon />,
  },
];

const PROFESSOR_PAGES = [
  { title: "Courses", link: "my-courses", icon: <DerslerimIcon /> },
];

const Pages = (role) => {
  switch (role) {
    case ROLE_TYPES.STUDENT:
      return STUDENT_PAGES;
    case ROLE_TYPES.LECTURER:
      return PROFESSOR_PAGES;
    case ROLE_TYPES.ADVISOR:
      return ADVISOR_PAGES;
    case ROLE_TYPES.ADMINISTRATOR:
      return ADMINISTRATOR_PAGES;
    default:
      return "No pages available for this role.";
  }
};

export default Pages;
