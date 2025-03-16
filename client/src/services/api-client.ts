import axios from "axios";

// API URL can be overridden by environment variables
const API_URL = import.meta.env.VITE_API_URL || "/api";

// Create API client with simplified configuration
const api = axios.create({
  baseURL: API_URL,
  withCredentials: true,
  timeout: 30000, // 30 seconds
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
});

// Add request interceptor for authentication if needed
api.interceptors.request.use((config) => {
  // Example: Add authorization header if token exists
  // const token = localStorage.getItem('token');
  // if (token) {
  //   config.headers.Authorization = `Bearer ${token}`;
  // }
  return config;
});

// Add response interceptor for error handling
api.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    // Handle common errors (401, 403, 500, etc.)
    if (error.response) {
      // Session expired or unauthorized
      if (error.response.status === 401) {
        // Handle unauthorized (e.g., redirect to login)
        console.error("Unauthorized access, please log in again");
        // window.location.href = '/login';
      }

      // Log errors
      console.error("API Error:", error.response.status, error.response.data);
    } else if (error.request) {
      // Network error
      console.error("Network error:", error.message);
    } else {
      // Something else happened in setting up the request
      console.error("Error setting up request:", error.message);
    }

    return Promise.reject(error);
  }
);

export default api;