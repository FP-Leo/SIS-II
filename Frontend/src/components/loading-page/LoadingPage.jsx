import React from "react";
import styles from "./styles.module.css";
import Logo from "@/assets/logo";
import { Box, useTheme } from "@mui/material";

const LoadingPage = () => {
  const theme = useTheme();

  return (
    <div className={styles.loadingContainer}>
      <Logo width={200} height={160} />
      <Box
        sx={{
          borderTop: "3px solid #000",
          marginTop: "50px",
          "&:after": {
            borderTop: `3px solid ${theme.palette.primary.main}`,
          },
        }}
        className={styles.loader}
      ></Box>
    </div>
  );
};

export default LoadingPage;
