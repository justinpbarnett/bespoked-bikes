import { useState } from "react";
import { useQueryClient, useMutation, useQuery } from "@tanstack/react-query";
import { X } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Switch } from "@/components/ui/switch";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { format } from "date-fns";
import { createDiscount, getProducts } from "@/services/api";
import { Discount, DiscountCreate, Product } from "@/types";
import { toast } from "sonner";

type DiscountFormProps = {
  discount: Discount | null;
  onClose: () => void;
};

export default function DiscountForm({ discount, onClose }: DiscountFormProps) {
  const queryClient = useQueryClient();
  const isEditing = !!discount;

  // Fetch products for the select dropdown
  const { data: products = [] } = useQuery({
    queryKey: ["products"],
    queryFn: getProducts,
  });

  // Initialize form state
  const [formData, setFormData] = useState<DiscountCreate>({
    productId: discount?.product?.id,
    beginDate: discount?.beginDate
      ? format(new Date(discount.beginDate), "yyyy-MM-dd")
      : format(new Date(), "yyyy-MM-dd"),
    endDate: discount?.endDate
      ? format(new Date(discount.endDate), "yyyy-MM-dd")
      : format(
          new Date(new Date().setMonth(new Date().getMonth() + 1)),
          "yyyy-MM-dd"
        ), // Default to 1 month from now
    discountPercentage: discount?.discountPercentage || 10,
    isGlobal: discount?.isGlobal || false,
    discountCode: discount?.discountCode || "",
  });

  const [requiresCode, setRequiresCode] = useState<boolean>(
    !!discount?.discountCode
  );
  const [error, setError] = useState<string | null>(null);

  // Create discount mutation
  const createDiscountMutation = useMutation({
    mutationFn: createDiscount,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["discounts"] });
      toast.success("Discount created successfully");
      onClose();
    },
    onError: (err: any) => {
      console.error("Create discount error:", err);
      setError(err.response?.data || "Failed to create discount");
      toast.error("Failed to create discount");
    },
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);

    // Validate form
    if (
      (!formData.isGlobal && !formData.productId) ||
      !formData.beginDate ||
      !formData.endDate ||
      formData.discountPercentage <= 0 ||
      formData.discountPercentage > 100
    ) {
      setError(
        "Please fill in all required fields. Product is required for non-global discounts, and discount percentage must be between 1 and 100."
      );
      return;
    }

    // Validate dates
    if (new Date(formData.beginDate) >= new Date(formData.endDate)) {
      setError("Begin date must be before end date.");
      return;
    }

    // Validate discount code if required
    if (requiresCode && !formData.discountCode) {
      setError(
        "Discount code is required when 'Require Discount Code' is enabled."
      );
      return;
    }

    // Prepare data for submission
    const submissionData = { ...formData };

    // Only include discount code if it's required
    if (!requiresCode) {
      delete submissionData.discountCode;
    }

    createDiscountMutation.mutate(submissionData);
  };

  const handleChange = (field: string, value: any) => {
    setFormData((prev) => ({
      ...prev,
      [field]: value,
    }));
  };

  return (
    <div className="bg-card p-6 rounded-lg shadow mb-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-semibold">
          {isEditing ? "Edit Discount" : "Add New Discount"}
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
        <div className="grid gap-4">
          <div className="flex items-center justify-between">
            <Label htmlFor="isGlobal">Global Discount</Label>
            <Switch
              id="isGlobal"
              checked={formData.isGlobal}
              onCheckedChange={(checked) => handleChange("isGlobal", checked)}
            />
          </div>
          <div className="text-sm text-muted-foreground">
            {formData.isGlobal
              ? "This discount will apply to all products"
              : "This discount applies to a specific product"}
          </div>

          {!formData.isGlobal && (
            <div className="grid gap-2">
              <Label htmlFor="product">Product</Label>
              <Select
                value={formData.productId?.toString() || ""}
                onValueChange={(value) =>
                  handleChange("productId", parseInt(value))
                }
              >
                <SelectTrigger id="product">
                  <SelectValue placeholder="Select a product" />
                </SelectTrigger>
                <SelectContent>
                  {products.map((product: Product) => (
                    <SelectItem key={product.id} value={product.id.toString()}>
                      {product.name} - ${product.salePrice}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
          )}

          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label htmlFor="beginDate">Begin Date</Label>
              <Input
                id="beginDate"
                type="date"
                value={formData.beginDate}
                onChange={(e) => handleChange("beginDate", e.target.value)}
                required
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="endDate">End Date</Label>
              <Input
                id="endDate"
                type="date"
                value={formData.endDate}
                onChange={(e) => handleChange("endDate", e.target.value)}
                required
              />
            </div>
          </div>

          <div className="space-y-2">
            <Label htmlFor="discountPercentage">Discount Percentage (%)</Label>
            <Input
              id="discountPercentage"
              type="number"
              min="0"
              max="100"
              step="0.1"
              value={formData.discountPercentage}
              onChange={(e) =>
                handleChange(
                  "discountPercentage",
                  parseFloat(e.target.value) || 0
                )
              }
              required
            />
          </div>

          <div className="flex items-center justify-between">
            <Label htmlFor="requiresCode">Require Discount Code</Label>
            <Switch
              id="requiresCode"
              checked={requiresCode}
              onCheckedChange={setRequiresCode}
            />
          </div>
          <div className="text-sm text-muted-foreground">
            {requiresCode
              ? "Customers must enter a code to receive this discount"
              : "This discount will be applied automatically"}
          </div>

          {requiresCode && (
            <div className="space-y-2">
              <Label htmlFor="discountCode">Discount Code</Label>
              <Input
                id="discountCode"
                type="text"
                placeholder="E.g. SUMMER25"
                value={formData.discountCode || ""}
                onChange={(e) => handleChange("discountCode", e.target.value)}
                required={requiresCode}
              />
            </div>
          )}
        </div>

        <div className="flex justify-end space-x-2 pt-4">
          <Button variant="outline" type="button" onClick={onClose}>
            Cancel
          </Button>
          <Button type="submit" disabled={createDiscountMutation.isPending}>
            {createDiscountMutation.isPending
              ? "Saving..."
              : isEditing
              ? "Update Discount"
              : "Add Discount"}
          </Button>
        </div>
      </form>
    </div>
  );
}
