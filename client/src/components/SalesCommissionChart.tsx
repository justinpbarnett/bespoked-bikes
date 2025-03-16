"use client";

import * as React from "react";
import {
  Area,
  AreaChart,
  Bar,
  BarChart,
  CartesianGrid,
  XAxis,
  YAxis,
} from "recharts";
import { ChevronDown } from "lucide-react";

import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import {
  type ChartConfig,
  ChartContainer,
  ChartLegend,
  ChartLegendContent,
  ChartTooltip,
} from "@/components/ui/chart";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";

const formatCurrency = (value: number) => {
  return new Intl.NumberFormat("en-US", {
    style: "currency",
    currency: "USD",
    minimumFractionDigits: 0,
    maximumFractionDigits: 0,
  }).format(value);
};

interface SalesCommissionData {
  label: string;
  sales: number;
  commission: number;
}

interface SalesCommissionChartProps {
  data: SalesCommissionData[];
  allTimeData?: SalesCommissionData[];
  title: string;
  description?: string;
  chartType?: "area" | "bar";
  timeRangeSelector?: boolean;
}

const chartConfig = {
  sales: {
    label: "Sales",
    color: "hsl(var(--chart-1))",
  },
  commission: {
    label: "Commission",
    color: "hsl(var(--chart-2))",
  },
} satisfies ChartConfig;

interface ChartTooltipContentProps {
  active?: boolean;
  payload?: Array<{
    value: number | string;
    name: string;
    dataKey: string;
    color: string;
  }>;
}

function ChartTooltipContent({ active, payload }: ChartTooltipContentProps) {
  if (!active || !payload || payload.length === 0) {
    return null;
  }

  const salesData = payload.find((p) => p.dataKey === "sales") as
    | { value: number }
    | undefined;
  const commissionData = payload.find((p) => p.dataKey === "commission") as
    | { value: number }
    | undefined;

  return (
    <div className="rounded-lg border bg-background p-2 shadow-sm">
      {salesData && (
        <div className="flex flex-col">
          <span className="text-[0.70rem] uppercase text-muted-foreground">
            Sales
          </span>
          <span className="font-bold text-muted-foreground">
            {salesData.value !== undefined
              ? formatCurrency(salesData.value)
              : ""}
          </span>
        </div>
      )}
      {commissionData && (
        <div className="flex flex-col">
          <span className="text-[0.70rem] uppercase text-muted-foreground">
            Commission
          </span>
          <span className="font-bold text-muted-foreground">
            {commissionData.value !== undefined
              ? formatCurrency(commissionData.value)
              : ""}
          </span>
        </div>
      )}
    </div>
  );
}

