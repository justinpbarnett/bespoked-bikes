import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getSalespersons } from "@/services";
import type { Salesperson } from "@/types/index";
import { Button } from "@/components/ui/button";
import SalespersonForm from "@/forms/SalespersonForm";
import { Plus } from "lucide-react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./columns";

export default function Salespersons() {
  const [editingSalesperson, setEditingSalesperson] =
    useState<Salesperson | null>(null);
  const [isFormOpen, setIsFormOpen] = useState(false);

  const {
    data: salespersons,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["salespersons"],
    queryFn: getSalespersons,
  });

  const handleAddNew = () => {
    setEditingSalesperson(null);
    setIsFormOpen(true);
  };

  const handleEdit = (salesperson: Salesperson) => {
    setEditingSalesperson(salesperson);
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
    setEditingSalesperson(null);
  };

  // Setup click handler for edit buttons
  const setupEditHandlers = () => {
    setTimeout(() => {
      document.querySelectorAll('.edit-action').forEach(button => {
        const salespersonId = button.getAttribute('data-salesperson-id');
        if (salespersonId && salespersons) {
          const salesperson = (salespersons as Salesperson[]).find(p => p.id === parseInt(salespersonId));
          if (salesperson) {
            button.addEventListener('click', () => handleEdit(salesperson));
          }
        }
      });
    }, 0);
  };

  if (isLoading) {
    return <div>Loading salespersons...</div>;
  }

  if (error) {
    return <div>Error loading salespersons: {error.toString()}</div>;
  }

  setupEditHandlers();

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Salespersons</h1>
        <Button onClick={handleAddNew}>
          <Plus className="w-4 h-4 mr-2" />
          Add Salesperson
        </Button>
      </div>

      {isFormOpen && (
        <SalespersonForm
          salesperson={editingSalesperson}
          onClose={handleCloseForm}
        />
      )}

      <div className="bg-card rounded-lg shadow">
        <DataTable 
          columns={columns} 
          data={(salespersons as Salesperson[]) || []} 
          searchKey="name"
          searchPlaceholder="Search salespersons..."
        />
      </div>
    </div>
  );
}