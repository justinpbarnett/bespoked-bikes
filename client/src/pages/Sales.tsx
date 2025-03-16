import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getSalesFiltered } from "../services/api";
import { Button } from "../components/ui/button";
import SaleForm from "../forms/SaleForm";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "../components/ui/table";
import { Input } from "../components/ui/input";
import { Label } from "../components/ui/label";
import { Plus, Search } from "lucide-react";
import { format } from "date-fns";

export default function Sales() {
  const [isFormOpen, setIsFormOpen] = useState(false);
  const [dateFilter, setDateFilter] = useState({
    startDate: "",
    endDate: "",
  });

  const {
    data: sales,
    isLoading,
    error,
    refetch,
  } = useQuery({
    queryKey: ["sales", dateFilter.startDate, dateFilter.endDate],
    queryFn: () => getSalesFiltered(dateFilter.startDate, dateFilter.endDate),
  });

  const handleAddNew = () => {
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
  };

  const handleFilterChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setDateFilter((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const formatDate = (dateString: string) => {
    return format(new Date(dateString), "MMM d, yyyy");
  };

  if (isLoading) {
    return <div>Loading sales...</div>;
  }

  if (error) {
    return <div>Error loading sales: {error.toString()}</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Sales</h1>
        <Button onClick={handleAddNew}>
          <Plus className="w-4 h-4 mr-2" />
          Record Sale
        </Button>
      </div>

      {isFormOpen && <SaleForm onClose={handleCloseForm} />}

      <div className="bg-card p-4 rounded-lg shadow">
        <h2 className="text-lg font-medium mb-4">Filter Sales</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <div className="space-y-2">
            <Label htmlFor="startDate">Start Date</Label>
            <Input
              id="startDate"
              name="startDate"
              type="date"
              value={dateFilter.startDate}
              onChange={handleFilterChange}
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="endDate">End Date</Label>
            <Input
              id="endDate"
              name="endDate"
              type="date"
              value={dateFilter.endDate}
              onChange={handleFilterChange}
            />
          </div>
          <div className="flex items-end">
            <Button onClick={() => refetch()} className="mb-0.5">
              <Search className="w-4 h-4 mr-2" />
              Filter
            </Button>
          </div>
        </div>
      </div>

      <div className="bg-card rounded-lg shadow">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Product</TableHead>
              <TableHead>Customer</TableHead>
              <TableHead>Salesperson</TableHead>
              <TableHead>Date</TableHead>
              <TableHead>Original Price</TableHead>
              <TableHead>Discount</TableHead>
              <TableHead>Sale Price</TableHead>
              <TableHead>Commission</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {sales?.map((sale) => (
              <TableRow key={sale.id}>
                <TableCell className="font-medium">
                  {sale.productName}
                </TableCell>
                <TableCell>{`${sale.customerFirstName} ${sale.customerLastName}`}</TableCell>
                <TableCell>{`${sale.salespersonFirstName} ${sale.salespersonLastName}`}</TableCell>
                <TableCell>{formatDate(sale.saleDate)}</TableCell>
                <TableCell>
                  ${sale.originalPrice?.toFixed(2) || sale.salePrice.toFixed(2)}
                </TableCell>
                <TableCell>
                  {sale.appliedDiscountPercentage > 0 ? (
                    <span className="px-2 py-1 bg-green-100 text-green-800 dark:bg-green-900/30 dark:text-green-400 rounded-full text-xs font-medium">
                      {sale.appliedDiscountPercentage}%
                      {sale.appliedDiscountCode && (
                        <span className="ml-1 text-xs font-normal">
                          ({sale.appliedDiscountCode})
                        </span>
                      )}
                    </span>
                  ) : (
                    "None"
                  )}
                </TableCell>
                <TableCell>${sale.salePrice.toFixed(2)}</TableCell>
                <TableCell>${sale.commissionAmount.toFixed(2)}</TableCell>
              </TableRow>
            ))}
            {sales?.length === 0 && (
              <TableRow>
                <TableCell colSpan={6} className="text-center py-4">
                  No sales found. Record a new sale to get started.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}
