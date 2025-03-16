import { InventoryAlert } from "@/types/index";
import { Badge } from "@/components/ui/badge";
import { Skeleton } from "@/components/ui/skeleton";

interface InventoryAlertsListProps {
  inventoryAlerts?: InventoryAlert;
  isLoading: boolean;
}

export default function InventoryAlertsList({
  inventoryAlerts,
  isLoading,
}: InventoryAlertsListProps) {
  return (
    <div className="space-y-4">
      {isLoading ? (
        // Skeleton loading state for inventory alerts
        Array(4)
          .fill(0)
          .map((_, index) => (
            <div key={index} className="flex items-center">
              <div className="space-y-2">
                <Skeleton className="h-4 w-32" />
                <Skeleton className="h-3 w-24" />
              </div>
              <Skeleton className="h-6 w-24 ml-auto rounded-full" />
            </div>
          ))
      ) : (
        <>
          {/* Out of stock products */}
          {inventoryAlerts?.outOfStock?.map(
            (product: { id: number; name: string; quantityOnHand: number }) => (
              <div key={product.id} className="flex items-center">
                <div className="space-y-1">
                  <p className="text-sm font-medium leading-none">
                    {product.name}
                  </p>
                  <p className="text-sm text-muted-foreground">
                    {product.quantityOnHand} units remaining
                  </p>
                </div>
                <Badge variant="destructive" className="ml-auto">
                  Out of Stock
                </Badge>
              </div>
            )
          )}

          {/* Low stock products, sorted by quantity (lowest first) */}
          {inventoryAlerts?.lowStock
            ?.sort(
              (a: { quantityOnHand: number }, b: { quantityOnHand: number }) =>
                a.quantityOnHand - b.quantityOnHand
            )
            .map(
              (product: {
                id: number;
                name: string;
                quantityOnHand: number;
              }) => (
                <div key={product.id} className="flex items-center">
                  <div className="space-y-1">
                    <p className="text-sm font-medium leading-none">
                      {product.name}
                    </p>
                    <p className="text-sm text-muted-foreground">
                      {product.quantityOnHand} units remaining
                    </p>
                  </div>
                  <Badge variant="outline" className="ml-auto">
                    Low Stock
                  </Badge>
                </div>
              )
            )}

          {/* No alerts message */}
          {!inventoryAlerts?.outOfStock?.length &&
            !inventoryAlerts?.lowStock?.length && (
              <p className="text-center py-4 text-muted-foreground">
                No inventory alerts found.
              </p>
            )}
        </>
      )}
    </div>
  );
}
