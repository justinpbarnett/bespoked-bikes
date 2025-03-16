"use client"

import { ColumnDef } from "@tanstack/react-table"
import { Discount } from "@/types/index"
import { DataTableColumnHeader } from "@/components/ui/data-table-column-header"
import { format } from "date-fns"
import { Badge } from "@/components/ui/badge"

export const columns: ColumnDef<Discount>[] = [
  {
    accessorKey: "productName",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Product" />
    ),
    cell: ({ row }) => {
      const isGlobal = row.original.isGlobal
      
      return (
        <div className="font-medium">
          {isGlobal ? (
            <span className="font-semibold text-primary">Global Discount</span>
          ) : (
            row.original.product?.name
          )}
        </div>
      )
    },
  },
  {
    accessorKey: "discountPercentage",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Discount %" />
    ),
    cell: ({ row }) => {
      return <div>{row.getValue("discountPercentage")}%</div>
    },
  },
  {
    accessorKey: "beginDate",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Begin Date" />
    ),
    cell: ({ row }) => {
      const dateValue = row.getValue("beginDate") as string
      
      if (!dateValue) {
        return <div>No date</div>
      }
      
      try {
        const parsedDate = new Date(dateValue)
        
        if (!isNaN(parsedDate.getTime())) {
          return <div>{format(parsedDate, "MMM d, yyyy")}</div>
        }
        
        return <div>{dateValue}</div>
      } catch (error) {
        return <div>{dateValue}</div>
      }
    },
  },
  {
    accessorKey: "endDate",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="End Date" />
    ),
    cell: ({ row }) => {
      const dateValue = row.getValue("endDate") as string
      
      if (!dateValue) {
        return <div>No date</div>
      }
      
      try {
        const parsedDate = new Date(dateValue)
        
        if (!isNaN(parsedDate.getTime())) {
          return <div>{format(parsedDate, "MMM d, yyyy")}</div>
        }
        
        return <div>{dateValue}</div>
      } catch (error) {
        return <div>{dateValue}</div>
      }
    },
  },
  {
    accessorKey: "requiresCode",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Code Required" />
    ),
    cell: ({ row }) => {
      const requiresCode = row.getValue("requiresCode") as boolean
      const discountCode = row.original.discountCode
      
      if (requiresCode) {
        return (
          <Badge variant="warning" className="whitespace-nowrap">
            {discountCode || "Yes"}
          </Badge>
        )
      }
      
      return <span className="text-xs">No</span>
    },
  },
  {
    id: "status",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Status" />
    ),
    cell: ({ row }) => {
      const now = new Date()
      const beginDate = new Date(row.original.beginDate)
      const endDate = new Date(row.original.endDate)
      
      let status = "Upcoming"
      let variant: "default" | "success" | "destructive" = "default" 

      if (now >= beginDate && now <= endDate) {
        status = "Active"
        variant = "success"
      } else if (now > endDate) {
        status = "Expired"
        variant = "destructive"
      }
      
      return <Badge variant={variant}>{status}</Badge>
    },
  },
]