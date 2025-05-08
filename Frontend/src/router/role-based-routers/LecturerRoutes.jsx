import EditProfile from "@/pages/edit-profile/EditProfile";
import MainScreenCategories from "@/pages/MainScreenCategories";
import Courses from "@/pages/lecturer/my-courses/Courses";
import DetailsPage from "@/pages/lecturer/my-courses/detail-page/DetailsPage";
import ParticlesCSS from "@/components/particles";

const LecturerRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
  {
    path: "my-courses",
    element: <Courses />,
  },
  {
    path: "my-courses/details/:courseCode",
    element: <DetailsPage />,
  },
  {
    path: "my-courses/exams/:courseCode",
    element: <ParticlesCSS />,
  },
  {
    path: "my-courses/list/:courseCode",
    element: <DetailsPage />,
  },
];

export default LecturerRoutes;
