import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getProducts } from "@/services/product-service";
import { Product } from "@/types/index";
import { Button } from "@/components/ui/button";
import ProductForm from "@/forms/ProductForm";
import { Plus } from "lucide-react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./columns";

export default function Products() {
  const [editingProduct, setEditingProduct] = useState<Product | null>(null);
  const [isFormOpen, setIsFormOpen] = useState(false);

  const {
    data: products,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["products"],
    queryFn: getProducts,
  });

  const handleAddNew = () => {
    setEditingProduct(null);
    setIsFormOpen(true);
  };

  const handleEdit = (product: Product) => {
    setEditingProduct(product);
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
    setEditingProduct(null);
  };

  const setupEditHandlers = () => {
    setTimeout(() => {
      document.querySelectorAll(".edit-action").forEach((button) => {
        const productId = button.getAttribute("data-product-id");
        if (productId && products) {
          const product = products.find((p) => p.id === parseInt(productId));
          if (product) {
            button.addEventListener("click", () => handleEdit(product));
          }
        }
      });
    }, 0);
  };

  if (isLoading) {
    return <div>Loading products...</div>;
  }

  if (error) {
    return <div>Error loading products: {error.toString()}</div>;
  }

  setupEditHandlers();

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Products</h1>
        <Button onClick={handleAddNew}>
          <Plus className="w-4 h-4 mr-2" />
          Add Product
        </Button>
      </div>

      {isFormOpen && (
        <ProductForm product={editingProduct} onClose={handleCloseForm} />
      )}

      <div className="bg-card rounded-lg shadow">
        <DataTable
          columns={columns}
          data={products || []}
          searchKey="name"
          searchPlaceholder="Filter products..."
        />
      </div>
    </div>
  );
}
