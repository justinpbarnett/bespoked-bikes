import { Routes, Route, Navigate } from "react-router-dom";
import MainLayout from "./components/layout/MainLayout";
import Products from "./components/products/Products";
import Salespersons from "./components/salespersons/Salespersons";
import Customers from "./components/customers/Customers";
import Sales from "./components/sales/Sales";
import Reports from "./components/reports/Reports";
import "./App.css";

function App() {
  return (
    <Routes>
      <Route path="/" element={<MainLayout />}>
        <Route index element={<Navigate to="/products" replace />} />
        <Route path="products" element={<Products />} />
        <Route path="salespersons" element={<Salespersons />} />
        <Route path="customers" element={<Customers />} />
        <Route path="sales" element={<Sales />} />
        <Route path="reports" element={<Reports />} />
        <Route path="*" element={<Navigate to="/products" replace />} />
      </Route>
    </Routes>
  );
}

export default App;
