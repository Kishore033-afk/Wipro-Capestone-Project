import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { API } from "../../services/api";

export const enrollCourse = createAsyncThunk(
  "enrollments/enroll",
  async ({ userId, courseId }, { rejectWithValue }) => {
    try {
      const response = await API.post("/enrollments", {
        userId,
        courseId,
      });
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

export const fetchEnrollments = createAsyncThunk(
  "enrollments/fetchAll",
  async (userId) => {
    const response = await API.get(`/enrollments?userId=${userId}`);
    return response.data;
  }
);

export const updateCourseProgress = createAsyncThunk(
  "enrollments/updateProgress",
  async ({ enrollmentId, progress }) => {
    const response = await API.put(`/enrollments/${enrollmentId}/progress`, {
      progress,
    });
    return response.data;
  }
);

const enrollmentSlice = createSlice({
  name: "enrollments",
  initialState: {
    items: [],
    status: "idle",
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(enrollCourse.pending, (state) => {
        state.status = "loading";
      })
      .addCase(enrollCourse.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.items.push(action.payload);
      })
      .addCase(enrollCourse.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.payload;
      })
      .addCase(fetchEnrollments.fulfilled, (state, action) => {
        state.items = action.payload;
      })
      .addCase(updateCourseProgress.fulfilled, (state, action) => {
        const index = state.items.findIndex((e) => e.id === action.payload.id);
        if (index !== -1) {
          state.items[index] = action.payload;
        }
      });
  },
});

export default enrollmentSlice.reducer;
