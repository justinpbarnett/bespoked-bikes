import { RecentSale } from "@/types/index";
import { Skeleton } from "@/components/ui/skeleton";

interface RecentSalesListProps {
  recentSales?: RecentSale[];
  isLoading: boolean;
  formatCurrency: (amount: number) => string;
}

export default function RecentSalesList({
  recentSales,
  isLoading,
  formatCurrency,
}: RecentSalesListProps) {
  return (
    <div className="space-y-4">
      {isLoading ? (
        // Skeleton loading state for recent sales
        Array(5)
          .fill(0)
          .map((_, index) => (
            <div key={index} className="flex items-center">
              <div className="space-y-2">
                <Skeleton className="h-4 w-36" />
                <Skeleton className="h-3 w-48" />
              </div>
              <Skeleton className="h-4 w-20 ml-auto" />
            </div>
          ))
      ) : recentSales && recentSales.length > 0 ? (
        // Actual data
        recentSales.map((sale: RecentSale) => (
          <div key={sale.id} className="flex items-center">
            <div className="space-y-1">
              <div className="text-sm font-medium">
                {sale.product}
              </div>
              <div className="text-sm text-muted-foreground">
                {sale.salesperson} • {sale.customer}
              </div>
            </div>
            <div className="ml-auto font-medium">
              {formatCurrency(sale.salePrice)}
            </div>
          </div>
        ))
      ) : (
        // No sales found
        <p className="text-center py-4 text-muted-foreground">
          No recent sales found.
        </p>
      )}
    </div>
  );
}