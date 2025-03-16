import api from "./api-client";
import type { Customer, CustomerCreate } from "@/types/index";

export const getCustomers = async (): Promise<Customer[]> => {
  const response = await api.get<Customer[]>("/customers");
  return response.data;
};

export const getCustomer = async (id: number): Promise<Customer> => {
  const response = await api.get<Customer>(`/customers/${id}`);
  return response.data;
};

export const createCustomer = async (
  customer: CustomerCreate
): Promise<Customer> => {
  const response = await api.post<Customer>("/customers", customer);
  return response.data;
};