import { ReactNode } from "react";
import StatCard from "./StatCard";

interface Metric {
  title: string;
  value: string | number;
  icon: ReactNode;
  change?: number;
  changeText?: string;
}

interface MetricsGridProps {
  metrics: Metric[];
  isLoading?: boolean;
  columns?: 2 | 3 | 4;
  className?: string;
}

export default function MetricsGrid({
  metrics,
  isLoading = false,
  columns = 4,
  className = "",
}: MetricsGridProps) {
  const columnClass = {
    2: "md:grid-cols-2",
    3: "md:grid-cols-3",
    4: "md:grid-cols-2 lg:grid-cols-4",
  }[columns];

  return (
    <div className={`grid gap-4 ${columnClass} ${className}`}>
      {metrics.map((metric, index) => (
        <StatCard
          key={index}
          title={metric.title}
          value={metric.value}
          icon={metric.icon}
          change={metric.change}
          changeText={metric.changeText}
          isLoading={isLoading}
        />
      ))}
    </div>
  );
}