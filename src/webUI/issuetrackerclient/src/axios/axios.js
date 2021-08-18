import axios from "axios";

const instance = axios.create({
  baseURL: "http://localhost:5004",
  headers: {
    headerType: "example header type",
  },
});

export default instance;
