// ----------------
// Response Types
// ----------------

export interface Product {
  id: number;
  name: string;
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
  manager: string | null;
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
  salesDate: string;
  salePrice: number;
  commissionAmount: number;
  originalPrice: number;
  appliedDiscountId: number | null;
  appliedDiscountPercentage: number;
  appliedDiscountCode?: string;
  productId: number;
  productName: string;
  salespersonId: number;
  salespersonFirstName: string;
  salespersonLastName: string;
  customerId: number;
  customerFirstName: string;
  customerLastName: string;

  // Virtual properties for compatibility with existing UI
  product?: {
    id: number;
    name: string;
  };
  salesperson?: {
    id: number;
    firstName: string;
    lastName: string;
  };
  customer?: {
    id: number;
    firstName: string;
    lastName: string;
  };
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

export interface CommissionReport {
  year: number;
  quarter: number;
  startDate: string;
  endDate: string;
  commissions: Array<{
    salespersonId: number;
    firstName: string;
    lastName: string;
    totalSales: number;
    totalRevenue: number;
    totalCommission: number;
  }>;
}

// Dashboard Types
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

// ----------------
// Request Types
// ----------------

export interface ProductCreate {
  name: string;
  manufacturer: string;
  style: string;
  purchasePrice: number;
  salePrice: number;
  quantityOnHand: number;
  commissionPercentage: number;
}

// Allow updating all product fields including name
export interface ProductUpdate extends ProductCreate {}

export interface SalespersonBase {
  firstName: string;
  lastName: string;
  address: string;
  phone: string;
  startDate: string;
  manager: string | null;
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
  salespersonId: number;
  customerId: number;
  salesDate: string;
  discountCode?: string;
}

export interface DiscountCreate {
  productId?: number;
  beginDate: string;
  endDate: string;
  discountPercentage: number;
  isGlobal: boolean;
  discountCode?: string;
}
