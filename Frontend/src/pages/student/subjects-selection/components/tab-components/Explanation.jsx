import { Box } from "@mui/material";

import InfoBox from "@/components/Info-Box";

const Explanation = () => {
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        flexDirection: "column",

        marginTop: "30px",
        paddingX: "10px",
      }}
    >
      <InfoBox description="(*) Courses marked with this are not included in the credit or Lesson Hour totals." />
      <InfoBox description="(**) Courses marked with this are available as Distance Education. You can choose the branch you want to register in. Distance Education is a form of education provided electronically over the internet, without the obligation of the instructor and the student to be in the same environment.*" />
      <InfoBox
        heading=":: Mandatory Courses ::"
        description="Under the mandatory courses tab, there are courses that are included in your semester or that you have experienced in previous semesters. (If the previous all-region course was held in the semester you are currently enrolled in, it will be automatically registered and you cannot remove that course.) These are compulsory courses to be completed in order to graduate."
      />{" "}
      <InfoBox
        heading=":: Extracurricular Courses ::"
        description="The selected courses panel on the left is automatically filled with mandatory courses that you have previously taken but failed to pass. You can select and add the courses you want to take on top of these courses according to your ECTS/AKTS from the courses in the tables above."
      />{" "}
      <InfoBox
        heading=":: Upper Term Courses ::"
        description="There are courses form your upper semester in the upper semester courses tab."
      />{" "}
      <InfoBox
        heading=":: Succeeded Courses ::"
        description="In the Succeeded Courses tab, you can find the courses you have previously taken and succeeded in. You can choose from these courses to increase your grades."
      />{" "}
      <InfoBox
        heading=":: Optional Courses ::"
        description="Your optional courses are included in the elective courses tab. It is not mandatory for graduation, but you must take elective courses to complete the credits required for graduation."
      />{" "}
    </Box>
  );
};

export default Explanation;
