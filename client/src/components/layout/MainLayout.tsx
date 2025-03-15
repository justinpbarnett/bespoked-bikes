import { Outlet, Link, useLocation } from "react-router-dom";
import { Bike, Users, User, ShoppingCart, BarChart, Menu, X } from "lucide-react";
import { useState } from "react";
import { cn } from "../../lib/utils";

const navItems = [
  {
    title: "Products",
    href: "/products",
    icon: <Bike className="w-5 h-5" />,
  },
  {
    title: "Salespersons",
    href: "/salespersons",
    icon: <Users className="w-5 h-5" />,
  },
  {
    title: "Customers",
    href: "/customers",
    icon: <User className="w-5 h-5" />,
  },
  {
    title: "Sales",
    href: "/sales",
    icon: <ShoppingCart className="w-5 h-5" />,
  },
  {
    title: "Reports",
    href: "/reports",
    icon: <BarChart className="w-5 h-5" />,
  },
];

export default function MainLayout() {
  const location = useLocation();
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  return (
    <div className="flex h-screen bg-gray-50">
      {/* Sidebar for desktop */}
      <div className="hidden md:flex md:w-64 md:flex-col">
        <div className="flex flex-col flex-grow pt-5 overflow-y-auto bg-white border-r">
          <div className="flex items-center flex-shrink-0 px-4">
            <h1 className="text-xl font-semibold">BeSpoked Bikes</h1>
          </div>
          <div className="flex flex-col flex-grow px-4 mt-5">
            <nav className="flex-1 space-y-1">
              {navItems.map((item) => {
                const isActive = location.pathname.startsWith(item.href);
                return (
                  <Link
                    key={item.title}
                    to={item.href}
                    className={cn(
                      "group flex items-center px-2 py-2 text-sm font-medium rounded-md",
                      isActive
                        ? "bg-blue-50 text-blue-600"
                        : "text-gray-600 hover:bg-gray-50 hover:text-gray-900"
                    )}
                  >
                    {item.icon}
                    <span className="ml-3">{item.title}</span>
                  </Link>
                );
              })}
            </nav>
          </div>
        </div>
      </div>

      {/* Mobile menu */}
      <div className="md:hidden">
        {mobileMenuOpen && (
          <div className="fixed inset-0 z-40 flex">
            <div className="fixed inset-0 bg-gray-600 bg-opacity-75" onClick={() => setMobileMenuOpen(false)}></div>
            <div className="relative flex flex-col flex-1 w-full max-w-xs pt-5 pb-4 bg-white">
              <div className="absolute top-0 right-0 pt-2 -mr-12">
                <button
                  type="button"
                  className="flex items-center justify-center w-10 h-10 ml-1 rounded-full focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
                  onClick={() => setMobileMenuOpen(false)}
                >
                  <span className="sr-only">Close sidebar</span>
                  <X className="w-6 h-6 text-white" />
                </button>
              </div>
              <div className="flex items-center flex-shrink-0 px-4">
                <h1 className="text-xl font-semibold">BeSpoked Bikes</h1>
              </div>
              <div className="flex flex-col flex-grow px-4 mt-5">
                <nav className="flex-1 space-y-1">
                  {navItems.map((item) => {
                    const isActive = location.pathname.startsWith(item.href);
                    return (
                      <Link
                        key={item.title}
                        to={item.href}
                        className={cn(
                          "group flex items-center px-2 py-2 text-base font-medium rounded-md",
                          isActive
                            ? "bg-blue-50 text-blue-600"
                            : "text-gray-600 hover:bg-gray-50 hover:text-gray-900"
                        )}
                        onClick={() => setMobileMenuOpen(false)}
                      >
                        {item.icon}
                        <span className="ml-3">{item.title}</span>
                      </Link>
                    );
                  })}
                </nav>
              </div>
            </div>
          </div>
        )}
      </div>

      {/* Main content */}
      <div className="flex flex-col flex-1 w-0 overflow-hidden">
        <div className="pt-1 pl-1 md:hidden sm:pl-3 sm:pt-3">
          <button
            type="button"
            className="-ml-0.5 -mt-0.5 h-12 w-12 inline-flex items-center justify-center rounded-md text-gray-500 hover:text-gray-900 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-blue-500"
            onClick={() => setMobileMenuOpen(true)}
          >
            <span className="sr-only">Open sidebar</span>
            <Menu className="w-6 h-6" />
          </button>
        </div>
        <main className="relative flex-1 overflow-y-auto focus:outline-none">
          <div className="py-6">
            <div className="px-4 mx-auto max-w-7xl sm:px-6 md:px-8">
              <Outlet />
            </div>
          </div>
        </main>
      </div>
    </div>
  );
}