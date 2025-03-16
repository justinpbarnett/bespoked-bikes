import api from "./api-client";
import type { Product, ProductCreate, ProductUpdate } from "@/types/index";

export const getProducts = async (): Promise<Product[]> => {
  const response = await api.get<Product[]>("/products");
  return response.data;
};

export const getProduct = async (id: number): Promise<Product> => {
  const response = await api.get<Product>(`/products/${id}`);
  return response.data;
};

export const createProduct = async (
  product: ProductCreate
): Promise<Product> => {
  const response = await api.post<Product>("/products", product);
  return response.data;
};

export const updateProduct = async (
  id: number,
  product: ProductUpdate
): Promise<void> => {
  await api.put(`/products/${id}`, {
    ...product,
    id: id, // Explicitly include id in the request body
  });
};