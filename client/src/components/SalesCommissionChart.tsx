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
  title,
  description,
  chartType = "area",
  timeRangeSelector = false,
}: SalesCommissionChartProps) {
  const [timeRange, setTimeRange] = React.useState("all")

  // Filter data based on time range if needed
  const filteredData = React.useMemo(() => {
    if (timeRange === "all" || !timeRangeSelector) return data

    // In a real app, you would implement actual filtering logic here
    // For this demo, we'll just return a subset of the data
    const count =
      timeRange === "3m" ? Math.min(3, data.length) : timeRange === "6m" ? Math.min(6, data.length) : data.length

    return data.slice(0, count)
  }, [data, timeRange, timeRangeSelector])

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
                 timeRange === "6m" ? "Last 6 months" : 
                 timeRange === "3m" ? "Last 3 months" : "Select range"}
                <ChevronDown className="ml-2 h-4 w-4 opacity-50" />
              </Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent>
              <DropdownMenuItem onClick={() => setTimeRange("all")}>
                All time
              </DropdownMenuItem>
              <DropdownMenuItem onClick={() => setTimeRange("6m")}>
                Last 6 months
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