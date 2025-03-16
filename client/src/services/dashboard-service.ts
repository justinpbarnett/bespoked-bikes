import api from "./api-client";
import type { 
  DashboardSummary, 
  RecentSale, 
  MonthlySalesData, 
  TopSalesperson, 
  InventoryAlert,
  ProductPerformance
} from "@/types/index";

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