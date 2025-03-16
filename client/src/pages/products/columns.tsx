"use client"

import { ColumnDef } from "@tanstack/react-table"
import { Button } from "@/components/ui/button"
import { Product } from "@/types/index"
import { Edit } from "lucide-react"
import { DataTableColumnHeader } from "@/components/ui/data-table-column-header"

export const columns: ColumnDef<Product>[] = [
  {
    accessorKey: "name",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Name" />
    ),
    cell: ({ row }) => {
      return <div className="font-medium">{row.getValue("name")}</div>
    },
  },
  {
    accessorKey: "manufacturer",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Manufacturer" />
    ),
  },
  {
    accessorKey: "style",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Style" />
    ),
  },
  {
    accessorKey: "purchasePrice",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Purchase Price" />
    ),
    cell: ({ row }) => {
      const price = parseFloat(row.getValue("purchasePrice"))
      const formatted = new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(price)
      return <div className="text-right font-medium">{formatted}</div>
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
    accessorKey: "quantityOnHand",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Quantity" />
    ),
    cell: ({ row }) => {
      const quantity = parseInt(row.getValue("quantityOnHand"))
      return <div className="text-center">{quantity}</div>
    },
  },
  {
    accessorKey: "commissionPercentage",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Commission %" />
    ),
    cell: ({ row }) => {
      const commission = parseFloat(row.getValue("commissionPercentage"))
      return <div className="text-center">{commission}%</div>
    },
  },
  {
    id: "actions",
    cell: ({ row }) => {
      const product = row.original
      
      return (
        <Button
          variant="ghost"
          size="sm"
          onClick={() => {}}
          className="edit-action"
          data-product-id={product.id}
        >
          <Edit className="w-4 h-4" />
        </Button>
      )
    },
  },
]