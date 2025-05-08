import { SELECTED_SUBJECTS_ACTIONS } from "./selected-subjects.types";

const INITIAL_STATE = {
  selectedSubjects: [],
  fetchedSubjects: [],
};

export const selectedSubjectsReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case SELECTED_SUBJECTS_ACTIONS.SET_SELECTED_SUBJECTS:
      return { ...state, selectedSubjects: payload };
    case SELECTED_SUBJECTS_ACTIONS.SET_FETCHED_SUBJECTS:
      return { ...state, fetchedSubjects: payload };
    default:
      return state;
  }
};
