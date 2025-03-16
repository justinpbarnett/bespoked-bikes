import { useState, useEffect } from "react";
import { useQueryClient, useMutation, useQuery } from "@tanstack/react-query";
import {
  createSale,
  getProducts,
  getSalespersons,
  getCustomers,
} from "@/services/api";
import { SaleCreate } from "@/types";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { X } from "lucide-react";
import { format } from "date-fns";

type SaleFormProps = {
  onClose: () => void;
};

export default function SaleForm({ onClose }: SaleFormProps) {
  const queryClient = useQueryClient();

  const [formData, setFormData] = useState<SaleCreate>({
    productId: 0,
    salespersonId: 0,
    customerId: 0,
    salesDate: format(new Date(), "yyyy-MM-dd"),
  });

  const [error, setError] = useState<string | null>(null);

  // Fetch products, salespersons, and customers
  const { data: products } = useQuery({
    queryKey: ["products"],
    queryFn: getProducts,
  });

  const { data: salespersons } = useQuery({
    queryKey: ["salespersons"],
    queryFn: getSalespersons,
  });

  const { data: customers } = useQuery({
    queryKey: ["customers"],
    queryFn: getCustomers,
  });

  // Set default values after data is loaded
  useEffect(() => {
    if (products?.length && formData.productId === 0) {
      setFormData((prev) => ({ ...prev, productId: products[0].id }));
    }
    if (salespersons?.length && formData.salespersonId === 0) {
      setFormData((prev) => ({ ...prev, salespersonId: salespersons[0].id }));
    }
    if (customers?.length && formData.customerId === 0) {
      setFormData((prev) => ({ ...prev, customerId: customers[0].id }));
    }
  }, [products, salespersons, customers, formData]);

  const createMutation = useMutation({
    mutationFn: createSale,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["sales"] });
      onClose();
    },
    onError: (err: any) => {
      setError(err.response?.data || "Failed to record sale");
    },
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;

    setFormData((prev) => ({
      ...prev,
      [name]: name === "salesDate" ? value : parseInt(value, 10),
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);

    // Validate form
    if (
      formData.productId <= 0 ||
      formData.salespersonId <= 0 ||
      formData.customerId <= 0 ||
      !formData.salesDate
    ) {
      setError(
        "Please select a product, salesperson, customer, and sales date."
      );
      return;
    }

    createMutation.mutate(formData);
  };

  // Find product in stock
  const selectedProduct = products?.find((p) => p.id === formData.productId);
  const isOutOfStock = selectedProduct && selectedProduct.quantityOnHand <= 0;

  return (
    <div className="bg-card p-6 rounded-lg shadow mb-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-semibold">Record New Sale</h2>
        <Button variant="ghost" size="sm" onClick={onClose}>
          <X className="w-4 h-4" />
        </Button>
      </div>

      {error && (
        <div className="bg-red-50 text-red-600 p-3 rounded-md mb-4">
          {error}
        </div>
      )}

      {isOutOfStock && (
        <div className="bg-yellow-50 text-yellow-600 p-3 rounded-md mb-4">
          Warning: Selected product is out of stock!
        </div>
      )}

      <form onSubmit={handleSubmit} className="space-y-4">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div className="space-y-2">
            <Label htmlFor="productId">Product</Label>
            <select
              id="productId"
              name="productId"
              value={formData.productId}
              onChange={handleChange}
              className="w-full h-10 px-3 py-2 rounded-md border border-input bg-[hsl(var(--background))]"
              required
            >
              <option value="">Select a product</option>
              {products?.map((product) => (
                <option key={product.id} value={product.id}>
                  {product.name} - ${product.salePrice.toFixed(2)}
                  {product.quantityOnHand <= 0 ? " (Out of stock)" : ""}
                </option>
              ))}
            </select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="salespersonId">Salesperson</Label>
            <select
              id="salespersonId"
              name="salespersonId"
              value={formData.salespersonId}
              onChange={handleChange}
              className="w-full h-10 px-3 py-2 rounded-md border border-input bg-[hsl(var(--background))]"
              required
            >
              <option value="">Select a salesperson</option>
              {salespersons?.map((salesperson) => (
                <option key={salesperson.id} value={salesperson.id}>
                  {salesperson.firstName} {salesperson.lastName}
                </option>
              ))}
            </select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="customerId">Customer</Label>
            <select
              id="customerId"
              name="customerId"
              value={formData.customerId}
              onChange={handleChange}
              className="w-full h-10 px-3 py-2 rounded-md border border-input bg-[hsl(var(--background))]"
              required
            >
              <option value="">Select a customer</option>
              {customers?.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.firstName} {customer.lastName}
                </option>
              ))}
            </select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="salesDate">Sales Date</Label>
            <Input
              id="salesDate"
              name="salesDate"
              type="date"
              value={formData.salesDate}
              onChange={handleChange}
              required
            />
          </div>
        </div>

        {selectedProduct && (
          <div className="mt-6 bg-muted/30 p-4 rounded-md">
            <h3 className="font-medium mb-2">Product Details</h3>
            <div className="grid grid-cols-2 gap-4">
              <div>
                <span className="text-sm text-muted-foreground">Sale Price:</span>
                <p>${selectedProduct.salePrice.toFixed(2)}</p>
              </div>
              <div>
                <span className="text-sm text-muted-foreground">Commission:</span>
                <p>{selectedProduct.commissionPercentage.toFixed(1)}%</p>
              </div>
              <div>
                <span className="text-sm text-muted-foreground">In Stock:</span>
                <p>{selectedProduct.quantityOnHand}</p>
              </div>
              <div>
                <span className="text-sm text-muted-foreground">
                  Commission Amount:
                </span>
                <p>
                  $
                  {(
                    (selectedProduct.salePrice *
                      selectedProduct.commissionPercentage) /
                    100
                  ).toFixed(2)}
                </p>
              </div>
            </div>
          </div>
        )}

        <div className="flex justify-end space-x-2 pt-4">
          <Button variant="outline" type="button" onClick={onClose}>
            Cancel
          </Button>
          <Button
            type="submit"
            disabled={createMutation.isPending || isOutOfStock}
          >
            {createMutation.isPending ? "Processing..." : "Record Sale"}
          </Button>
        </div>
      </form>
    </div>
  );
}
