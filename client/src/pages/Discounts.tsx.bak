import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getDiscounts } from "../services/api";
import { Discount } from "../types/index";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Button } from "@/components/ui/button";
import { Percent, Plus } from "lucide-react";
import { format, parseISO } from "date-fns";
import DiscountForm from "../forms/DiscountForm";

export default function Discounts() {
  const [isFormOpen, setIsFormOpen] = useState(false);
  const [editingDiscount, setEditingDiscount] = useState<Discount | null>(null);

  // Fetch all discounts
  const { data: discounts = [], isLoading: isLoadingDiscounts } = useQuery({
    queryKey: ["discounts"],
    queryFn: getDiscounts,
  });

  const handleAddNew = () => {
    setEditingDiscount(null);
    setIsFormOpen(true);
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
    setEditingDiscount(null);
  };

  // Format date for display
  const formatDate = (dateString: string) => {
    try {
      return format(parseISO(dateString), "MMM d, yyyy");
    } catch (error) {
      return dateString;
    }
  };

  return (
    <div className="container mx-auto py-10">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-3xl font-bold">Discounts</h1>
        <Button onClick={handleAddNew}>
          <Plus className="mr-2 h-4 w-4" /> Create Discount
        </Button>
      </div>

      {isFormOpen && (
        <DiscountForm discount={editingDiscount} onClose={handleCloseForm} />
      )}

      <Card>
        <CardHeader>
          <CardTitle>Current Discounts</CardTitle>
          <CardDescription>
            Manage both global and product-specific discounts that will be
            automatically applied to sales.
          </CardDescription>
        </CardHeader>
        <CardContent>
          {isLoadingDiscounts ? (
            <div className="flex justify-center items-center h-40">
              <p>Loading discounts...</p>
            </div>
          ) : discounts.length === 0 ? (
            <div className="flex flex-col items-center justify-center h-40 text-center">
              <Percent className="h-10 w-10 text-muted-foreground mb-2" />
              <p className="text-muted-foreground">No discounts created yet.</p>
              <p className="text-sm text-muted-foreground">
                Create a discount to see it here.
              </p>
            </div>
          ) : (
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead>Product</TableHead>
                  <TableHead>Discount %</TableHead>
                  <TableHead>Begin Date</TableHead>
                  <TableHead>End Date</TableHead>
                  <TableHead>Code Required</TableHead>
                  <TableHead>Status</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {discounts.map((discount: Discount) => {
                  const now = new Date();
                  const beginDate = new Date(discount.beginDate);
                  const endDate = new Date(discount.endDate);
                  let status = "Upcoming";
                  let statusClass =
                    "bg-blue-100 text-blue-800 dark:bg-blue-900/30 dark:text-blue-400";

                  if (now >= beginDate && now <= endDate) {
                    status = "Active";
                    statusClass =
                      "bg-green-100 text-green-800 dark:bg-green-900/30 dark:text-green-400";
                  } else if (now > endDate) {
                    status = "Expired";
                    statusClass =
                      "bg-red-100 text-red-800 dark:bg-red-900/30 dark:text-red-400";
                  }

                  return (
                    <TableRow key={discount.id}>
                      <TableCell className="font-medium">
                        {discount.isGlobal ? (
                          <span className="font-semibold text-primary">
                            Global Discount
                          </span>
                        ) : (
                          discount.product?.name
                        )}
                      </TableCell>
                      <TableCell>{discount.discountPercentage}%</TableCell>
                      <TableCell>{formatDate(discount.beginDate)}</TableCell>
                      <TableCell>{formatDate(discount.endDate)}</TableCell>
                      <TableCell>
                        {discount.requiresCode ? (
                          <span className="text-xs px-2 py-1 rounded-full bg-yellow-100 text-yellow-800 dark:bg-yellow-900/30 dark:text-yellow-400">
                            {discount.discountCode || "Yes"}
                          </span>
                        ) : (
                          <span className="text-xs">No</span>
                        )}
                      </TableCell>
                      <TableCell>
                        <span
                          className={`px-2 py-1 rounded-full text-xs font-medium ${statusClass}`}
                        >
                          {status}
                        </span>
                      </TableCell>
                    </TableRow>
                  );
                })}
              </TableBody>
            </Table>
          )}
        </CardContent>
      </Card>
    </div>
  );
}
