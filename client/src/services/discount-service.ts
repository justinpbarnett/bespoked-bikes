import api from "./api-client";
import type { Discount, DiscountCreate } from "@/types/index";

export const getDiscounts = async (): Promise<Discount[]> => {
  const response = await api.get<Discount[]>("/discounts");
  return response.data;
};

export const getGlobalDiscounts = async (
  date?: string
): Promise<Discount[]> => {
  const params = new URLSearchParams();
  if (date) params.append("date", date);

  const response = await api.get<Discount[]>("/discounts/global", { params });
  return response.data;
};

export const createDiscount = async (
  discount: DiscountCreate
): Promise<Discount> => {
  const response = await api.post<Discount>("/discounts", discount);
  return response.data;
};