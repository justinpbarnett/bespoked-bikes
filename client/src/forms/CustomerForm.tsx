import { useState } from "react";
import { useQueryClient, useMutation } from "@tanstack/react-query";
import { createCustomer } from "../services/customer-service";
import { CustomerCreate } from "../types/index";
import { Button } from "../components/ui/button";
import { Input } from "../components/ui/input";
import { Label } from "../components/ui/label";
import { X } from "lucide-react";

type CustomerFormProps = {
  onClose: () => void;
};

export default function CustomerForm({ onClose }: CustomerFormProps) {
  const queryClient = useQueryClient();

  const [formData, setFormData] = useState<CustomerCreate>({
    firstName: "",
    lastName: "",
    address: "",
    phone: "",
    startDate: new Date().toISOString().split("T")[0],
  });

  const [error, setError] = useState<string | null>(null);

  const createMutation = useMutation({
    mutationFn: createCustomer,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["customers"] });
      onClose();
    },
    onError: (err: any) => {
      setError(err.response?.data || "Failed to create customer");
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

    createMutation.mutate(formData);
  };

  return (
    <div className="bg-card p-6 rounded-lg shadow mb-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-semibold">Add New Customer</h2>
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
        </div>

        <div className="flex justify-end space-x-2 pt-4">
          <Button variant="outline" type="button" onClick={onClose}>
            Cancel
          </Button>
          <Button type="submit" disabled={createMutation.isPending}>
            {createMutation.isPending ? "Saving..." : "Add Customer"}
          </Button>
        </div>
      </form>
    </div>
  );
}
