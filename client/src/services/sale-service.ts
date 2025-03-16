import api from "./api-client";
import type { Sale, SaleCreate } from "@/types/index";

export const getSales = async (): Promise<Sale[]> => {
  const response = await api.get<Sale[]>("/sales");
  return response.data;
};

export const getSalesFiltered = async (
  startDate?: string,
  endDate?: string
): Promise<Sale[]> => {
  const params = new URLSearchParams();
  if (startDate) params.append("startDate", startDate);
  if (endDate) params.append("endDate", endDate);

  const response = await api.get<Sale[]>("/sales/filter", { params });
  return response.data;
};

export const createSale = async (saleDto: SaleCreate): Promise<Sale> => {
  const response = await api.post<Sale>("/sales", saleDto);
  return response.data;
};