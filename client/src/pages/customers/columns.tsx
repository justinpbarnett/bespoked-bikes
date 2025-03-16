"use client"

import { ColumnDef } from "@tanstack/react-table"
import { Customer } from "@/types/index"
import { DataTableColumnHeader } from "@/components/ui/data-table-column-header"
import { format } from "date-fns"

export const columns: ColumnDef<Customer>[] = [
  {
    id: "name",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Name" />
    ),
    accessorFn: (row) => `${row.firstName} ${row.lastName}`,
    cell: ({ row }) => {
      return <div className="font-medium">{row.getValue("name")}</div>
    },
  },
  {
    accessorKey: "address",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Address" />
    ),
  },
  {
    accessorKey: "phone",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Phone" />
    ),
  },
  {
    accessorKey: "startDate",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Start Date" />
    ),
    cell: ({ row }) => {
      const date = row.getValue("startDate") as string
      const formatted = format(new Date(date), "MMM d, yyyy")
      return <div>{formatted}</div>
    },
  },
]