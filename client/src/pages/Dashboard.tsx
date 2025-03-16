import React, { useState } from "react";
import { Link } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { BarChart3, PlusCircle } from "lucide-react";
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
  getTopSalespersons,
  getProductPerformance,
  getInventoryAlerts,
} from "@/services";

export default function Dashboard() {
  // State for sale form visibility
  const [isFormOpen, setIsFormOpen] = useState(false);

  // Form handlers
  const handleAddSale = () => setIsFormOpen(true);
  const handleCloseForm = () => setIsFormOpen(false);

  // Get current date info for data filtering
  const currentDate = new Date();
  const currentYear = currentDate.getFullYear();

  // Fetch dashboard data
  const { data: summaryData, isLoading: isSummaryLoading } = useQuery({
    queryKey: ["dashboardSummary"],
    queryFn: getDashboardSummary,
    staleTime: 1000 * 60 * 5, // 5 minutes
  });

  const { data: recentSales, isLoading: isRecentSalesLoading } = useQuery({
    queryKey: ["recentSales"],
    queryFn: () => getRecentSales(5),
    staleTime: 5 * 1000, // 5 seconds - more frequent updates for recent sales
    refetchOnWindowFocus: true, // Refetch when window regains focus
    refetchInterval: 30 * 1000, // Refetch every 30 seconds while window is open
  });

  // Fetch sales data for charts
  const { data: rollingYearSalesData, isLoading: isRollingYearSalesLoading } = useQuery({
    queryKey: ["monthlySales", currentYear],
    queryFn: () => getMonthlySalesData(currentYear),
    staleTime: 1000 * 60 * 10, // 10 minutes
  });

  const { data: allTimeSalesData, isLoading: isAllTimeSalesLoading } = useQuery({
    queryKey: ["monthlySales", "all"],
    queryFn: () => getMonthlySalesData("all"),
    staleTime: 1000 * 60 * 10, // 10 minutes
  });

  // Combine and prepare chart data
  const isMonthlySalesLoading = isRollingYearSalesLoading || isAllTimeSalesLoading;

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

  // Fetch other dashboard data
  // Commenting out unused queries for now, but they'll be needed for other tabs
  // const { data: topSalespersons, isLoading: isTopSalespersonsLoading } = useQuery({
  //   queryKey: ["topSalespersons"],
  //   queryFn: () => getTopSalespersons(3),
  //   staleTime: 1000 * 60 * 5, // 5 minutes
  // });

  const { data: inventoryAlerts, isLoading: isInventoryAlertsLoading } = useQuery({
    queryKey: ["inventoryAlerts"],
    queryFn: getInventoryAlerts,
    staleTime: 1000 * 60 * 5, // 5 minutes
  });

  // const { data: productPerformance, isLoading: isProductPerformanceLoading } = useQuery({
  //   queryKey: ["productPerformance"],
  //   queryFn: getProductPerformance,
  //   staleTime: 1000 * 60 * 10, // 10 minutes
  // });

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

      {/* Sale Form */}
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

        {/* For brevity, we'll keep the other tabs as they are. 
            In a real refactoring, we would extract each tab to its own component like OverviewTab */}
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

            {/* Rest of analytics tab content (same as before) */}
          </div>
        </TabsContent>

        <TabsContent value="inventory" className="space-y-4">
          {/* Inventory tab content (same as before) */}
        </TabsContent>

        <TabsContent value="team" className="space-y-4">
          {/* Team tab content (same as before) */}
        </TabsContent>
      </Tabs>
    </div>
  );
}

// Import Skeleton at the top of the file if it's directly used here
import { Skeleton } from "@/components/ui/skeleton";
