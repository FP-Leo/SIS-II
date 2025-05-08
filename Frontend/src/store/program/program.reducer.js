import { PROGRAM_ACTION_TYPES } from "./program.types";

const INITIAL_STATE = {
  program: "Computer Engineering",
  programData: {
    name: "Computer Engineering",
    description: "This is a sample program description.",
    courses: [
      { code: "CSE101", name: "Introduction to Computer Science" },
      { code: "CSE102", name: "Data Structures" },
      { code: "CSE103", name: "Algorithms" },
      { code: "CSE104", name: "Operating Systems" },
    ],
  },
};

export const programReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case PROGRAM_ACTION_TYPES.SET_PROGRAM:
      return { ...state, program: payload };
    default:
      return state;
  }
};
