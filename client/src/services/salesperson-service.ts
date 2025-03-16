import api from "./api-client";
import type { Salesperson, SalespersonSubmit } from "@/types/index";

export const getSalespersons = async (): Promise<Salesperson[]> => {
  const response = await api.get<Salesperson[]>("/salespersons");
  return response.data;
};

export const getSalesperson = async (id: number): Promise<Salesperson> => {
  const response = await api.get<Salesperson>(`/salespersons/${id}`);
  return response.data;
};

export const createSalesperson = async (
  salesperson: SalespersonSubmit
): Promise<Salesperson> => {
  const response = await api.post<Salesperson>("/salespersons", salesperson);
  return response.data;
};

export const updateSalesperson = async (
  id: number,
  salesperson: SalespersonSubmit
): Promise<void> => {
  // Include the ID in the request body to match route parameter
  await api.put(`/salespersons/${id}`, {
    ...salesperson,
    id: id, // Explicitly include id in the request body
  });
};