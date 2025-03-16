import { useState } from "react";
import { useQueryClient, useMutation } from "@tanstack/react-query";
import {
  createSalesperson,
  updateSalesperson,
} from "../services/salesperson-service";
import { Salesperson, SalespersonSubmit } from "../types/index";
import { Button } from "../components/ui/button";
import { Input } from "../components/ui/input";
import { Label } from "../components/ui/label";
import { X } from "lucide-react";
import { format } from "date-fns";

type SalespersonFormProps = {
  salesperson: Salesperson | null;
  onClose: () => void;
};

export default function SalespersonForm({
  salesperson,
  onClose,
}: SalespersonFormProps) {
  const queryClient = useQueryClient();
  const isEditing = !!salesperson;

  const [formData, setFormData] = useState<SalespersonSubmit>({
    firstName: salesperson?.firstName || "",
    lastName: salesperson?.lastName || "",
    address: salesperson?.address || "",
    phone: salesperson?.phone || "",
    startDate: salesperson?.startDate
      ? format(new Date(salesperson.startDate), "yyyy-MM-dd")
      : format(new Date(), "yyyy-MM-dd"),
    terminationDate: salesperson?.terminationDate
      ? format(new Date(salesperson.terminationDate), "yyyy-MM-dd")
      : "",
    manager: salesperson?.manager || "",
  });

  const [error, setError] = useState<string | null>(null);

  const createMutation = useMutation({
    mutationFn: createSalesperson,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["salespersons"] });
      onClose();
    },
    onError: (err: any) => {
      setError(err.response?.data || "Failed to create salesperson");
    },
  });

  const updateMutation = useMutation({
    mutationFn: ({ id, data }: { id: number; data: Omit<Salesperson, "id"> }) =>
      updateSalesperson(id, data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["salespersons"] });
      onClose();
    },
    onError: (err: any) => {
      console.error("Update error:", err);

      if (err.response?.data) {
        if (typeof err.response.data === "string") {
          setError(err.response.data);
        } else if (err.response.data.detail) {
          setError(err.response.data.detail);
        } else if (err.response.data.message) {
          setError(err.response.data.message);
        } else if (err.response.data.title) {
          setError(
            `${err.response.data.title}: ${
              err.response.data.detail || "Please check your input."
            }`
          );
        } else {
          setError(JSON.stringify(err.response.data));
        }
      } else {
        setError(
          `Failed to update salesperson: ${err.message || "Unknown error"}`
        );
      }
    },
  });

  const validatePhoneNumber = (phone: string): boolean => {
    // Regex for US phone format: (123) 456-7890 or 123-456-7890 or 1234567890
    const phoneRegex = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    return phoneRegex.test(phone);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);

    if (
      !formData.firstName ||
      !formData.lastName ||
      !formData.address ||
      !formData.phone ||
      !formData.startDate
    ) {
      setError(
        "Please fill out all required fields: First Name, Last Name, Address, Phone, and Start Date."
      );
      return;
    }
    
    if (!validatePhoneNumber(formData.phone)) {
      setError("Please enter a valid phone number (e.g., (123) 456-7890, 123-456-7890, or 1234567890)");
      return;
    }

    if (
      formData.terminationDate &&
      new Date(formData.terminationDate) < new Date(formData.startDate)
    ) {
      setError("Termination date cannot be before start date.");
      return;
    }

    const submissionData = { ...formData };

    if (
      !submissionData.terminationDate ||
      submissionData.terminationDate === ""
    ) {
      submissionData.terminationDate = null as any;
    }

    Object.keys(submissionData).forEach((key) => {
      const value = submissionData[key as keyof typeof submissionData];
      if (typeof value === "string") {
        submissionData[key as keyof typeof submissionData] =
          value.trim() as any;
      }
    });

    if (isEditing && salesperson) {
      updateMutation.mutate({
        id: salesperson.id,
        data: submissionData,
      });
    } else {
      createMutation.mutate(submissionData);
    }
  };

  return (
    <div className="bg-card p-6 rounded-lg shadow mb-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-semibold">
          {isEditing ? "Edit Salesperson" : "Add New Salesperson"}
        </h2>
        <Button variant="ghost" size="sm" onClick={onClose}>
          <X className="w-4 h-4" />
        </Button>
      </div>

      {error && (
        <div className="bg-red-50 text-red-600 p-3 rounded-md mb-4">
          {error}
        </div>
      )}

      <form onSubmit={handleSubmit} className="space-y-4">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div className="space-y-2">
            <Label htmlFor="firstName">First Name</Label>
            <Input
              id="firstName"
              name="firstName"
              value={formData.firstName}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="lastName">Last Name</Label>
            <Input
              id="lastName"
              name="lastName"
              value={formData.lastName}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2 md:col-span-2">
            <Label htmlFor="address">Address</Label>
            <Input
              id="address"
              name="address"
              value={formData.address}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="phone">Phone</Label>
            <Input
              id="phone"
              name="phone"
              value={formData.phone}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="manager">Manager</Label>
            <Input
              id="manager"
              name="manager"
              value={formData.manager || ""}
              onChange={handleChange}
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="startDate">Start Date</Label>
            <Input
              id="startDate"
              name="startDate"
              type="date"
              value={formData.startDate}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="terminationDate">
              Termination Date (if applicable)
            </Label>
            <Input
              id="terminationDate"
              name="terminationDate"
              type="date"
              value={formData.terminationDate || ""}
              onChange={handleChange}
            />
          </div>
        </div>

        <div className="flex justify-end space-x-2 pt-4">
          <Button variant="outline" type="button" onClick={onClose}>
            Cancel
          </Button>
          <Button
            type="submit"
            disabled={createMutation.isPending || updateMutation.isPending}
          >
            {createMutation.isPending || updateMutation.isPending
              ? "Saving..."
              : isEditing
              ? "Update Salesperson"
              : "Add Salesperson"}
          </Button>
        </div>
      </form>
    </div>
  );
}
