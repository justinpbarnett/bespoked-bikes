import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getDiscounts } from "@/services/api";
import { Button } from "@/components/ui/button";
import { Plus, Percent } from "lucide-react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./columns";
import DiscountForm from "@/forms/DiscountForm";
import { Discount } from "@/types/index";

export default function Discounts() {
  const [isFormOpen, setIsFormOpen] = useState(false);
  const [editingDiscount, setEditingDiscount] = useState<Discount | null>(null);

  // Fetch all discounts
  const { data: discounts = [], isLoading } = useQuery({
    queryKey: ["discounts"],
    queryFn: getDiscounts,
    staleTime: 10 * 1000, // Keep data fresh for 10 seconds
    refetchOnWindowFocus: true, // Refetch when window regains focus
  });

  const handleAddNew = () => {
    setEditingDiscount(null);
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
    setEditingDiscount(null);
  };

  if (isLoading) {
    return <div>Loading discounts...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Discounts</h1>
        <Button onClick={handleAddNew}>
          <Plus className="w-4 h-4 mr-2" />
          Create Discount
        </Button>
      </div>

      {isFormOpen && (
        <DiscountForm discount={editingDiscount} onClose={handleCloseForm} />
      )}

      <div className="bg-card rounded-lg shadow">
        {discounts.length === 0 ? (
          <div className="flex flex-col items-center justify-center h-40 text-center p-4">
            <Percent className="h-10 w-10 text-muted-foreground mb-2" />
            <p className="text-muted-foreground">No discounts created yet.</p>
            <p className="text-sm text-muted-foreground">
              Create a discount to see it here.
            </p>
          </div>
        ) : (
          <DataTable 
            columns={columns} 
            data={discounts || []} 
            searchKey="discountPercentage"
            searchPlaceholder="Search discounts..."
          />
        )}
      </div>
    </div>
  );
}