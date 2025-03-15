import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getSalespersons } from "../services/api";
import { Salesperson } from "../types";
import { Button } from "../components/ui/button";
import SalespersonForm from "../forms/SalespersonForm";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "../components/ui/table";
import { Edit, Plus } from "lucide-react";
import { format } from "date-fns";

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

  const formatDate = (dateString: string | null) => {
    if (!dateString) return "N/A";
    return format(new Date(dateString), "MMM d, yyyy");
  };

  if (isLoading) {
    return <div>Loading salespersons...</div>;
  }

  if (error) {
    return <div>Error loading salespersons: {error.toString()}</div>;
  }

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

      <div className="bg-white rounded-lg shadow">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Name</TableHead>
              <TableHead>Address</TableHead>
              <TableHead>Phone</TableHead>
              <TableHead>Start Date</TableHead>
              <TableHead>Termination Date</TableHead>
              <TableHead>Manager</TableHead>
              <TableHead>Actions</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {salespersons?.map((salesperson) => (
              <TableRow key={salesperson.id}>
                <TableCell className="font-medium">
                  {salesperson.firstName} {salesperson.lastName}
                </TableCell>
                <TableCell>{salesperson.address}</TableCell>
                <TableCell>{salesperson.phone}</TableCell>
                <TableCell>{formatDate(salesperson.startDate)}</TableCell>
                <TableCell>{formatDate(salesperson.terminationDate)}</TableCell>
                <TableCell>{salesperson.manager || "N/A"}</TableCell>
                <TableCell>
                  <Button
                    variant="ghost"
                    size="sm"
                    onClick={() => handleEdit(salesperson)}
                  >
                    <Edit className="w-4 h-4" />
                  </Button>
                </TableCell>
              </TableRow>
            ))}
            {salespersons?.length === 0 && (
              <TableRow>
                <TableCell colSpan={7} className="text-center py-4">
                  No salespersons found. Add a new salesperson to get started.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}
