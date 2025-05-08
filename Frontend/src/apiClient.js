import axios from "axios";
import { API_URL } from "./config-global";

const api = axios.create({
  baseURL: API_URL,
  headers: { "Content-Type": "application/json" },
});

api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("authToken");
    if (token && config.headers) {
      config.headers.Authorization = `Token ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export class APIClient {
  constructor(endpoint) {
    this.endpoint = endpoint;
  }

  getAll = (config) =>
    api.get(`${this.endpoint}/`, config).then((res) => res.data);

  get = async (id, config) => {
    const res = await api.get(`${this.endpoint}/${id}/`, config);
    return res.data;
  };

  getByUsername = async (username, config) => {
    const res = await api.get(`${this.endpoint}/${username}/`, config);
    return res.data;
  };

  getFiltered = async (params, config) => {
    const queryParams = {};

    if (params && typeof params.filter_id === "number") {
      queryParams.project_id = params.filter_id;
    }

    if (params && params.start_date) {
      queryParams.start_date = params.start_date.toISOString();
    }

    if (params && params.end_date) {
      queryParams.end_date = params.end_date.toISOString();
    }

    const res = await api.get(this.endpoint, {
      ...config,
      params: queryParams,
    });
    return res.data;
  };

  post = (data, config) =>
    api.post(`${this.endpoint}/`, data, config).then((res) => res.data);

  put = (id, data, config) =>
    api.put(`${this.endpoint}/${id}/`, data, config).then((res) => res.data);

  patch = (id, data, config) =>
    api.patch(`${this.endpoint}/${id}/`, data, config).then((res) => res.data);

  delete = (id, config) =>
    api.delete(`${this.endpoint}/${id}/`, config).then((res) => res.data);
}

export default api;
