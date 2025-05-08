import { useDispatch } from "react-redux";
import { Outlet } from "react-router-dom";
import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

import { Router } from "@/router/router";
import { setProgram } from "@/store/program/program.action";
import LoadingPage from "@/components/loading-page/LoadingPage";
import { tokenValidationService } from "@/services/AuthService.js";
import { setUserToken, setUserData } from "@/store/user/user.action";

import { _program, _user } from "@/_mock/data";

const App = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const location = useLocation();
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const checkAuthStatus = async () => {
      // const { isAuthenticated, error, user, company } =
      //   await tokenValidationService.checkAuth();

      localStorage.setItem(
        "token",
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
      );

      const isAuthenticated = true;
      const error = null;
      const user = _user;
      const program = _program;

      if (isAuthenticated) {
        dispatch(setUserToken(localStorage.getItem("token")));
        dispatch(setUserData(user));
        dispatch(setProgram(program));
        if (location.pathname === "/") {
          navigate("/home");
        }
      } else {
        navigate("/");
        localStorage.removeItem("token");
        dispatch(setUserToken(null));
        dispatch(setUserData(null));
        dispatch(setProgram(null));
        console.error(error);
      }

      setIsLoading(false);
    };

    checkAuthStatus();
  }, []);

  if (isLoading) {
    return <LoadingPage />;
  }

  return (
    <>
      <Router />
      <Outlet />
    </>
  );
};

export default App;
