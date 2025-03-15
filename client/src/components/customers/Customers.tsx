import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getCustomers } from "../../services/api";
import { Customer } from "../../types";
import { Button } from "../ui/button";
import CustomerForm from "./CustomerForm";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "../ui/table";
import { Plus } from "lucide-react";
import { format } from "date-fns";

export default function Customers() {
  const [isFormOpen, setIsFormOpen] = useState(false);

  const { data: customers, isLoading, error } = useQuery({
    queryKey: ["customers"],
    queryFn: getCustomers,
  });

  const handleAddNew = () => {
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
  };

  const formatDate = (dateString: string) => {
    return format(new Date(dateString), "MMM d, yyyy");
  };

  if (isLoading) {
    return <div>Loading customers...</div>;
  }

  if (error) {
    return <div>Error loading customers: {error.toString()}</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Customers</h1>
        <Button onClick={handleAddNew}>
          <Plus className="w-4 h-4 mr-2" />
          Add Customer
        </Button>
      </div>

      {isFormOpen && (
        <CustomerForm onClose={handleCloseForm} />
      )}

      <div className="bg-white rounded-lg shadow">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Name</TableHead>
              <TableHead>Address</TableHead>
              <TableHead>Phone</TableHead>
              <TableHead>Start Date</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {customers?.map((customer) => (
              <TableRow key={customer.id}>
                <TableCell className="font-medium">
                  {customer.firstName} {customer.lastName}
                </TableCell>
                <TableCell>{customer.address}</TableCell>
                <TableCell>{customer.phone}</TableCell>
                <TableCell>{formatDate(customer.startDate)}</TableCell>
              </TableRow>
            ))}
            {customers?.length === 0 && (
              <TableRow>
                <TableCell colSpan={4} className="text-center py-4">
                  No customers found. Add a new customer to get started.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}