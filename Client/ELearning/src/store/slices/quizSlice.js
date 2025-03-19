import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { API } from "../../services/api";

export const fetchQuizzes = createAsyncThunk(
  "quizzes/fetchByCourse",
  async (courseId) => {
    const response = await API.get(`/quizzes/${courseId}`);
    return response.data;
  }
);

export const submitQuizAttempt = createAsyncThunk(
  "quizzes/submitAttempt",
  async (attemptData) => {
    const response = await API.post("/quizzes/attempt", attemptData);
    return response.data;
  }
);

export const fetchQuizAttempts = createAsyncThunk(
  "quizzes/fetchAttempts",
  async (userId) => {
    const response = await API.get(`/quizzes/attempts/${userId}`);
    return response.data;
  }
);

const quizSlice = createSlice({
  name: "quizzes",
  initialState: {
    quizzes: [],
    attempts: [],
    status: "idle",
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchQuizzes.pending, (state) => {
        state.status = "loading";
      })
      .addCase(fetchQuizzes.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.quizzes = action.payload;
      })
      .addCase(submitQuizAttempt.fulfilled, (state, action) => {
        state.attempts.push(action.payload);
      })
      .addCase(fetchQuizAttempts.fulfilled, (state, action) => {
        state.attempts = action.payload;
      });
  },
});

export default quizSlice.reducer;
