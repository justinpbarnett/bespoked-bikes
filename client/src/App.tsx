import { Routes, Route, Navigate } from "react-router-dom";
import { ThemeProvider } from "@/components/theme-provider";
import MainLayout from "@/components/layout/MainLayout";

// Lazy-loaded page components
import Dashboard from "@/pages/Dashboard";

// We'll lazy load other pages for better performance
import { lazy, Suspense } from "react";
import { Skeleton } from "@/components/ui/skeleton";

// Lazy loaded components
const Products = lazy(() => import("@/pages/products"));
const Salespersons = lazy(() => import("@/pages/salespersons"));
const Customers = lazy(() => import("@/pages/customers"));
const Sales = lazy(() => import("@/pages/sales"));
const Discounts = lazy(() => import("@/pages/discounts"));
const Reports = lazy(() => import("@/pages/Reports"));

// Loading fallback for lazy-loaded routes
const PageSkeleton = () => (
  <div className="w-full space-y-4 p-8">
    <Skeleton className="h-8 w-48" />
    <Skeleton className="h-4 w-full" />
    <Skeleton className="h-64 w-full" />
  </div>
);

function App() {
  return (
    <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
      <Routes>
        <Route path="/" element={<MainLayout />}>
          {/* Default route redirects to dashboard */}
          <Route index element={<Navigate to="/dashboard" replace />} />
          
          {/* Eagerly loaded dashboard as it's the main page */}
          <Route path="dashboard" element={<Dashboard />} />
          
          {/* Lazy-loaded routes */}
          <Route path="products" element={
            <Suspense fallback={<PageSkeleton />}>
              <Products />
            </Suspense>
          } />
          <Route path="salespersons" element={
            <Suspense fallback={<PageSkeleton />}>
              <Salespersons />
            </Suspense>
          } />
          <Route path="customers" element={
            <Suspense fallback={<PageSkeleton />}>
              <Customers />
            </Suspense>
          } />
          <Route path="sales" element={
            <Suspense fallback={<PageSkeleton />}>
              <Sales />
            </Suspense>
          } />
          <Route path="discounts" element={
            <Suspense fallback={<PageSkeleton />}>
              <Discounts />
            </Suspense>
          } />
          <Route path="reports" element={
            <Suspense fallback={<PageSkeleton />}>
              <Reports />
            </Suspense>
          } />
          
          {/* Catch all route redirects to dashboard */}
          <Route path="*" element={<Navigate to="/dashboard" replace />} />
        </Route>
      </Routes>
    </ThemeProvider>
  );
}

export default App;
