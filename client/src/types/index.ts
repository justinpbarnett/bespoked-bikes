// ----------------
// Response Types
// ----------------

export interface Product {
  id: number;
  name: string;
  description: string;
  manufacturer: string;
  style: string;
  purchasePrice: number;
  salePrice: number;
  quantityOnHand: number;
  commissionPercentage: number;
}

export interface Salesperson {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  phone: string;
  startDate: string;
  terminationDate: string | null;
  manager: string;
}

export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  phone: string;
  startDate: string;
}

export interface Sale {
  id: number;
  productId: number;
  customerId: number;
  salespersonId: number;
  saleDate: string;
  salePrice: number;
  commissionPercentage: number;
  commissionAmount: number;
  product?: Product;
  customer?: Customer;
  productName: string;
  customerFirstName: string;
  customerLastName: string;
  salespersonFirstName: string;
  salespersonLastName: string;
  originalPrice?: number;
  appliedDiscountPercentage: number;
  appliedDiscountCode?: string;
}

export interface Discount {
  id: number;
  beginDate: string;
  endDate: string;
  discountPercentage: number;
  product?: {
    id: number;
    name: string;
  };
  isGlobal: boolean;
  discountCode?: string;
  requiresCode: boolean;
}

export interface DetailedSale {
  saleDate: string;
  productName: string;
  customerName: string;
  salePrice: number;
  commissionAmount: number;
  commissionRate: number;
}

export interface ExtendedSalespersonCommission {
  salespersonId: number;
  firstName: string;
  lastName: string;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  averageCommissionRate: number;
  highestSale: number;
  lowestSale: number;
  manager?: string;
  startDate?: string;
  firstSaleDate?: string;
  lastSaleDate?: string;
  detailedSales: DetailedSale[];
}

export interface StyleReport {
  style: string;
  count: number;
  revenue: number;
  totalSales: number;
  totalCommission: number;
  averagePrice: number;
  totalRevenue: number;
}

export interface CommissionReport {
  startDate: string;
  endDate: string;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  averagePrice: number;
  commissions: ExtendedSalespersonCommission[];
  quarterSummary: {
    totalSales: number;
    totalRevenue: number;
    totalCommission: number;
    averageCommissionRate: number;
    averageSalePrice: number;
    salespersonsWithSales: number;
    salespersonCount: number;
  };
  monthlySummary: Array<{
    month: number;
    year: number;
    totalSales: number;
    totalRevenue: number;
    totalCommission: number;
  }>;
  productStyles: Array<{
    style: string;
    count: number;
    revenue: number;
    totalSales: number;
    totalCommission: number;
    averagePrice: number;
  }>;
  topProducts: Array<{
    productId: number;
    productName: string;
    manufacturer: string;
    totalSales: number;
    totalRevenue: number;
    totalCommission: number;
  }>;
  quarter: number;
  year: number;
}

// Dashboard Types
export interface DashboardSummary {
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  averageCommissionRate: number;
  averageSalePrice: number;
  salespersonsWithSales: number;
  salespersonCount: number;
  revenueChangePercentage: number;
  salesChangePercentage: number;
  activeSalespersons: number;
  inventoryAlerts: number;
  lowStockCount: number;
  outOfStockCount: number;
  totalProducts: number;
  inventoryValue: number;
}

export interface RecentSale {
  id: number;
  productName: string;
  customerName: string;
  salespersonName: string;
  saleDate: string;
  salePrice: number;
  commissionAmount: number;
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
  firstName: string;
  lastName: string;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  avatar?: string;
  target: number;
}

export interface InventoryAlert {
  outOfStock: Array<{
    id: number;
    name: string;
    quantityOnHand: number;
    reorderPoint: number;
  }>;
  lowStock: Array<{
    id: number;
    name: string;
    quantityOnHand: number;
    reorderPoint: number;
  }>;
}

export interface ProductPerformance {
  id: number;
  name: string;
  sales: number;
  revenue: number;
  commission: number;
  percentage: number;
}

// ----------------
// Request Types
// ----------------

export interface ProductCreate {
  name: string;
  description: string;
  manufacturer: string;
  style: string;
  purchasePrice: number;
  salePrice: number;
  quantityOnHand: number;
  commissionPercentage: number;
}

export interface ProductUpdate extends Partial<ProductCreate> {
  id?: number;
}

export interface SalespersonBase {
  firstName: string;
  lastName: string;
  address: string;
  phone: string;
  startDate: string;
  manager: string;
}

export interface SalespersonSubmit extends SalespersonBase {
  terminationDate: string | null;
}

export interface CustomerCreate {
  firstName: string;
  lastName: string;
  address: string;
  phone: string;
  startDate: string;
}

export interface SaleCreate {
  productId: number;
  customerId: number;
  salespersonId: number;
  saleDate: string;
  salePrice: number;
}

export interface DiscountCreate {
  productId?: number;
  beginDate: string;
  endDate: string;
  discountPercentage: number;
  isGlobal: boolean;
  discountCode?: string;
}

export type BadgeVariant =
  | "default"
  | "destructive"
  | "outline"
  | "secondary"
  | "warning";
