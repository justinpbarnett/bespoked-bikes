"use client"

import { ColumnDef } from "@tanstack/react-table"
import { Sale } from "@/types/index"
import { DataTableColumnHeader } from "@/components/ui/data-table-column-header"
import { format } from "date-fns"
import { Badge } from "@/components/ui/badge"

export const columns: ColumnDef<Sale>[] = [
  {
    accessorKey: "productName",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Product" />
    ),
    cell: ({ row }) => {
      return <div className="font-medium">{row.getValue("productName")}</div>
    },
  },
  {
    id: "customer",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Customer" />
    ),
    accessorFn: (row) => `${row.customerFirstName} ${row.customerLastName}`,
    cell: ({ row }) => {
      return <div>{row.getValue("customer")}</div>
    },
  },
  {
    id: "salesperson",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Salesperson" />
    ),
    accessorFn: (row) => `${row.salespersonFirstName} ${row.salespersonLastName}`,
    cell: ({ row }) => {
      return <div>{row.getValue("salesperson")}</div>
    },
  },
  {
    accessorKey: "salesDate",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Date" />
    ),
    cell: ({ row }) => {
      const dateValue = row.getValue("salesDate") as string
      
      if (!dateValue) {
        return <div>No date</div>
      }
      
      try {
        // Parse the date using the JavaScript Date constructor
        const parsedDate = new Date(dateValue)
        
        // Check if the date is valid
        if (!isNaN(parsedDate.getTime())) {
          // Format the date using date-fns
          return <div>{format(parsedDate, "MMM d, yyyy")}</div>
        }
        
        // If parsing fails, just return the raw value
        return <div>{dateValue}</div>
      } catch (error) {
        // If any error occurs, return the original string
        return <div>{dateValue}</div>
      }
    },
  },
  {
    accessorKey: "originalPrice",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Original Price" />
    ),
    cell: ({ row }) => {
      const price = (row.getValue("originalPrice") as number) || row.original.salePrice
      const formatted = new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(price)
      return <div className="text-right font-medium">{formatted}</div>
    },
  },
  {
    id: "discount",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Discount" />
    ),
    cell: ({ row }) => {
      const discount = row.original.appliedDiscountPercentage
      const discountCode = row.original.appliedDiscountCode
      
      if (discount > 0) {
        return (
          <Badge variant="success" className="whitespace-nowrap">
            {discount}%
            {discountCode && (
              <span className="ml-1 text-xs font-normal">
                ({discountCode})
              </span>
            )}
          </Badge>
        )
      }
      
      return <div>None</div>
    },
  },
  {
    accessorKey: "salePrice",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Sale Price" />
    ),
    cell: ({ row }) => {
      const price = parseFloat(row.getValue("salePrice"))
      const formatted = new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(price)
      return <div className="text-right font-medium">{formatted}</div>
    },
  },
  {
    accessorKey: "commissionAmount",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Commission" />
    ),
    cell: ({ row }) => {
      const commission = parseFloat(row.getValue("commissionAmount"))
      const formatted = new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(commission)
      return <div className="text-right font-medium">{formatted}</div>
    },
  },
]