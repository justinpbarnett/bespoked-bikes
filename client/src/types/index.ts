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
  product: {
    id: number;
    name: string;
  };
  salesperson: {
    id: number;
    firstName: string;
    lastName: string;
  };
  customer: {
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
  product: {
    id: number;
    name: string;
  };
}

export interface DetailedSale {
  saleId: number;
  salesDate: string;
  productId: number;
  productName: string;
  customerId: number;
  customerName: string;
  salePrice: number;
  commissionAmount: number;
  commissionRate: number;
}

export interface SalespersonCommission {
  salespersonId: number;
  firstName: string;
  lastName: string;
  manager: string | null;
  startDate: string | null;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  averageCommissionRate: number;
  highestSale: number;
  lowestSale: number;
  firstSaleDate: string | null;
  lastSaleDate: string | null;
  detailedSales: DetailedSale[];
}

export interface ProductStyleSummary {
  style: string;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  averagePrice: number;
}

export interface MonthlySummary {
  month: number;
  year: number;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
}

export interface TopProduct {
  productId: number;
  productName: string;
  manufacturer: string;
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
}

export interface QuarterSummary {
  totalSales: number;
  totalRevenue: number;
  totalCommission: number;
  averageCommissionRate: number;
  averageSalePrice: number;
  salespersonCount: number;
  salespersonsWithSales: number;
}

export interface CommissionReport {
  year: number;
  quarter: number;
  startDate: string;
  endDate: string;
  quarterSummary: QuarterSummary;
  productStyles: ProductStyleSummary[];
  monthlySummary: MonthlySummary[];
  topProducts: TopProduct[];
  commissions: SalespersonCommission[];
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
}

export interface DiscountCreate {
  productId: number;
  beginDate: string;
  endDate: string;
  discountPercentage: number;
}
