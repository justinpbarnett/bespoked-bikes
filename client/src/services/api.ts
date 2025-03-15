import axios from "axios";
import {
  // Response types
  Product,
  Salesperson,
  Customer,
  Sale,
  Discount,
  CommissionReport,

  // Request types
  ProductCreate,
  ProductUpdate,
  SalespersonSubmit,
  CustomerCreate,
  SaleCreate,
  DiscountCreate,
} from "../types";

// In development, use relative URL which will be handled by Vite's proxy
// In production, use the full URL to the API server
const API_URL = import.meta.env.DEV ? "/api" : "https://localhost:7219/api";

const api = axios.create({
  baseURL: API_URL,
  // Adding withCredentials if you need to handle cookies/auth
  withCredentials: false,
});

// Products
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
  await api.put(`/products/${id}`, product);
};

// Salespersons
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
  await api.put(`/salespersons/${id}`, salesperson);
};

// Customers
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

// Sales
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

// Reports
export const getCommissionReport = async (
  year: number,
  quarter: number
): Promise<CommissionReport> => {
  const response = await api.get<CommissionReport>("/reports/commission", {
    params: { year, quarter },
  });
  return response.data;
};

// Discounts
export const getDiscounts = async (): Promise<Discount[]> => {
  const response = await api.get<Discount[]>("/discounts");
  return response.data;
};

export const createDiscount = async (
  discount: DiscountCreate
): Promise<Discount> => {
  const response = await api.post<Discount>("/discounts", discount);
  return response.data;
};

export default api;
