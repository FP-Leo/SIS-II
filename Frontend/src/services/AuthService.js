import api from "../apiClient";
import axios from "axios";

export const loginService = async (email, password) => {
  try {
    const response = await api.post("/login/", { username: email, password });
    return response.data;
  } catch (error) {
    console.error("Login error:", error);

    if (axios.isAxiosError(error)) {
      if (error.response) {
        throw new Error(error.response.data.message || "Invalid credentials");
      } else if (error.request) {
        throw new Error("Network error. Please try again.");
      }
    }

    throw new Error("An unexpected error occurred.");
  }
};

export const tokenValidationService = {
  checkAuth: async () => {
    try {
      const token = localStorage.getItem("token");
      if (!token) {
        localStorage.removeItem("token");
        return {
          isAuthenticated: false,
          error: null,
          user: null,
          company: null,
        };
      }

      const response = await api.get("/token-validation/", {
        headers: {
          Authorization: `Token ${token}`,
        },
      });

      if (response.status === 200) {
        return {
          error: null,
          isAuthenticated: true,
          user: response.data.user,
          company: response.data.company,
        };
      } else {
        return {
          isAuthenticated: false,
          error: "Invalid token",
          user: null,
          company: null,
        };
      }
    } catch (error) {
      console.error("Error validating token:", error);
      return {
        isAuthenticated: false,
        error: "Error validating token",
        user: null,
        company: null,
      };
    }
  },
};
