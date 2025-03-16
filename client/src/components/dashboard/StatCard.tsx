import { ReactNode } from "react";
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";
import { Skeleton } from "@/components/ui/skeleton";

interface StatCardProps {
  title: string;
  value: string | number;
  icon: ReactNode;
  change?: number;
  changeText?: string;
  isLoading?: boolean;
}

export default function StatCard({
  title,
  value,
  icon,
  change,
  changeText,
  isLoading = false,
}: StatCardProps) {
  return (
    <Card>
      <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
        <CardTitle className="text-sm font-medium">{title}</CardTitle>
        <span className="h-4 w-4 text-muted-foreground">{icon}</span>
      </CardHeader>
      <CardContent>
        {isLoading ? (
          <>
            <Skeleton className="h-8 w-32" />
            <Skeleton className="h-4 w-40 mt-1" />
          </>
        ) : (
          <>
            <div className="text-2xl font-bold">{value}</div>
            {(change !== undefined || changeText) && (
              <p className="text-xs text-muted-foreground">
                {change !== undefined && (
                  <span>
                    {change > 0 ? "+" : ""}
                    {change.toFixed(1)}%{" "}
                  </span>
                )}
                {changeText || "from last period"}
              </p>
            )}
          </>
        )}
      </CardContent>
    </Card>
  );
}