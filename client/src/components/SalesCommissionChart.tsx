"use client"

import * as React from "react"
import { Area, AreaChart, Bar, BarChart, CartesianGrid, XAxis, YAxis } from "recharts"
import { ChevronDown } from "lucide-react"

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import {
  type ChartConfig,
  ChartContainer,
  ChartLegend,
  ChartLegendContent,
  ChartTooltip,
  ChartTooltipContent,
} from "@/components/ui/chart"
import { 
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger
} from "@/components/ui/dropdown-menu"

interface SalesCommissionData {
  label: string
  sales: number
  commission: number
}

interface SalesCommissionChartProps {
  data: SalesCommissionData[]
  allTimeData?: SalesCommissionData[]
  title: string
  description?: string
  chartType?: "area" | "bar"
  timeRangeSelector?: boolean
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
} satisfies ChartConfig

export function SalesCommissionChart({
  data,
  allTimeData = [],
  title,
  description,
  chartType = "area",
  timeRangeSelector = false,
}: SalesCommissionChartProps) {
  const [timeRange, setTimeRange] = React.useState("12m") // Default to last 12 months view

  // Filter data based on time range if needed
  const filteredData = React.useMemo(() => {
    if (!timeRangeSelector) return data

    // Current month index (0-based, where 0 is January)
    const today = new Date()
    const currentMonth = today.getMonth()
    
    // Show all available data when "all" is selected
    if (timeRange === "all") {
      // Use all-time data which includes all months from all years
      return allTimeData && allTimeData.length > 0 ? allTimeData : data
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
    
    return data
  }, [data, allTimeData, timeRange, timeRangeSelector])

  // Format currency for tooltip
  const formatCurrency = (value: number) => {
    return new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
      minimumFractionDigits: 0,
      maximumFractionDigits: 0,
    }).format(value)
  }

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
              <Button variant="outline" className="w-[160px] justify-between sm:ml-auto">
                {timeRange === "all" ? "All time" : 
                 timeRange === "12m" ? "Last 12 months" : 
                 timeRange === "3m" ? "Last 3 months" : "Select range"}
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
        <ChartContainer config={chartConfig} className="aspect-auto h-[300px] w-full">
          {chartType === "area" ? (
            <AreaChart data={filteredData}>
              <defs>
                <linearGradient id="fillSales" x1="0" y1="0" x2="0" y2="1">
                  <stop offset="5%" stopColor="var(--color-sales)" stopOpacity={0.8} />
                  <stop offset="95%" stopColor="var(--color-sales)" stopOpacity={0.1} />
                </linearGradient>
                <linearGradient id="fillCommission" x1="0" y1="0" x2="0" y2="1">
                  <stop offset="5%" stopColor="var(--color-commission)" stopOpacity={0.8} />
                  <stop offset="95%" stopColor="var(--color-commission)" stopOpacity={0.1} />
                </linearGradient>
              </defs>
              <CartesianGrid vertical={false} />
              <XAxis dataKey="label" tickLine={false} axisLine={false} tickMargin={8} minTickGap={32} />
              <YAxis
                tickLine={false}
                axisLine={false}
                tickMargin={8}
                tickFormatter={(value) => formatCurrency(value)}
              />
              <ChartTooltip
                cursor={false}
                content={
                  <ChartTooltipContent valueFormatter={(value) => formatCurrency(Number(value))} indicator="dot" />
                }
              />
              <Area dataKey="sales" type="monotone" fill="url(#fillSales)" stroke="var(--color-sales)" stackId="a" />
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
              <XAxis dataKey="label" tickLine={false} axisLine={false} tickMargin={8} />
              <YAxis
                tickLine={false}
                axisLine={false}
                tickMargin={8}
                tickFormatter={(value) => formatCurrency(value)}
              />
              <ChartTooltip
                cursor={false}
                content={
                  <ChartTooltipContent valueFormatter={(value) => formatCurrency(Number(value))} indicator="line" />
                }
              />
              <Bar dataKey="sales" fill="var(--color-sales)" radius={[4, 4, 0, 0]} barSize={20} />
              <Bar dataKey="commission" fill="var(--color-commission)" radius={[4, 4, 0, 0]} barSize={20} />
              <ChartLegend content={<ChartLegendContent />} />
            </BarChart>
          )}
        </ChartContainer>
      </CardContent>
    </Card>
  )
}