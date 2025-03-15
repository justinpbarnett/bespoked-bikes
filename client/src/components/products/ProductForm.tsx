import { useState } from "react";
import { useQueryClient, useMutation } from "@tanstack/react-query";
import { createProduct, updateProduct } from "../../services/api";
import { Product, ProductCreate, ProductUpdate } from "../../types";
import { Button } from "../ui/button";
import { Input } from "../ui/input";
import { Label } from "../ui/label";
import { X } from "lucide-react";

type ProductFormProps = {
  product: Product | null;
  onClose: () => void;
};

export default function ProductForm({ product, onClose }: ProductFormProps) {
  const queryClient = useQueryClient();
  const isEditing = !!product;

  const [formData, setFormData] = useState<ProductCreate>({
    name: product?.name || "",
    manufacturer: product?.manufacturer || "",
    style: product?.style || "",
    purchasePrice: product?.purchasePrice || 0,
    salePrice: product?.salePrice || 0,
    quantityOnHand: product?.quantityOnHand || 0,
    commissionPercentage: product?.commissionPercentage || 0,
  });

  const [error, setError] = useState<string | null>(null);

  const createMutation = useMutation({
    mutationFn: createProduct,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["products"] });
      onClose();
    },
    onError: (err: any) => {
      setError(err.response?.data || "Failed to create product");
    },
  });

  const updateMutation = useMutation({
    mutationFn: ({ id, data }: { id: number; data: Omit<Product, "id"> }) =>
      updateProduct(id, data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["products"] });
      onClose();
    },
    onError: (err: any) => {
      setError(err.response?.data || "Failed to update product");
    },
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement>
  ) => {
    const { name, value, type } = e.target;
    
    setFormData((prev) => ({
      ...prev,
      [name]: type === "number" ? parseFloat(value) || 0 : value,
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);

    // Validate form
    if (
      !formData.name ||
      !formData.manufacturer ||
      !formData.style ||
      formData.purchasePrice <= 0 ||
      formData.salePrice <= 0 ||
      formData.quantityOnHand < 0 ||
      formData.commissionPercentage < 0 ||
      formData.commissionPercentage > 100
    ) {
      setError(
        "Please fill out all fields correctly. Prices must be greater than 0, commission percentage must be between 0 and 100."
      );
      return;
    }

    if (isEditing && product) {
      updateMutation.mutate({
        id: product.id,
        data: formData,
      });
    } else {
      createMutation.mutate(formData);
    }
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow mb-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-semibold">
          {isEditing ? "Edit Product" : "Add New Product"}
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
            <Label htmlFor="name">Product Name</Label>
            <Input
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="manufacturer">Manufacturer</Label>
            <Input
              id="manufacturer"
              name="manufacturer"
              value={formData.manufacturer}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="style">Style</Label>
            <Input
              id="style"
              name="style"
              value={formData.style}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="purchasePrice">Purchase Price ($)</Label>
            <Input
              id="purchasePrice"
              name="purchasePrice"
              type="number"
              step="0.01"
              min="0.01"
              value={formData.purchasePrice}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="salePrice">Sale Price ($)</Label>
            <Input
              id="salePrice"
              name="salePrice"
              type="number"
              step="0.01"
              min="0.01"
              value={formData.salePrice}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="quantityOnHand">Quantity on Hand</Label>
            <Input
              id="quantityOnHand"
              name="quantityOnHand"
              type="number"
              min="0"
              step="1"
              value={formData.quantityOnHand}
              onChange={handleChange}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="commissionPercentage">Commission Percentage (%)</Label>
            <Input
              id="commissionPercentage"
              name="commissionPercentage"
              type="number"
              min="0"
              max="100"
              step="0.1"
              value={formData.commissionPercentage}
              onChange={handleChange}
              required
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
              ? "Update Product"
              : "Add Product"}
          </Button>
        </div>
      </form>
    </div>
  );
}