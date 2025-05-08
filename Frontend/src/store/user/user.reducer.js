import { first } from "lodash";
import { USER_ACTION_TYPES } from "./user.types";

const INITIAL_STATE = {
  userToken: "12312321sadsada",
  userData: {
    name: "John Doe",
    firstName: "John",
    lastName: "Doe",
    email: "jogn@gmail.com",
    phone: "1234567890",
    address: "123 Main St, City, Country",
    dateOfBirth: "1990-01-01",
    role: "Student",
    departments: ["Department 1", "Department 2"],
  },
};

export const userReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case USER_ACTION_TYPES.SET_USER_TOKEN:
      return { ...state, userToken: payload };
    case USER_ACTION_TYPES.SET_USER_DATA:
      return { ...state, userData: payload };

    default:
      return state;
  }
};
