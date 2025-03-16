"use client"

import * as React from "react"

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Skeleton } from "@/components/ui/skeleton"

interface SalesCommissionChartSkeletonProps {
  title: string
  description?: string
  timeRangeSelector?: boolean
}

export function SalesCommissionChartSkeleton({
  title,
  description,
  timeRangeSelector = false,
}: SalesCommissionChartSkeletonProps) {
  return (
    <Card>
      <CardHeader className="flex items-center gap-2 space-y-0 border-b py-5 sm:flex-row">
        <div className="grid flex-1 gap-1 text-center sm:text-left">
          <CardTitle>{title}</CardTitle>
          {description && <CardDescription>{description}</CardDescription>}
        </div>
        {timeRangeSelector && (
          <Skeleton className="h-9 w-[160px]" />
        )}
      </CardHeader>
      <CardContent className="px-2 pt-4 sm:px-6 sm:pt-6">
        <div className="aspect-auto h-[300px] w-full">
          <div className="flex h-full w-full flex-col space-y-4">
            <div className="flex items-center justify-between">
              <Skeleton className="h-4 w-20" />
              <div className="flex space-x-2">
                <Skeleton className="h-4 w-4" />
                <Skeleton className="h-4 w-4" />
              </div>
            </div>
            <Skeleton className="h-[250px] w-full" />
          </div>
        </div>
      </CardContent>
    </Card>
  )
}