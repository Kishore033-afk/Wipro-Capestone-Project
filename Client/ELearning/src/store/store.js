import { configureStore } from "@reduxjs/toolkit";
import courseReducer from "./slices/courseSlice";
import authReducer from "./slices/authSlice";
import enrollmentReducer from "./slices/enrollmentSlice";
import quizReducer from "./slices/quizSlice";

export const store = configureStore({
  reducer: {
    courses: courseReducer,
    auth: authReducer,
    enrollments: enrollmentReducer,
    quizzes: quizReducer,
  },
});
