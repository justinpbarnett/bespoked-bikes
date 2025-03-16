"use client"

import { ColumnDef } from "@tanstack/react-table"
import { Salesperson } from "@/types/index"
import { DataTableColumnHeader } from "@/components/ui/data-table-column-header"
import { format } from "date-fns"
import { Button } from "@/components/ui/button"
import { Edit } from "lucide-react"

export const columns: ColumnDef<Salesperson>[] = [
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
  {
    accessorKey: "terminationDate",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Termination Date" />
    ),
    cell: ({ row }) => {
      const date = row.getValue("terminationDate") as string | null
      if (!date) return <div>N/A</div>
      const formatted = format(new Date(date), "MMM d, yyyy")
      return <div>{formatted}</div>
    },
  },
  {
    accessorKey: "manager",
    header: ({ column }) => (
      <DataTableColumnHeader column={column} title="Manager" />
    ),
    cell: ({ row }) => {
      const manager = row.getValue("manager") as string
      return <div>{manager || "N/A"}</div>
    },
  },
  {
    id: "actions",
    cell: ({ row }) => {
      const salesperson = row.original
      
      return (
        <Button
          variant="ghost"
          size="sm"
          onClick={() => {}}
          className="edit-action"
          data-salesperson-id={salesperson.id}
        >
          <Edit className="w-4 h-4" />
        </Button>
      )
    },
  },
]