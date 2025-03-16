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

// For development: keep it simple with the proxy
// Let the proxy in vite.config.ts handle the routing to the backend
const API_URL = "/api";

// Create API client with simplified configuration
const api = axios.create({
  baseURL: API_URL,
  // Adding withCredentials if you need to handle cookies/auth
  withCredentials: false,
  // Add reasonable timeout but slightly shorter for development to see errors faster
  timeout: 10000, // 10 seconds
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

// Add request interceptor for debugging
api.interceptors.request.use(
  (config) => {
    return config;
  },
  (error) => {
    console.error("API Request Error:", error);
    return Promise.reject(error);
  }
);

// Add response interceptor for error handling with detailed debugging
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

      // Log other errors
      console.error("API Error:", error.response.status, error.response.data);

      // More detailed debugging
      console.error("Complete error response:", {
        status: error.response.status,
        statusText: error.response.statusText,
        data: error.response.data,
        headers: error.response.headers,
        config: {
          url: error.config?.url,
          method: error.config?.method,
          data: error.config?.data,
        },
      });
    } else if (error.request) {
      // Network error - add more detailed debugging info
      console.error("Network error details:", {
        message: error.message,
        request: {
          url: error.config?.url,
          method: error.config?.method,
          baseURL: error.config?.baseURL,
          headers: error.config?.headers,
          data: error.config?.data,
        },
        code: error.code,
        stack: error.stack,
      });
    } else {
      // Something else happened in setting up the request
      console.error("Error setting up request:", error.message);
    }

    return Promise.reject(error);
  }
);

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
  await api.put(`/products/${id}`, {
    ...product,
    id: id, // Explicitly include id in the request body
  });
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
  // Include the ID in the request body to match route parameter
  await api.put(`/salespersons/${id}`, {
    ...salesperson,
    id: id, // Explicitly include id in the request body
  });
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
  try {
    const response = await api.post<Discount>("/discounts", discount);
    return response.data;
  } catch (error) {
    console.error("API error in createDiscount:", error);
    throw error;
  }
};

// Dashboard
export interface DashboardSummary {
  totalRevenue: number;
  totalSales: number;
  activeSalespersons: number;
  inventoryAlerts: number;
  lowStockCount: number;
  outOfStockCount: number;
  revenueChangePercentage: number;
  salesChangePercentage: number;
  totalProducts: number;
  inventoryValue: number;
}

export interface RecentSale {
  id: number;
  salesDate: string;
  salePrice: number;
  product: string;
  salesperson: string;
  customer: string;
}

export interface MonthlySalesData {
  year: number;
  data: Array<{
    label: string;
    sales: number;
    commission: number;
  }>;
}

export interface TopSalesperson {
  id: number;
  name: string;
  avatar: string;
  sales: number;
  target: number;
}

export interface InventoryAlert {
  outOfStock: Array<{
    id: number;
    name: string;
    manufacturer: string;
    quantityOnHand: number;
    status: string;
  }>;
  lowStock: Array<{
    id: number;
    name: string;
    manufacturer: string;
    quantityOnHand: number;
    reorderLevel: number;
    status: string;
  }>;
}

export interface ProductPerformance {
  id: number;
  name: string;
  sales: number;
  revenue: number;
  percentage: number;
}

export const getDashboardSummary = async (): Promise<DashboardSummary> => {
  const response = await api.get<DashboardSummary>("/dashboard/summary");
  return response.data;
};

export const getRecentSales = async (
  count: number = 5
): Promise<RecentSale[]> => {
  const response = await api.get<RecentSale[]>("/dashboard/recent-sales", {
    params: { count },
  });
  return response.data;
};

export const getMonthlySalesData = async (
  year: number | string
): Promise<MonthlySalesData> => {
  const response = await api.get<MonthlySalesData>("/dashboard/monthly-sales", {
    params: { year },
  });
  return response.data;
};

export const getTopSalespersons = async (
  count: number = 3
): Promise<TopSalesperson[]> => {
  const response = await api.get<TopSalesperson[]>(
    "/dashboard/top-salespersons",
    {
      params: { count },
    }
  );
  return response.data;
};

export const getInventoryAlerts = async (): Promise<InventoryAlert> => {
  const response = await api.get<InventoryAlert>("/dashboard/inventory-alerts");
  return response.data;
};

export const getProductPerformance = async (): Promise<
  ProductPerformance[]
> => {
  const response = await api.get<ProductPerformance[]>(
    "/dashboard/product-performance"
  );
  return response.data;
};

export default api;
