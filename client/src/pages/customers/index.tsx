import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getCustomers } from "@/services";
import { Button } from "@/components/ui/button";
import { Customer } from "@/types/index";
import CustomerForm from "@/forms/CustomerForm";
import { Plus } from "lucide-react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./columns";

export default function Customers() {
  const [isFormOpen, setIsFormOpen] = useState(false);

  const {
    data: customers,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["customers"],
    queryFn: getCustomers,
  });

  const handleAddNew = () => {
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
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

      {isFormOpen && <CustomerForm onClose={handleCloseForm} />}

      <div className="bg-card rounded-lg shadow">
        <DataTable 
          columns={columns} 
          data={(customers as Customer[]) || []} 
          searchKey="name"
          searchPlaceholder="Search customers..."
        />
      </div>
    </div>
  );
}