import React, { useState } from "react";
import { Link } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
  CardFooter,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import {
  BarChart3,
  PlusCircle,
  ShoppingCart,
  AlertTriangle,
  Users,
  DollarSign,
} from "lucide-react";
import { SalesCommissionChart } from "@/components/SalesCommissionChart";
import { SalesCommissionChartSkeleton } from "@/components/SalesCommissionChartSkeleton";
import SaleForm from "@/forms/SaleForm";
import { formatCurrency } from "@/lib/format";
import PageHeader from "@/components/common/PageHeader";
import OverviewTab from "@/components/dashboard/OverviewTab";
import {
  getDashboardSummary,
  getRecentSales,
  getMonthlySalesData,
  getInventoryAlerts,
} from "@/services";
import InventoryAlertsList from "@/components/dashboard/InventoryAlertsList";
import MetricsGrid from "@/components/dashboard/MetricsGrid";
import RecentSalesList from "@/components/dashboard/RecentSalesList";
import { Skeleton } from "@/components/ui/skeleton";

export default function Dashboard() {
  const [isFormOpen, setIsFormOpen] = useState(false);

  const handleAddSale = () => setIsFormOpen(true);
  const handleCloseForm = () => setIsFormOpen(false);

  const currentDate = new Date();
  const currentYear = currentDate.getFullYear();

  const { data: summaryData, isLoading: isSummaryLoading } = useQuery({
    queryKey: ["dashboardSummary"],
    queryFn: getDashboardSummary,
    staleTime: 1000 * 60 * 5, // 5 minutes
  });

  const { data: recentSales, isLoading: isRecentSalesLoading } = useQuery({
    queryKey: ["recentSales"],
    queryFn: () => getRecentSales(5),
    staleTime: 5 * 1000,
    refetchOnWindowFocus: true,
    refetchInterval: 30 * 1000,
  });

  const { data: rollingYearSalesData, isLoading: isRollingYearSalesLoading } =
    useQuery({
      queryKey: ["monthlySales", currentYear],
      queryFn: () => getMonthlySalesData(currentYear),
      staleTime: 1000 * 60 * 10, // 10 minutes
    });

  const { data: allTimeSalesData, isLoading: isAllTimeSalesLoading } = useQuery(
    {
      queryKey: ["monthlySales", "all"],
      queryFn: () => getMonthlySalesData("all"),
      staleTime: 1000 * 60 * 10, // 10 minutes
    }
  );

  const isMonthlySalesLoading =
    isRollingYearSalesLoading || isAllTimeSalesLoading;

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

  const { data: inventoryAlerts, isLoading: isInventoryAlertsLoading } =
    useQuery({
      queryKey: ["inventoryAlerts"],
      queryFn: getInventoryAlerts,
      staleTime: 1000 * 60 * 5, // 5 minutes
    });

  return (
    <div className="container mx-auto py-10">
      <PageHeader
        title="Dashboard"
        description="Welcome back, Manager. Here's an overview of your bike shop."
        actions={
          <>
            <Button onClick={handleAddSale}>
              <PlusCircle className="mr-2 h-4 w-4" />
              Record Sale
            </Button>
            <Button variant="outline" asChild>
              <Link to="/reports">
                <BarChart3 className="mr-2 h-4 w-4" />
                View Reports
              </Link>
            </Button>
          </>
        }
      />

      {isFormOpen && <SaleForm onClose={handleCloseForm} />}

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

        <TabsContent value="overview">
          <OverviewTab
            summaryData={summaryData}
            recentSales={recentSales}
            inventoryAlerts={inventoryAlerts}
            isSummaryLoading={isSummaryLoading}
            isRecentSalesLoading={isRecentSalesLoading}
            isInventoryAlertsLoading={isInventoryAlertsLoading}
            formatCurrency={formatCurrency}
          />
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
          </div>
        </TabsContent>

        <TabsContent value="inventory" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7">
            {/* Inventory Overview Card */}
            <Card className="col-span-4">
              <CardHeader>
                <CardTitle>Inventory Overview</CardTitle>
                <CardDescription>
                  Current inventory status and alerts.
                </CardDescription>
              </CardHeader>
              <CardContent>
                <InventoryAlertsList
                  inventoryAlerts={inventoryAlerts}
                  isLoading={isInventoryAlertsLoading}
                />
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/products">Manage Inventory</Link>
                </Button>
              </CardFooter>
            </Card>

            {/* Inventory Metrics Card */}
            <Card className="col-span-3">
              <CardHeader>
                <CardTitle>Inventory Metrics</CardTitle>
                <CardDescription>Key inventory statistics.</CardDescription>
              </CardHeader>
              <CardContent>
                <MetricsGrid
                  metrics={[
                    {
                      title: "Total Products",
                      value: summaryData?.totalProducts || 0,
                      icon: <ShoppingCart />,
                      changeText: "Active products",
                    },
                    {
                      title: "Out of Stock",
                      value: summaryData?.outOfStockCount || 0,
                      icon: <AlertTriangle />,
                      changeText: "Items needing restock",
                    },
                    {
                      title: "Low Stock",
                      value: summaryData?.lowStockCount || 0,
                      icon: <AlertTriangle />,
                      changeText: "Items below threshold",
                    },
                  ]}
                  isLoading={isSummaryLoading}
                  columns={2}
                />
              </CardContent>
            </Card>
          </div>
        </TabsContent>

        <TabsContent value="team" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7">
            {/* Team Performance Card */}
            <Card className="col-span-4">
              <CardHeader>
                <CardTitle>Team Performance</CardTitle>
                <CardDescription>
                  Sales team performance metrics and achievements.
                </CardDescription>
              </CardHeader>
              <CardContent>
                <MetricsGrid
                  metrics={[
                    {
                      title: "Active Salespersons",
                      value: summaryData?.activeSalespersons || 0,
                      icon: <Users />,
                      changeText: "Full-time team members",
                    },
                    {
                      title: "Total Sales",
                      value: summaryData?.totalSales || 0,
                      icon: <ShoppingCart />,
                      change: summaryData?.salesChangePercentage,
                      changeText: "from last month",
                    },
                    {
                      title: "Total Revenue",
                      value: formatCurrency(summaryData?.totalRevenue || 0),
                      icon: <DollarSign />,
                      change: summaryData?.revenueChangePercentage,
                      changeText: "from last month",
                    },
                  ]}
                  isLoading={isSummaryLoading}
                  columns={2}
                />
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/salespersons">Manage Team</Link>
                </Button>
              </CardFooter>
            </Card>

            {/* Recent Team Activity Card */}
            <Card className="col-span-3">
              <CardHeader>
                <CardTitle>Recent Team Activity</CardTitle>
                <CardDescription>
                  Latest sales and achievements.
                </CardDescription>
              </CardHeader>
              <CardContent>
                <RecentSalesList
                  recentSales={recentSales}
                  isLoading={isRecentSalesLoading}
                  formatCurrency={formatCurrency}
                />
              </CardContent>
            </Card>
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
}
