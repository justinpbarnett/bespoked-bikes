"use client";
import React from "react";
import { Link } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import {
  BarChart3,
  Users,
  ShoppingCart,
  Package,
  DollarSign,
  AlertTriangle,
  TrendingUp,
  Calendar,
  PlusCircle,
} from "lucide-react";
import { Progress } from "@/components/ui/progress";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Badge } from "@/components/ui/badge";
import { Skeleton } from "@/components/ui/skeleton";
import { SalesCommissionChart } from "../components/SalesCommissionChart";
import { SalesCommissionChartSkeleton } from "../components/SalesCommissionChartSkeleton";
import {
  getDashboardSummary,
  getRecentSales,
  getMonthlySalesData,
  getTopSalespersons,
  getProductPerformance,
  getInventoryAlerts,
} from "../services/api";
import type {
  DashboardSummary,
  RecentSale,
  MonthlySalesData,
  TopSalesperson,
  ProductPerformance,
  InventoryAlert,
} from "../types/index";

export default function Dashboard() {
  // Get current date info for data filtering
  const currentDate = new Date();
  const currentYear = currentDate.getFullYear();

  // Fetch dashboard data
  const { data: summaryData, isLoading: isSummaryLoading } =
    useQuery<DashboardSummary>({
      queryKey: ["dashboardSummary"],
      queryFn: getDashboardSummary,
      staleTime: 1000 * 60 * 5, // 5 minutes
      gcTime: 1000 * 60 * 30, // 30 minutes
    });

  const { data: recentSales, isLoading: isRecentSalesLoading } = useQuery<
    RecentSale[]
  >({
    queryKey: ["recentSales"],
    queryFn: () => getRecentSales(5),
    staleTime: 1000 * 60 * 5, // 5 minutes
    gcTime: 1000 * 60 * 30, // 30 minutes
  });

  // Fetch the current year data (which will be a 12-month rolling window)
  const { data: rollingYearSalesData, isLoading: isRollingYearSalesLoading } =
    useQuery<MonthlySalesData>({
      queryKey: ["monthlySales", currentYear],
      queryFn: () => getMonthlySalesData(currentYear),
      staleTime: 1000 * 60 * 10, // 10 minutes
      gcTime: 1000 * 60 * 60, // 60 minutes
    });

  const { data: allTimeSalesData, isLoading: isAllTimeSalesLoading } =
    useQuery<MonthlySalesData>({
      queryKey: ["monthlySales", "all"],
      queryFn: () => getMonthlySalesData("all"),
      staleTime: 1000 * 60 * 10, // 10 minutes
      gcTime: 1000 * 60 * 60, // 60 minutes
    });

  // Combine and prepare the data
  const isMonthlySalesLoading =
    isRollingYearSalesLoading || isAllTimeSalesLoading;

  // Create a dataset for the chart
  const monthlySalesData = React.useMemo(() => {
    if (!rollingYearSalesData?.data || !allTimeSalesData?.data) return null;

    const yearData = [...rollingYearSalesData.data];

    return {
      year: currentYear,
      data: yearData.map((item) => ({
        ...item,
        month: item.label, // Map label to month for chart component
      })),
      allTimeData: allTimeSalesData.data.map((item) => ({
        label: item.label,
        sales: item.sales,
        commission: item.commission,
      })),
    };
  }, [rollingYearSalesData, allTimeSalesData, currentYear]);

  const { data: topSalespersons, isLoading: isTopSalespersonsLoading } =
    useQuery<TopSalesperson[]>({
      queryKey: ["topSalespersons"],
      queryFn: () => getTopSalespersons(3),
      staleTime: 1000 * 60 * 5, // 5 minutes
      gcTime: 1000 * 60 * 30, // 30 minutes
    });

  const { data: inventoryAlerts, isLoading: isInventoryAlertsLoading } =
    useQuery<InventoryAlert>({
      queryKey: ["inventoryAlerts"],
      queryFn: getInventoryAlerts,
      staleTime: 1000 * 60 * 5, // 5 minutes
      gcTime: 1000 * 60 * 30, // 30 minutes
    });

  const { data: productPerformance, isLoading: isProductPerformanceLoading } =
    useQuery<ProductPerformance[]>({
      queryKey: ["productPerformance"],
      queryFn: getProductPerformance,
      staleTime: 1000 * 60 * 10, // 10 minutes
      gcTime: 1000 * 60 * 30, // 30 minutes
    });

  // Format currency for display
  const formatCurrency = (amount: number) => {
    return new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
    }).format(amount);
  };

  return (
    <div className="container mx-auto py-10">
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center mb-8">
        <div>
          <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
          <p className="text-muted-foreground">
            Welcome back, Manager. Here's an overview of your bike shop.
          </p>
        </div>
        <div className="flex gap-2 mt-4 md:mt-0">
          <Button asChild>
            <Link to="/sales/new">
              <PlusCircle className="mr-2 h-4 w-4" />
              Record Sale
            </Link>
          </Button>
          <Button variant="outline" asChild>
            <Link to="/reports">
              <BarChart3 className="mr-2 h-4 w-4" />
              View Reports
            </Link>
          </Button>
        </div>
      </div>

      {/* Sales and Commission Chart */}
      {isMonthlySalesLoading ? (
        <SalesCommissionChartSkeleton
          title="Monthly Sales & Commission"
          description="View of sales and commission data"
          timeRangeSelector={true}
        />
      ) : (
        <SalesCommissionChart
          data={monthlySalesData?.data || []}
          allTimeData={monthlySalesData?.allTimeData || []}
          title="Monthly Sales & Commission"
          description="View of sales and commission data"
          chartType="area"
          timeRangeSelector={true}
        />
      )}

      <Tabs defaultValue="overview" className="space-y-4 mt-8">
        <TabsList>
          <TabsTrigger value="overview">Overview</TabsTrigger>
          <TabsTrigger value="analytics">Analytics</TabsTrigger>
          <TabsTrigger value="inventory">Inventory</TabsTrigger>
          <TabsTrigger value="team">Team</TabsTrigger>
        </TabsList>

        <TabsContent value="overview" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            {/* Total Revenue Card */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Total Revenue
                </CardTitle>
                <DollarSign className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-32" />
                    <Skeleton className="h-4 w-40 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {formatCurrency(summaryData?.totalRevenue || 0)}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      {summaryData?.revenueChangePercentage &&
                      summaryData.revenueChangePercentage > 0
                        ? "+"
                        : ""}
                      {summaryData?.revenueChangePercentage?.toFixed(1)}% from
                      last month
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            {/* Sales Count Card */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Sales</CardTitle>
                <ShoppingCart className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-24 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {summaryData?.totalSales || 0}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      {summaryData?.salesChangePercentage &&
                      summaryData.salesChangePercentage > 0
                        ? "+"
                        : ""}
                      {summaryData?.salesChangePercentage?.toFixed(1)}% from
                      last month
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            {/* Active Salespersons Card */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Active Salespersons
                </CardTitle>
                <Users className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-24 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {summaryData?.activeSalespersons || 0}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      Full-time team members
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            {/* Inventory Alerts Card */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Inventory Alerts
                </CardTitle>
                <AlertTriangle className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-40 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {summaryData?.inventoryAlerts || 0}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      {summaryData?.outOfStockCount || 0} out of stock,{" "}
                      {summaryData?.lowStockCount || 0} low stock
                    </p>
                  </>
                )}
              </CardContent>
            </Card>
          </div>

          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7">
            {/* Recent Sales Card */}
            <Card className="col-span-4">
              <CardHeader>
                <CardTitle>Recent Sales</CardTitle>
                <CardDescription>
                  The most recent sales transactions.
                </CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {isRecentSalesLoading ? (
                    // Skeleton loading state for recent sales
                    Array(5)
                      .fill(0)
                      .map((_, index) => (
                        <div key={index} className="flex items-center">
                          <div className="space-y-2">
                            <Skeleton className="h-4 w-36" />
                            <Skeleton className="h-3 w-48" />
                          </div>
                          <Skeleton className="h-4 w-20 ml-auto" />
                        </div>
                      ))
                  ) : recentSales && recentSales.length > 0 ? (
                    // Actual data
                    recentSales.map((sale: RecentSale) => (
                      <div key={sale.id} className="flex items-center">
                        <div className="space-y-1">
                          <div className="text-sm font-medium">
                            {sale.productName}
                          </div>
                          <div className="text-sm text-muted-foreground">
                            {sale.salespersonName} • {sale.customerName}
                          </div>
                        </div>
                        <div className="ml-auto font-medium">
                          {formatCurrency(sale.salePrice)}
                        </div>
                      </div>
                    ))
                  ) : (
                    // No sales found
                    <p className="text-center py-4 text-muted-foreground">
                      No recent sales found.
                    </p>
                  )}
                </div>
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/sales">View All Sales</Link>
                </Button>
              </CardFooter>
            </Card>

            {/* Inventory Alerts Card */}
            <Card className="col-span-3">
              <CardHeader>
                <CardTitle>Inventory Alerts</CardTitle>
                <CardDescription>Products that need attention.</CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {isInventoryAlertsLoading ? (
                    // Skeleton loading state for inventory alerts
                    Array(4)
                      .fill(0)
                      .map((_, index) => (
                        <div key={index} className="flex items-center">
                          <div className="space-y-2">
                            <Skeleton className="h-4 w-32" />
                            <Skeleton className="h-3 w-24" />
                          </div>
                          <Skeleton className="h-6 w-24 ml-auto rounded-full" />
                        </div>
                      ))
                  ) : (
                    <>
                      {/* Out of stock products */}
                      {inventoryAlerts?.outOfStock?.map(
                        (product: {
                          id: number;
                          name: string;
                          quantityOnHand: number;
                          reorderPoint: number;
                        }) => (
                          <div key={product.id} className="flex items-center">
                            <div className="space-y-1">
                              <p className="text-sm font-medium leading-none">
                                {product.name}
                              </p>
                              <p className="text-sm text-muted-foreground">
                                {product.quantityOnHand} units remaining
                                (Reorder point: {product.reorderPoint})
                              </p>
                            </div>
                            <Badge variant="destructive" className="ml-auto">
                              Out of Stock
                            </Badge>
                          </div>
                        )
                      )}

                      {/* Low stock products, sorted by quantity (lowest first) */}
                      {inventoryAlerts?.lowStock
                        ?.sort(
                          (
                            a: { quantityOnHand: number },
                            b: { quantityOnHand: number }
                          ) => a.quantityOnHand - b.quantityOnHand
                        )
                        .map(
                          (product: {
                            id: number;
                            name: string;
                            quantityOnHand: number;
                            reorderPoint: number;
                          }) => (
                            <div key={product.id} className="flex items-center">
                              <div className="space-y-1">
                                <p className="text-sm font-medium leading-none">
                                  {product.name}
                                </p>
                                <p className="text-sm text-muted-foreground">
                                  {product.quantityOnHand} units remaining
                                  (Reorder point: {product.reorderPoint})
                                </p>
                              </div>
                              <Badge variant="outline" className="ml-auto">
                                Low Stock
                              </Badge>
                            </div>
                          )
                        )}

                      {/* No alerts message */}
                      {!inventoryAlerts?.outOfStock?.length &&
                        !inventoryAlerts?.lowStock?.length && (
                          <p className="text-center py-4 text-muted-foreground">
                            No inventory alerts found.
                          </p>
                        )}
                    </>
                  )}
                </div>
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/products">Manage Inventory</Link>
                </Button>
              </CardFooter>
            </Card>
          </div>
        </TabsContent>

        <TabsContent value="analytics" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
            <Card className="col-span-2">
              <CardHeader>
                <CardTitle>Sales Performance</CardTitle>
                <CardDescription>
                  Monthly sales performance for the current quarter.
                </CardDescription>
              </CardHeader>
              <CardContent>
                {isMonthlySalesLoading ? (
                  <div className="aspect-auto h-[300px] w-full">
                    <Skeleton className="h-full w-full" />
                  </div>
                ) : (
                  <SalesCommissionChart
                    data={monthlySalesData?.data?.slice(-3) || []}
                    allTimeData={monthlySalesData?.allTimeData || []}
                    title=""
                    description=""
                    chartType="bar"
                  />
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Top Products</CardTitle>
                <CardDescription>
                  Best selling products this month.
                </CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {isProductPerformanceLoading
                    ? // Skeleton loading state for product performance
                      Array(5)
                        .fill(0)
                        .map((_, index) => (
                          <div key={index} className="space-y-2">
                            <div className="flex items-center justify-between">
                              <Skeleton className="h-4 w-32" />
                              <Skeleton className="h-4 w-12" />
                            </div>
                            <Skeleton className="h-2 w-full" />
                          </div>
                        ))
                    : // Actual product performance data
                      productPerformance?.map((product) => (
                        <div key={product.id} className="space-y-2">
                          <div className="flex items-center justify-between">
                            <div className="text-sm font-medium">
                              {product.name}
                            </div>
                            <div className="text-sm text-muted-foreground">
                              {formatCurrency(product.revenue)} revenue
                            </div>
                          </div>
                          <Progress value={product.percentage} />
                        </div>
                      ))}
                </div>
              </CardContent>
            </Card>
          </div>

          <Card>
            <CardHeader>
              <CardTitle>Quarterly Targets</CardTitle>
              <CardDescription>
                Progress towards quarterly sales targets.
              </CardDescription>
            </CardHeader>
            <CardContent>
              <div className="grid gap-6 md:grid-cols-3">
                {isTopSalespersonsLoading
                  ? Array.from({ length: 3 }).map((_, index) => (
                      <div key={index} className="space-y-2">
                        <div className="flex items-center gap-4">
                          <Skeleton className="h-8 w-8 rounded-full" />
                          <div className="space-y-1">
                            <Skeleton className="h-4 w-24" />
                            <Skeleton className="h-3 w-32" />
                          </div>
                        </div>
                        <Skeleton className="h-2 w-full" />
                      </div>
                    ))
                  : topSalespersons?.map((person) => (
                      <div key={person.id} className="space-y-2">
                        <div className="flex items-center gap-4">
                          <Avatar className="h-8 w-8">
                            <AvatarImage
                              src={person.avatar}
                              alt={`${person.firstName} ${person.lastName}`}
                            />
                            <AvatarFallback>
                              {person.firstName[0]}
                              {person.lastName[0]}
                            </AvatarFallback>
                          </Avatar>
                          <div className="space-y-1">
                            <div className="text-sm font-medium">
                              {person.firstName} {person.lastName}
                            </div>
                            <div className="text-sm text-muted-foreground">
                              {formatCurrency(person.totalRevenue)} /{" "}
                              {formatCurrency(person.target)}
                            </div>
                          </div>
                          <div className="ml-auto font-medium">
                            {Math.round(
                              (person.totalRevenue / person.target) * 100
                            )}
                            %
                          </div>
                        </div>
                        <Progress
                          value={(person.totalRevenue / person.target) * 100}
                          className="h-2"
                        />
                      </div>
                    ))}
              </div>
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="inventory" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Total Products
                </CardTitle>
                <Package className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-24 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold"></div>
                    <p className="text-xs text-muted-foreground">
                      Across various categories
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Out of Stock
                </CardTitle>
                <AlertTriangle className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-32 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {summaryData?.outOfStockCount || 0}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      Requires immediate attention
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Low Stock</CardTitle>
                <AlertTriangle className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-32 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {summaryData?.lowStockCount || 0}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      Below reorder threshold
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Inventory Value
                </CardTitle>
                <DollarSign className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-32" />
                    <Skeleton className="h-4 w-40 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {formatCurrency(summaryData?.inventoryValue || 0)}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      Total value of current inventory
                    </p>
                  </>
                )}
              </CardContent>
            </Card>
          </div>

          <div className="grid gap-4 md:grid-cols-2">
            <Card>
              <CardHeader>
                <CardTitle>Inventory by Category</CardTitle>
                <CardDescription>
                  Distribution of products by category.
                </CardDescription>
              </CardHeader>
              <CardContent className="h-[300px] flex items-center justify-center">
                {isSummaryLoading ? (
                  <Skeleton className="h-full w-full" />
                ) : (
                  <div className="text-center text-muted-foreground">
                    <Package className="mx-auto h-12 w-12 mb-2" />
                    <p>Inventory chart would be displayed here</p>
                    <p className="text-sm">
                      Using a charting library like Recharts
                    </p>
                  </div>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Inventory Alerts</CardTitle>
                <CardDescription>Products that need attention.</CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {isInventoryAlertsLoading ? (
                    // Skeleton loading state for inventory alerts
                    Array(4)
                      .fill(0)
                      .map((_, index) => (
                        <div key={index} className="flex items-center">
                          <div className="space-y-2">
                            <Skeleton className="h-4 w-32" />
                            <Skeleton className="h-3 w-24" />
                          </div>
                          <Skeleton className="h-6 w-24 ml-auto rounded-full" />
                        </div>
                      ))
                  ) : (
                    <>
                      {/* Out of stock products */}
                      {inventoryAlerts?.outOfStock?.map(
                        (product: {
                          id: number;
                          name: string;
                          quantityOnHand: number;
                          reorderPoint: number;
                        }) => (
                          <div key={product.id} className="flex items-center">
                            <div className="space-y-1">
                              <p className="text-sm font-medium leading-none">
                                {product.name}
                              </p>
                              <p className="text-sm text-muted-foreground">
                                {product.quantityOnHand} units remaining
                                (Reorder point: {product.reorderPoint})
                              </p>
                            </div>
                            <Badge variant="destructive" className="ml-auto">
                              Out of Stock
                            </Badge>
                          </div>
                        )
                      )}

                      {/* Low stock products, sorted by quantity (lowest first) */}
                      {inventoryAlerts?.lowStock
                        ?.sort(
                          (
                            a: { quantityOnHand: number },
                            b: { quantityOnHand: number }
                          ) => a.quantityOnHand - b.quantityOnHand
                        )
                        .map(
                          (product: {
                            id: number;
                            name: string;
                            quantityOnHand: number;
                            reorderPoint: number;
                          }) => (
                            <div key={product.id} className="flex items-center">
                              <div className="space-y-1">
                                <p className="text-sm font-medium leading-none">
                                  {product.name}
                                </p>
                                <p className="text-sm text-muted-foreground">
                                  {product.quantityOnHand} units remaining
                                  (Reorder point: {product.reorderPoint})
                                </p>
                              </div>
                              <Badge variant="outline" className="ml-auto">
                                Low Stock
                              </Badge>
                            </div>
                          )
                        )}

                      {/* No alerts message */}
                      {!inventoryAlerts?.outOfStock?.length &&
                        !inventoryAlerts?.lowStock?.length && (
                          <p className="text-center py-4 text-muted-foreground">
                            No inventory alerts found.
                          </p>
                        )}
                    </>
                  )}
                </div>
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/products">Manage Inventory</Link>
                </Button>
              </CardFooter>
            </Card>
          </div>
        </TabsContent>

        <TabsContent value="team" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Active Salespersons
                </CardTitle>
                <Users className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isSummaryLoading ? (
                  <>
                    <Skeleton className="h-8 w-16" />
                    <Skeleton className="h-4 w-32 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {summaryData?.activeSalespersons || 0}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      Full-time team members
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Top Performer
                </CardTitle>
                <TrendingUp className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isTopSalespersonsLoading ? (
                  <>
                    <Skeleton className="h-8 w-40" />
                    <Skeleton className="h-4 w-32 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {topSalespersons && topSalespersons.length > 0
                        ? topSalespersons[0].firstName +
                          " " +
                          topSalespersons[0].lastName
                        : "None"}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      {formatCurrency(
                        topSalespersons && topSalespersons.length > 0
                          ? topSalespersons[0].totalRevenue
                          : 0
                      )}{" "}
                      in sales this quarter
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Average Sales
                </CardTitle>
                <ShoppingCart className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                {isTopSalespersonsLoading ? (
                  <>
                    <Skeleton className="h-8 w-32" />
                    <Skeleton className="h-4 w-40 mt-1" />
                  </>
                ) : (
                  <>
                    <div className="text-2xl font-bold">
                      {formatCurrency(
                        topSalespersons && topSalespersons.length > 0
                          ? topSalespersons.reduce(
                              (sum, person) => sum + person.totalRevenue,
                              0
                            ) / topSalespersons.length
                          : 0
                      )}
                    </div>
                    <p className="text-xs text-muted-foreground">
                      Per salesperson this quarter
                    </p>
                  </>
                )}
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Next Review
                </CardTitle>
                <Calendar className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">June 15</div>
                <p className="text-xs text-muted-foreground">
                  Quarterly performance reviews
                </p>
              </CardContent>
            </Card>
          </div>

          <Card>
            <CardHeader>
              <CardTitle>Team Performance</CardTitle>
              <CardDescription>
                Sales performance by team member.
              </CardDescription>
            </CardHeader>
            <CardContent>
              <div className="space-y-8">
                {isTopSalespersonsLoading
                  ? // Skeleton loading state for team performance
                    Array(3)
                      .fill(0)
                      .map((_, index) => (
                        <div key={index} className="space-y-2">
                          <div className="flex items-center">
                            <Skeleton className="h-9 w-9 rounded-full" />
                            <div className="ml-4 space-y-1">
                              <Skeleton className="h-4 w-28" />
                              <Skeleton className="h-3 w-36" />
                            </div>
                            <Skeleton className="h-4 w-12 ml-auto" />
                          </div>
                          <Skeleton className="h-2 w-full" />
                        </div>
                      ))
                  : // Actual team performance data
                    topSalespersons?.map((person: TopSalesperson) => (
                      <div key={person.id} className="space-y-2">
                        <div className="flex items-center">
                          <Avatar className="h-9 w-9">
                            <AvatarFallback>{person.avatar}</AvatarFallback>
                          </Avatar>
                          <div className="ml-4 space-y-1">
                            <p className="text-sm font-medium leading-none">
                              {person.firstName} {person.lastName}
                            </p>
                            <p className="text-sm text-muted-foreground">
                              {formatCurrency(person.totalRevenue)} revenue
                            </p>
                          </div>
                        </div>
                        <Progress
                          value={(person.totalRevenue / person.target) * 100}
                          className="h-2"
                        />
                      </div>
                    ))}
              </div>
            </CardContent>
            <CardFooter>
              <Button variant="outline" asChild className="w-full">
                <Link to="/salespersons">View All Team Members</Link>
              </Button>
            </CardFooter>
          </Card>
        </TabsContent>
      </Tabs>
    </div>
  );
}
