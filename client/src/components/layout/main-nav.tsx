import { Link, useLocation } from "react-router-dom";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { LogOut, User } from "lucide-react";
import { ModeToggle } from "@/components/mode-toggle";

export function MainNav() {
  const location = useLocation();
  const pathname = location.pathname;

  return (
    <div className="border-b">
      <div className="flex h-16 items-center px-4 container mx-auto">
        <Link to="/dashboard" className="font-bold text-xl mr-6">
          <img src="/logo.png" alt="Bespoked Bikes" className="h-8" />
        </Link>
        <nav className="flex items-center space-x-4 lg:space-x-6 mx-6">
          <Link
            to="/dashboard"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/dashboard"
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Dashboard
          </Link>
          <Link
            to="/salespersons"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/salespersons" ||
                pathname.startsWith("/salespersons/")
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Salespersons
          </Link>
          <Link
            to="/products"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/products" || pathname.startsWith("/products/")
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Products
          </Link>
          <Link
            to="/customers"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/customers" || pathname.startsWith("/customers/")
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Customers
          </Link>
          <Link
            to="/sales"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/sales" || pathname.startsWith("/sales/")
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Sales
          </Link>
          <Link
            to="/discounts"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/discounts" || pathname.startsWith("/discounts/")
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Discounts
          </Link>
          <Link
            to="/reports"
            className={cn(
              "text-sm font-medium transition-colors hover:text-primary",
              pathname === "/reports" || pathname.startsWith("/reports/")
                ? "text-primary"
                : "text-muted-foreground"
            )}
          >
            Reports
          </Link>
        </nav>
        <div className="ml-auto flex items-center space-x-4">
          <ModeToggle />
          <Button variant="ghost" size="sm" className="flex items-center gap-2">
            <User className="h-4 w-4" />
            <span>John Doe (Manager)</span>
          </Button>
          <Button variant="ghost" size="icon">
            <LogOut className="h-4 w-4" />
            <span className="sr-only">Log out</span>
          </Button>
        </div>
      </div>
    </div>
  );
}
