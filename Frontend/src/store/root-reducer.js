import { combineReducers } from "redux";

import { userReducer } from "./user/user.reducer";
import { selectedSubjectsReducer } from "./selected-subjects/selected-subjects.reducer";
import { programReducer } from "./program/program.reducer";

export const rootReducer = combineReducers({
  user: userReducer,
  selectedSubjects: selectedSubjectsReducer,
  program: programReducer,
});
