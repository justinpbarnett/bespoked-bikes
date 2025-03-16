import { useEffect, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { SaleCreate, Product, Discount } from "@/types/index";
import { useForm } from "@/hooks/use-form";
import { useMutationWithInvalidation } from "@/hooks/use-mutation";
import { formatCurrency } from "@/lib/format";
import {
  getProducts,
  getSalespersons,
  getCustomers,
  createSale,
  getGlobalDiscounts,
} from "@/services";
import FormWrapper from "@/components/common/FormWrapper";
import { SelectField, InputField } from "@/components/common/FormField";
import { Badge } from "@/components/ui/badge";

interface SaleFormProps {
  onClose: () => void;
}

export default function SaleForm({ onClose }: SaleFormProps) {
  const [validDiscount, setValidDiscount] = useState<Discount | null>(null);
  const [checkingDiscount, setCheckingDiscount] = useState(false);

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
    if (!values.salesDate) {
      errors.salesDate = "Please select a sale date";
    } else {
      const selectedDate = new Date(values.salesDate);
      const today = new Date();
      today.setHours(0, 0, 0, 0);

      if (selectedDate > today) {
        errors.salesDate = "Sale date cannot be in the future";
      }
    }

    return errors;
  };

  const { values, errors, handleChange, handleSubmit, setValues } = useForm({
    initialValues: {
      productId: 0,
      customerId: 0,
      salespersonId: 0,
      salesDate: new Date().toISOString().split("T")[0],
      salePrice: 0,
      discountCode: "",
    } as SaleCreate,
    onSubmit: (values) => createMutation.mutate(values),
    validate: validateForm,
  });

  const createMutation = useMutationWithInvalidation({
    mutationFn: createSale,
    invalidateQueries: [
      "sales",
      "dashboardSummary",
      "recentSales",
      "monthlySales",
      "topSalespersons",
      "productPerformance",
    ],
    setQueryData: {
      queryKey: ["sales"],
      updater: (oldData, newData) =>
        oldData ? [newData, ...oldData] : [newData],
    },
    onSuccess: () => onClose(),
  });

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

  const { data: availableDiscounts } = useQuery({
    queryKey: ["global-discounts", values.salesDate],
    queryFn: () => getGlobalDiscounts(values.salesDate),
    enabled: !!values.salesDate,
  });

  useEffect(() => {
    if (products?.length && values.productId === 0) {
      setValues((prev: SaleCreate) => ({ ...prev, productId: products[0].id }));
    }
    if (salespersons?.length && values.salespersonId === 0) {
      setValues((prev: SaleCreate) => ({
        ...prev,
        salespersonId: salespersons[0].id,
      }));
    }
    if (customers?.length && values.customerId === 0) {
      setValues((prev: SaleCreate) => ({
        ...prev,
        customerId: customers[0].id,
      }));
    }
  }, [
    products,
    salespersons,
    customers,
    values.productId,
    values.salespersonId,
    values.customerId,
    setValues,
  ]);

  useEffect(() => {
    setValidDiscount(null);

    if (
      !values.discountCode ||
      values.discountCode.trim() === "" ||
      !availableDiscounts
    ) {
      return;
    }

    setCheckingDiscount(true);

    const matchingDiscount = availableDiscounts.find(
      (d) =>
        d.discountCode?.toLowerCase() === values.discountCode?.toLowerCase() &&
        (d.product?.id === values.productId || d.isGlobal)
    );

    if (matchingDiscount) {
      setValidDiscount(matchingDiscount);
    }

    setCheckingDiscount(false);
  }, [values.discountCode, values.productId, availableDiscounts]);

  const selectedProduct = products?.find((p) => p.id === values.productId) as
    | Product
    | undefined;
  const isOutOfStock = selectedProduct && selectedProduct.quantityOnHand <= 0;

  const originalPrice = selectedProduct?.salePrice || 0;
  const discountPercentage = validDiscount?.discountPercentage || 0;
  const finalPrice = originalPrice * (1 - discountPercentage / 100);

  const productOptions =
    products?.map((product) => ({
      value: product.id,
      label: `${product.name} - ${formatCurrency(product.salePrice)}${
        product.quantityOnHand <= 0 ? " (Out of stock)" : ""
      }`,
    })) || [];

  const salespersonOptions =
    salespersons?.map((person) => ({
      value: person.id,
      label: `${person.firstName} ${person.lastName}`,
    })) || [];

  const customerOptions =
    customers?.map((customer) => ({
      value: customer.id,
      label: `${customer.firstName} ${customer.lastName}`,
    })) || [];

  return (
    <FormWrapper
      title="Record New Sale"
      onClose={onClose}
      error={createMutation.error ? "Failed to record sale" : null}
      warning={
        isOutOfStock ? "Warning: Selected product is out of stock!" : undefined
      }
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
          id="salesDate"
          label="Sale Date"
          type="date"
          value={values.salesDate}
          onChange={handleChange}
          error={errors.salesDate}
          required
          max={new Date().toISOString().split("T")[0]}
        />

        <InputField
          id="discountCode"
          label="Discount Code"
          value={values.discountCode || ""}
          onChange={handleChange}
          placeholder="Enter discount code (optional)"
          description="Enter a valid discount code to apply to this sale"
          className="md:col-span-2"
        />
      </div>

      {selectedProduct && (
        <div className="mt-6 bg-muted/30 p-4 rounded-md">
          <h3 className="font-medium mb-2">Product Details</h3>
          <div className="grid grid-cols-2 gap-4">
            <div>
              <span className="text-sm text-muted-foreground">
                Regular Price:
              </span>
              <p
                className={
                  validDiscount ? "line-through text-muted-foreground" : ""
                }
              >
                {formatCurrency(selectedProduct.salePrice)}
              </p>
              {validDiscount && (
                <p className="text-green-600 font-medium">
                  {formatCurrency(finalPrice)}
                </p>
              )}
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
                {formatCurrency(
                  (finalPrice * selectedProduct.commissionPercentage) / 100
                )}
              </p>
            </div>

            {values.discountCode && (
              <div className="col-span-2 mt-2">
                <span className="text-sm text-muted-foreground">Discount:</span>
                {validDiscount ? (
                  <div className="flex items-center mt-1">
                    <Badge className="bg-green-600">
                      {validDiscount.discountPercentage}% off
                    </Badge>
                    <span className="ml-2 text-sm text-green-600">
                      Code "{values.discountCode}" applied successfully
                    </span>
                  </div>
                ) : (
                  <div className="flex items-center mt-1">
                    <Badge variant="destructive">Invalid</Badge>
                    <span className="ml-2 text-sm text-destructive">
                      Code "{values.discountCode}" not valid for this
                      product/date
                    </span>
                  </div>
                )}
              </div>
            )}
          </div>
        </div>
      )}
    </FormWrapper>
  );
}