export function SalesCommissionChart({
  data,
  allTimeData = [],
  title,
  description,
  chartType = "area",
  timeRangeSelector = false,
}: SalesCommissionChartProps) {
  const [timeRange, setTimeRange] = React.useState("12m"); // Default to last 12 months view

  // Filter data based on time range if needed
  const filteredData = React.useMemo(() => {
    if (!timeRangeSelector) return data;

    // Show all available data when "all" is selected
    if (timeRange === "all") {
      // Use all-time data which includes all months from all years
      return allTimeData && allTimeData.length > 0 ? allTimeData : data;
    }

    // For the 3-month and 12-month views, we'll use the data from the server
    if ((timeRange === "3m" || timeRange === "12m") && data) {
      // The server already sends the full 12 months in chronological order
      // with current month as the last element (rightmost in chart)

      // For "Last 3 months", show only the most recent 3 months
      // This means the last 3 elements in the array (including current month)
      if (timeRange === "3m") {
        return data.slice(-3);
      }

      // For "Last 12 months", use the full 12-month dataset
      // This shows current month as the rightmost point in the chart
      return data;
    }

    return data;
  }, [data, allTimeData, timeRange, timeRangeSelector]);

  return (
    <Card>
      <CardHeader className="flex items-center gap-2 space-y-0 border-b py-5 sm:flex-row">
        <div className="grid flex-1 gap-1 text-center sm:text-left">
          <CardTitle>{title}</CardTitle>
          {description && <CardDescription>{description}</CardDescription>}
        </div>
        {timeRangeSelector && (
          <DropdownMenu>
            <DropdownMenuTrigger asChild>
              <Button
                variant="outline"
                className="w-[160px] justify-between sm:ml-auto"
              >
                {timeRange === "all"
                  ? "All time"
                  : timeRange === "12m"
                  ? "Last 12 months"
                  : timeRange === "3m"
                  ? "Last 3 months"
                  : "Select range"}
                <ChevronDown className="ml-2 h-4 w-4 opacity-50" />
              </Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent>
              <DropdownMenuItem onClick={() => setTimeRange("all")}>
                All time
              </DropdownMenuItem>
              <DropdownMenuItem onClick={() => setTimeRange("12m")}>
                Last 12 months
              </DropdownMenuItem>
              <DropdownMenuItem onClick={() => setTimeRange("3m")}>
                Last 3 months
              </DropdownMenuItem>
            </DropdownMenuContent>
          </DropdownMenu>
        )}
      </CardHeader>
      <CardContent className="px-2 pt-4 sm:px-6 sm:pt-6">
        <ChartContainer
          config={chartConfig}
          className="aspect-auto h-[300px] w-full"
        >
          {chartType === "area" ? (
            <AreaChart data={filteredData}>
              <defs>
                <linearGradient id="fillSales" x1="0" y1="0" x2="0" y2="1">
                  <stop
                    offset="5%"
                    stopColor="var(--color-sales)"
                    stopOpacity={0.8}
                  />
                  <stop
                    offset="95%"
                    stopColor="var(--color-sales)"
                    stopOpacity={0.1}
                  />
                </linearGradient>
                <linearGradient id="fillCommission" x1="0" y1="0" x2="0" y2="1">
                  <stop
                    offset="5%"
                    stopColor="var(--color-commission)"
                    stopOpacity={0.8}
                  />
                  <stop
                    offset="95%"
                    stopColor="var(--color-commission)"
                    stopOpacity={0.1}
                  />
                </linearGradient>
              </defs>
              <CartesianGrid vertical={false} />
              <XAxis
                dataKey="label"
                tickLine={false}
                axisLine={false}
                tickMargin={8}
                minTickGap={32}
              />
              <YAxis
                tickLine={false}
                axisLine={false}
                tickMargin={8}
                tickFormatter={(value) => formatCurrency(value)}
              />
              <ChartTooltip
                cursor={false}
                content={({ active, payload }) => (
                  <ChartTooltipContent
                    active={active}
                    payload={
                      payload as Array<{
                        value: number;
                        name: string;
                        dataKey: string;
                        color: string;
                      }>
                    }
                  />
                )}
              />
              <Area
                dataKey="sales"
                type="monotone"
                fill="url(#fillSales)"
                stroke="var(--color-sales)"
                stackId="a"
              />
              <Area
                dataKey="commission"
                type="monotone"
                fill="url(#fillCommission)"
                stroke="var(--color-commission)"
                stackId="b"
              />
              <ChartLegend content={<ChartLegendContent />} />
            </AreaChart>
          ) : (
            <BarChart data={filteredData}>
              <CartesianGrid vertical={false} />
              <XAxis
                dataKey="label"
                tickLine={false}
                axisLine={false}
                tickMargin={8}
              />
              <YAxis
                tickLine={false}
                axisLine={false}
                tickMargin={8}
                tickFormatter={(value) => formatCurrency(value)}
              />
              <ChartTooltip
                cursor={false}
                content={({ active, payload }) => (
                  <ChartTooltipContent
                    active={active}
                    payload={
                      payload as Array<{
                        value: number;
                        name: string;
                        dataKey: string;
                        color: string;
                      }>
                    }
                  />
                )}
              />
              <Bar
                dataKey="sales"
                fill="var(--color-sales)"
                radius={[4, 4, 0, 0]}
                barSize={20}
              />
              <Bar
                dataKey="commission"
                fill="var(--color-commission)"
                radius={[4, 4, 0, 0]}
                barSize={20}
              />
              <ChartLegend content={<ChartLegendContent />} />
            </BarChart>
          )}
        </ChartContainer>
      </CardContent>
    </Card>
  );
}
