import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getSalesFiltered } from "@/services";
import { Button } from "@/components/ui/button";
import { Sale } from "@/types/index";
import SaleForm from "@/forms/SaleForm";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Plus, Search } from "lucide-react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./columns";

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
    staleTime: 10 * 1000, // Keep data fresh for 10 seconds
    refetchOnWindowFocus: true, // Refetch when window regains focus
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
        <DataTable 
          columns={columns} 
          data={(sales as Sale[]) || []} 
          searchKey="productName"
          searchPlaceholder="Search sales..."
        />
      </div>
    </div>
  );
}