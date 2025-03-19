import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { API } from "../../services/api";

export const registerUser = createAsyncThunk(
  "auth/register",
  async (userData) => {
    const response = await API.post("/users/register", userData);
    return response.data;
  }
);

const authSlice = createSlice({
  name: "auth",
  initialState: { user: null, status: "idle" },
  reducers: {
    login: (state, action) => {
      state.user = action.payload;
    },
    logout: (state) => {
      state.user = null;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(registerUser.fulfilled, (state, action) => {
      state.user = action.payload;
    });
  },
});

export const { login, logout } = authSlice.actions;
export default authSlice.reducer;
