import api from "./api-client";
import type { CommissionReport } from "@/types/index";

export const getCommissionReport = async (
  year: number,
  quarter: number
): Promise<CommissionReport> => {
  const response = await api.get<CommissionReport>("/reports/commission", {
    params: { year, quarter },
  });
  return response.data;
};