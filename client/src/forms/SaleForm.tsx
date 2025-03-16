import { useEffect } from "react";
import { useQuery } from "@tanstack/react-query";
import { SaleCreate, Product } from "@/types/index";
import { useForm } from "@/hooks/use-form";
import { useMutationWithInvalidation } from "@/hooks/use-mutation";
import { formatCurrency } from "@/lib/format";
import { 
  getProducts,
  getSalespersons, 
  getCustomers,
  createSale 
} from "@/services";
import FormWrapper from "@/components/common/FormWrapper";
import { SelectField, InputField } from "@/components/common/FormField";

interface SaleFormProps {
  onClose: () => void;
}

export default function SaleForm({ onClose }: SaleFormProps) {
  // Form validation function
  const validateForm = (values: SaleCreate) => {
    const errors: Record<string, string> = {};
    
    if (!values.productId) {
      errors.productId = "Please select a product";
    }
    if (!values.salespersonId) {
      errors.salespersonId = "Please select a salesperson";
    }
    if (!values.customerId) {
      errors.customerId = "Please select a customer";
    }
    if (!values.saleDate) {
      errors.saleDate = "Please select a sale date";
    }
    
    return errors;
  };

  // Setup form with useForm hook
  const { 
    values, 
    errors,
    handleChange, 
    handleSubmit,
    setValues 
  } = useForm({
    initialValues: {
      productId: 0,
      customerId: 0,
      salespersonId: 0,
      saleDate: new Date().toISOString().split("T")[0],
      salePrice: 0,
    } as SaleCreate,
    onSubmit: (values) => createMutation.mutate(values),
    validate: validateForm,
  });

  // Setup mutation with our custom hook
  const createMutation = useMutationWithInvalidation({
    mutationFn: createSale,
    invalidateQueries: [
      "sales", 
      "dashboardSummary", 
      "recentSales", 
      "monthlySales", 
      "topSalespersons", 
      "productPerformance"
    ],
    setQueryData: {
      queryKey: ["sales"],
      updater: (oldData, newData) => oldData ? [newData, ...oldData] : [newData],
    },
    onSuccess: () => onClose(),
  });

  // Fetch related data
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

  // Set default values when data loads
  useEffect(() => {
    if (products?.length && values.productId === 0) {
      setValues((prev: SaleCreate) => ({ ...prev, productId: products[0].id }));
    }
    if (salespersons?.length && values.salespersonId === 0) {
      setValues((prev: SaleCreate) => ({ ...prev, salespersonId: salespersons[0].id }));
    }
    if (customers?.length && values.customerId === 0) {
      setValues((prev: SaleCreate) => ({ ...prev, customerId: customers[0].id }));
    }
  }, [products, salespersons, customers, values.productId, values.salespersonId, values.customerId, setValues]);

  // Find selected product details
  const selectedProduct = products?.find((p) => p.id === values.productId) as Product | undefined;
  const isOutOfStock = selectedProduct && selectedProduct.quantityOnHand <= 0;

  // Create product options for select
  const productOptions = products?.map(product => ({
    value: product.id,
    label: `${product.name} - ${formatCurrency(product.salePrice)}${product.quantityOnHand <= 0 ? " (Out of stock)" : ""}`,
  })) || [];

  // Create salesperson options for select
  const salespersonOptions = salespersons?.map(person => ({
    value: person.id,
    label: `${person.firstName} ${person.lastName}`,
  })) || [];

  // Create customer options for select
  const customerOptions = customers?.map(customer => ({
    value: customer.id,
    label: `${customer.firstName} ${customer.lastName}`,
  })) || [];

  return (
    <FormWrapper
      title="Record New Sale"
      onClose={onClose}
      error={createMutation.error ? "Failed to record sale" : null}
      warning={isOutOfStock ? "Warning: Selected product is out of stock!" : undefined}
      onSubmit={handleSubmit}
      isSubmitting={createMutation.isPending}
      submitLabel="Record Sale"
    >
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        <SelectField
          id="productId"
          label="Product"
          value={values.productId}
          onChange={handleChange}
          options={productOptions}
          error={errors.productId}
          required
        />

        <SelectField
          id="salespersonId"
          label="Salesperson"
          value={values.salespersonId}
          onChange={handleChange}
          options={salespersonOptions}
          error={errors.salespersonId}
          required
        />

        <SelectField
          id="customerId"
          label="Customer"
          value={values.customerId}
          onChange={handleChange}
          options={customerOptions}
          error={errors.customerId}
          required
        />

        <InputField
          id="saleDate"
          label="Sale Date"
          type="date"
          value={values.saleDate}
          onChange={handleChange}
          error={errors.saleDate}
          required
        />
      </div>

      {selectedProduct && (
        <div className="mt-6 bg-muted/30 p-4 rounded-md">
          <h3 className="font-medium mb-2">Product Details</h3>
          <div className="grid grid-cols-2 gap-4">
            <div>
              <span className="text-sm text-muted-foreground">
                Sale Price:
              </span>
              <p>{formatCurrency(selectedProduct.salePrice)}</p>
            </div>
            <div>
              <span className="text-sm text-muted-foreground">
                Commission:
              </span>
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
                {formatCurrency((selectedProduct.salePrice * selectedProduct.commissionPercentage) / 100)}
              </p>
            </div>
          </div>
        </div>
      )}
    </FormWrapper>
  );
}
