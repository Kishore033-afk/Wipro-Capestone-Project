import axios from "axios";

export const API = axios.create({
  baseURL: "http://localhost:5093/api",
  headers: {
    "Content-Type": "application/json",
  },
});
