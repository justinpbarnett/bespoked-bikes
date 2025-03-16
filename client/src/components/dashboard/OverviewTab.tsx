import { Link } from "react-router-dom";
import { DashboardSummary, InventoryAlert, RecentSale } from "@/types/index";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { DollarSign, ShoppingCart, Users, AlertTriangle } from "lucide-react";
import MetricsGrid from "./MetricsGrid";
import RecentSalesList from "./RecentSalesList";
import InventoryAlertsList from "./InventoryAlertsList";

interface OverviewTabProps {
  summaryData?: DashboardSummary;
  recentSales?: RecentSale[];
  inventoryAlerts?: InventoryAlert;
  isSummaryLoading: boolean;
  isRecentSalesLoading: boolean;
  isInventoryAlertsLoading: boolean;
  formatCurrency: (amount: number) => string;
}

export default function OverviewTab({
  summaryData,
  recentSales,
  inventoryAlerts,
  isSummaryLoading,
  isRecentSalesLoading,
  isInventoryAlertsLoading,
  formatCurrency,
}: OverviewTabProps) {
  const metrics = [
    {
      title: "Total Revenue",
      value: formatCurrency(summaryData?.totalRevenue || 0),
      icon: <DollarSign />,
      change: summaryData?.revenueChangePercentage,
      changeText: "from last month",
    },
    {
      title: "Sales",
      value: summaryData?.totalSales || 0,
      icon: <ShoppingCart />,
      change: summaryData?.salesChangePercentage,
      changeText: "from last month",
    },
    {
      title: "Active Salespersons",
      value: summaryData?.activeSalespersons || 0,
      icon: <Users />,
      changeText: "Full-time team members",
    },
    {
      title: "Inventory Alerts",
      value: summaryData?.inventoryAlerts || 0,
      icon: <AlertTriangle />,
      changeText: `${summaryData?.outOfStockCount || 0} out of stock, ${
        summaryData?.lowStockCount || 0
      } low stock`,
    },
  ];

  return (
    <div className="space-y-4">
      <MetricsGrid 
        metrics={metrics}
        isLoading={isSummaryLoading}
      />

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
            <RecentSalesList 
              recentSales={recentSales}
              isLoading={isRecentSalesLoading}
              formatCurrency={formatCurrency}
            />
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
      </div>
    </div>
  );
}