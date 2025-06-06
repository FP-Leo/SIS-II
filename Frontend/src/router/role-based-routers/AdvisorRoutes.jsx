import EditProfile from "@/pages/edit-profile/EditProfile";
import MainScreenCategories from "@/pages/MainScreenCategories";
import AdvisorStudents from "@/pages/advisor/students/AdvisorStudents";
import StudentTranscript from "@/pages/advisor/students/detail-pages/student-transcript/StudentTranscript";
import StudentsInformation from "@/pages/advisor/students/detail-pages/student-information/StudentsInformation";
import RegistrationControl from "@/pages/advisor/students/detail-pages/registration-control/RegistrationControl";
import SubjectsRegistration from "@/pages/advisor/students/detail-pages/subjects-registration.jsx/SubjectsRegistration";

const AdvisorRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
  {
    path: "advisor-students",
    element: <AdvisorStudents />,
  },

  {
    path: "transcript/:id",
    element: <StudentTranscript />,
  },

  {
    path: "students-information/:id",
    element: <StudentsInformation />,
  },
  {
    path: "subjects-registration/:id",
    element: <SubjectsRegistration />,
  },
  {
    path: "registration-control/:id",
    element: <RegistrationControl />,
  },
];

export default AdvisorRoutes;
