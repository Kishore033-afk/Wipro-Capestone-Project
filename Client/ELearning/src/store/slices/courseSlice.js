import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { API } from "../../services/api";

// Existing thunk
export const fetchCourses = createAsyncThunk("courses/fetchAll", async () => {
  const response = await API.get("/courses");
  return response.data;
});

// New thunk for fetching single course
export const fetchCourseById = createAsyncThunk(
  "courses/fetchById",
  async (courseId) => {
    const response = await API.get(`/courses/${courseId}`);
    return response.data;
  }
);

export const courseSlice = createSlice({
  name: "courses",
  initialState: { items: [], status: "idle" },
  reducers: {},
  extraReducers: (builder) => {
    builder
      // Existing cases
      .addCase(fetchCourses.pending, (state) => {
        state.status = "loading";
      })
      .addCase(fetchCourses.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.items = action.payload;
      })
      // New cases for fetchCourseById
      .addCase(fetchCourseById.pending, (state) => {
        state.status = "loading";
      })
      .addCase(fetchCourseById.fulfilled, (state, action) => {
        const existing = state.items.find((c) => c.id === action.payload.id);
        if (!existing) {
          state.items.push(action.payload);
        }
        state.status = "succeeded";
      })
      .addCase(fetchCourseById.rejected, (state) => {
        state.status = "failed";
      });
  },
});

export default courseSlice.reducer;
