import { Box, Typography, Avatar } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import moment from "moment";
const GeneralInfoTable = ({ data }) => {
  const theme = useTheme();
  console.log(data);
  const { lecturerName, state, grade, examResultDtos } = data;

  return (
    <Box
      sx={{
        backgroundColor: theme.palette.common.white,
        boxShadow: theme.customShadows.z4,
        borderRadius: 1,
        display: "flex",
        flexDirection: "column",
        marginBottom: 3,
      }}
    >
      <Box
        sx={{
          paddingY: 2,
          paddingX: 3,
          width: "100%",
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <Typography variant="subtitle2">{`Course Name: Math (Hard Coded)`}</Typography>
        <Typography variant="subtitle2">{`State: ${state}`}</Typography>
      </Box>
      <Box
        sx={{
          display: "grid",
          alignItems: "center",
          height: "40px",
          gridTemplateColumns: "1fr 1fr 1fr 1fr ",
          backgroundColor: theme.palette.grey[200],
          borderTop: `1px solid ${theme.palette.divider}`,
          borderBottom: `1px solid ${theme.palette.divider}`,
        }}
      >
        <Typography textAlign="center" variant="caption">
          Exam Type
        </Typography>
        <Typography textAlign="center" variant="caption">
          Exam Name
        </Typography>
        <Typography textAlign="center" variant="caption">
          Announcement Date
        </Typography>
        <Typography textAlign="center" variant="caption">
          Points
        </Typography>
      </Box>
      <Box
        sx={{
          width: "100%",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "flex",
            flexDirection: "column",
          }}
        >
          {examResultDtos?.map((exam, index) => (
            <Box
              key={index}
              sx={{
                display: "grid",
                alignItems: "center",
                height: "40px",
                gridTemplateColumns: "1fr 1fr 1fr 1fr ",
                borderBottom: `1px solid ${theme.palette.divider}`,
              }}
            >
              <Typography textAlign="center" variant="caption">
                {exam.examName}
              </Typography>
              <Typography textAlign="center" variant="caption">
                {exam.examName}
              </Typography>
              <Typography textAlign="center" variant="caption">
                {moment(exam.announcmentDate).format("YYYY-MM-DD, h:mm")}
              </Typography>
              <Typography textAlign="center" variant="caption">
                {exam.points}
              </Typography>
            </Box>
          ))}
        </Box>
      </Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            marginLeft: 3,

            marginY: 3,
          }}
        >
          <Avatar src={""} />
          <Typography
            sx={{
              marginLeft: 3,
            }}
            variant="caption"
          >
            {"Lecturer: " + lecturerName}
          </Typography>
        </Box>
        <Box pr={3}>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Typography
              variant="caption"
              sx={{
                marginRight: 1,
              }}
            >
              Class average grade point at the end of the Finals:{" "}
            </Typography>
            <Typography>-</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Typography
              variant="caption"
              sx={{
                marginRight: 1,
              }}
            >
              Class average grade point at the end of the Complements:{" "}
            </Typography>
            <Typography>-</Typography>
          </Box>
        </Box>
      </Box>
    </Box>
  );
};
export default GeneralInfoTable;
