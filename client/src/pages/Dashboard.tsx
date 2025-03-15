"use client"
import { useState } from "react"
import { Link } from "react-router-dom"
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs"
import {
  BarChart3,
  Users,
  ShoppingCart,
  Package,
  DollarSign,
  AlertTriangle,
  TrendingUp,
  Calendar,
  PlusCircle,
} from "lucide-react"
import { Progress } from "@/components/ui/progress"
import { Avatar, AvatarFallback } from "@/components/ui/avatar"
import { Badge } from "@/components/ui/badge"
import { SalesCommissionChart } from "../components/SalesCommissionChart"

// Sample data for demonstration
const salesData = [
  {
    id: 1,
    product: "Mountain Explorer",
    customer: "John Smith",
    date: "2023-05-15",
    price: 899.99,
    salesperson: "Jane Doe",
  },
  {
    id: 2,
    product: "City Cruiser",
    customer: "Emily Johnson",
    date: "2023-05-18",
    price: 539.99,
    salesperson: "Jane Doe",
  },
  {
    id: 3,
    product: "Road Warrior",
    customer: "Michael Brown",
    date: "2023-05-20",
    price: 1169.99,
    salesperson: "John Doe",
  },
  {
    id: 4,
    product: "Commuter Pro",
    customer: "Sarah Wilson",
    date: "2023-05-22",
    price: 749.99,
    salesperson: "Jane Doe",
  },
  {
    id: 5,
    product: "Speed Demon",
    customer: "David Miller",
    date: "2023-05-25",
    price: 1439.99,
    salesperson: "Michael Johnson",
  },
]

const lowStockProducts = [
  { id: 3, name: "Road Warrior", manufacturer: "SpeedMaster", qtyOnHand: 5, reorderLevel: 10 },
  { id: 6, name: "Speed Demon", manufacturer: "SpeedMaster", qtyOnHand: 3, reorderLevel: 8 },
]

const outOfStockProducts = [
  { id: 4, name: "Trail Blazer", manufacturer: "BikeWorks", qtyOnHand: 0 },
  { id: 7, name: "Dirt Devil", manufacturer: "BikeWorks", qtyOnHand: 0 },
]

const topSalespersons = [
  { id: 2, name: "Jane Doe", sales: 35000, target: 40000, avatar: "JD" },
  { id: 1, name: "John Doe", sales: 28000, target: 35000, avatar: "JD" },
  { id: 3, name: "Michael Johnson", sales: 42000, target: 40000, avatar: "MJ" },
]

// Chart data
const monthlySalesData = [
  { label: "Jan", sales: 25000, commission: 2500 },
  { label: "Feb", sales: 30000, commission: 3000 },
  { label: "Mar", sales: 28000, commission: 2800 },
  { label: "Apr", sales: 35000, commission: 3500 },
  { label: "May", sales: 40000, commission: 4000 },
  { label: "Jun", sales: 45000, commission: 4500 },
]

export default function Dashboard() {
  // Format currency for display
  const formatCurrency = (amount: number) => {
    return new Intl.NumberFormat("en-US", { style: "currency", currency: "USD" }).format(amount)
  }

  // Format date for display
  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString()
  }

  // Calculate total sales
  const totalSales = salesData.reduce((total, sale) => total + sale.price, 0)

  return (
    <div className="container mx-auto py-10">
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center mb-8">
        <div>
          <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
          <p className="text-muted-foreground">Welcome back, Manager. Here's an overview of your bike shop.</p>
        </div>
        <div className="flex gap-2 mt-4 md:mt-0">
          <Button asChild>
            <Link to="/sales/new">
              <PlusCircle className="mr-2 h-4 w-4" />
              Record Sale
            </Link>
          </Button>
          <Button variant="outline" asChild>
            <Link to="/reports">
              <BarChart3 className="mr-2 h-4 w-4" />
              View Reports
            </Link>
          </Button>
        </div>
      </div>

      {/* Sales and Commission Chart */}
      <SalesCommissionChart
        data={monthlySalesData}
        title="Monthly Sales & Commission"
        description="Overview of sales and commission for the current year"
        chartType="area"
        timeRangeSelector={true}
      />

      <Tabs defaultValue="overview" className="space-y-4 mt-8">
        <TabsList>
          <TabsTrigger value="overview">Overview</TabsTrigger>
          <TabsTrigger value="analytics">Analytics</TabsTrigger>
          <TabsTrigger value="inventory">Inventory</TabsTrigger>
          <TabsTrigger value="team">Team</TabsTrigger>
        </TabsList>

        <TabsContent value="overview" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Total Revenue</CardTitle>
                <DollarSign className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{formatCurrency(totalSales)}</div>
                <p className="text-xs text-muted-foreground">+20.1% from last month</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Sales</CardTitle>
                <ShoppingCart className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{salesData.length}</div>
                <p className="text-xs text-muted-foreground">+12.5% from last month</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Active Salespersons</CardTitle>
                <Users className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{topSalespersons.length}</div>
                <p className="text-xs text-muted-foreground">No change from last month</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Inventory Alerts</CardTitle>
                <AlertTriangle className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{lowStockProducts.length + outOfStockProducts.length}</div>
                <p className="text-xs text-muted-foreground">
                  {outOfStockProducts.length} out of stock, {lowStockProducts.length} low stock
                </p>
              </CardContent>
            </Card>
          </div>

          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7">
            <Card className="col-span-4">
              <CardHeader>
                <CardTitle>Recent Sales</CardTitle>
                <CardDescription>The most recent sales transactions.</CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {salesData.slice(0, 5).map((sale) => (
                    <div key={sale.id} className="flex items-center">
                      <div className="space-y-1">
                        <p className="text-sm font-medium leading-none">{sale.product}</p>
                        <p className="text-sm text-muted-foreground">
                          Sold by {sale.salesperson} to {sale.customer}
                        </p>
                      </div>
                      <div className="ml-auto font-medium">{formatCurrency(sale.price)}</div>
                    </div>
                  ))}
                </div>
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/sales">View All Sales</Link>
                </Button>
              </CardFooter>
            </Card>

            <Card className="col-span-3">
              <CardHeader>
                <CardTitle>Inventory Alerts</CardTitle>
                <CardDescription>Products that need attention.</CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {outOfStockProducts.map((product) => (
                    <div key={product.id} className="flex items-center">
                      <div className="space-y-1">
                        <p className="text-sm font-medium leading-none">{product.name}</p>
                        <p className="text-sm text-muted-foreground">{product.manufacturer}</p>
                      </div>
                      <Badge variant="destructive" className="ml-auto">
                        Out of Stock
                      </Badge>
                    </div>
                  ))}

                  {lowStockProducts.map((product) => (
                    <div key={product.id} className="flex items-center">
                      <div className="space-y-1">
                        <p className="text-sm font-medium leading-none">{product.name}</p>
                        <p className="text-sm text-muted-foreground">{product.manufacturer}</p>
                      </div>
                      <Badge variant="outline" className="ml-auto">
                        Low Stock: {product.qtyOnHand}
                      </Badge>
                    </div>
                  ))}
                </div>
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/products">Manage Inventory</Link>
                </Button>
              </CardFooter>
            </Card>
          </div>
        </TabsContent>

        <TabsContent value="analytics" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
            <Card className="col-span-2">
              <CardHeader>
                <CardTitle>Sales Performance</CardTitle>
                <CardDescription>Monthly sales performance for the current quarter.</CardDescription>
              </CardHeader>
              <CardContent>
                <SalesCommissionChart data={monthlySalesData.slice(3)} title="" description="" chartType="bar" />
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Top Products</CardTitle>
                <CardDescription>Best selling products this month.</CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  <div className="space-y-2">
                    <div className="flex items-center justify-between">
                      <div className="text-sm font-medium">Mountain Explorer</div>
                      <div className="text-sm text-muted-foreground">35%</div>
                    </div>
                    <Progress value={35} />
                  </div>

                  <div className="space-y-2">
                    <div className="flex items-center justify-between">
                      <div className="text-sm font-medium">Road Warrior</div>
                      <div className="text-sm text-muted-foreground">25%</div>
                    </div>
                    <Progress value={25} />
                  </div>

                  <div className="space-y-2">
                    <div className="flex items-center justify-between">
                      <div className="text-sm font-medium">City Cruiser</div>
                      <div className="text-sm text-muted-foreground">20%</div>
                    </div>
                    <Progress value={20} />
                  </div>

                  <div className="space-y-2">
                    <div className="flex items-center justify-between">
                      <div className="text-sm font-medium">Speed Demon</div>
                      <div className="text-sm text-muted-foreground">15%</div>
                    </div>
                    <Progress value={15} />
                  </div>

                  <div className="space-y-2">
                    <div className="flex items-center justify-between">
                      <div className="text-sm font-medium">Commuter Pro</div>
                      <div className="text-sm text-muted-foreground">5%</div>
                    </div>
                    <Progress value={5} />
                  </div>
                </div>
              </CardContent>
            </Card>
          </div>

          <Card>
            <CardHeader>
              <CardTitle>Quarterly Targets</CardTitle>
              <CardDescription>Progress towards quarterly sales targets.</CardDescription>
            </CardHeader>
            <CardContent>
              <div className="grid gap-6 md:grid-cols-3">
                {topSalespersons.map((person) => (
                  <div key={person.id} className="space-y-2">
                    <div className="flex items-center gap-2">
                      <Avatar className="h-8 w-8">
                        <AvatarFallback>{person.avatar}</AvatarFallback>
                      </Avatar>
                      <div className="space-y-1">
                        <p className="text-sm font-medium leading-none">{person.name}</p>
                        <p className="text-sm text-muted-foreground">
                          {formatCurrency(person.sales)} / {formatCurrency(person.target)}
                        </p>
                      </div>
                    </div>
                    <Progress value={(person.sales / person.target) * 100} />
                  </div>
                ))}
              </div>
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="inventory" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Total Products</CardTitle>
                <Package className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">24</div>
                <p className="text-xs text-muted-foreground">Across 5 categories</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Out of Stock</CardTitle>
                <AlertTriangle className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{outOfStockProducts.length}</div>
                <p className="text-xs text-muted-foreground">Requires immediate attention</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Low Stock</CardTitle>
                <AlertTriangle className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{lowStockProducts.length}</div>
                <p className="text-xs text-muted-foreground">Below reorder threshold</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Inventory Value</CardTitle>
                <DollarSign className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{formatCurrency(85000)}</div>
                <p className="text-xs text-muted-foreground">Total value of current inventory</p>
              </CardContent>
            </Card>
          </div>

          <div className="grid gap-4 md:grid-cols-2">
            <Card>
              <CardHeader>
                <CardTitle>Inventory by Category</CardTitle>
                <CardDescription>Distribution of products by category.</CardDescription>
              </CardHeader>
              <CardContent className="h-[300px] flex items-center justify-center">
                <div className="text-center text-muted-foreground">
                  <Package className="mx-auto h-12 w-12 mb-2" />
                  <p>Inventory chart would be displayed here</p>
                  <p className="text-sm">Using a charting library like Recharts</p>
                </div>
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Inventory Alerts</CardTitle>
                <CardDescription>Products that need attention.</CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {outOfStockProducts.map((product) => (
                    <div key={product.id} className="flex items-center">
                      <div className="space-y-1">
                        <p className="text-sm font-medium leading-none">{product.name}</p>
                        <p className="text-sm text-muted-foreground">{product.manufacturer}</p>
                      </div>
                      <Badge variant="destructive" className="ml-auto">
                        Out of Stock
                      </Badge>
                    </div>
                  ))}

                  {lowStockProducts.map((product) => (
                    <div key={product.id} className="flex items-center">
                      <div className="space-y-1">
                        <p className="text-sm font-medium leading-none">{product.name}</p>
                        <p className="text-sm text-muted-foreground">{product.manufacturer}</p>
                      </div>
                      <Badge variant="outline" className="ml-auto">
                        Low Stock: {product.qtyOnHand}
                      </Badge>
                    </div>
                  ))}
                </div>
              </CardContent>
              <CardFooter>
                <Button variant="outline" asChild className="w-full">
                  <Link to="/products">Manage Inventory</Link>
                </Button>
              </CardFooter>
            </Card>
          </div>
        </TabsContent>

        <TabsContent value="team" className="space-y-4">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Active Salespersons</CardTitle>
                <Users className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{topSalespersons.length}</div>
                <p className="text-xs text-muted-foreground">Full-time team members</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Top Performer</CardTitle>
                <TrendingUp className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">Michael Johnson</div>
                <p className="text-xs text-muted-foreground">{formatCurrency(42000)} in sales this quarter</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Average Sales</CardTitle>
                <ShoppingCart className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{formatCurrency(35000)}</div>
                <p className="text-xs text-muted-foreground">Per salesperson this quarter</p>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Next Review</CardTitle>
                <Calendar className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">June 15</div>
                <p className="text-xs text-muted-foreground">Quarterly performance reviews</p>
              </CardContent>
            </Card>
          </div>

          <Card>
            <CardHeader>
              <CardTitle>Team Performance</CardTitle>
              <CardDescription>Sales performance by team member.</CardDescription>
            </CardHeader>
            <CardContent>
              <div className="space-y-8">
                {topSalespersons.map((person) => (
                  <div key={person.id} className="space-y-2">
                    <div className="flex items-center">
                      <Avatar className="h-9 w-9">
                        <AvatarFallback>{person.avatar}</AvatarFallback>
                      </Avatar>
                      <div className="ml-4 space-y-1">
                        <p className="text-sm font-medium leading-none">{person.name}</p>
                        <p className="text-sm text-muted-foreground">
                          {formatCurrency(person.sales)} / {formatCurrency(person.target)}
                        </p>
                      </div>
                      <div className="ml-auto font-medium">{Math.round((person.sales / person.target) * 100)}%</div>
                    </div>
                    <Progress value={(person.sales / person.target) * 100} className="h-2" />
                  </div>
                ))}
              </div>
            </CardContent>
            <CardFooter>
              <Button variant="outline" asChild className="w-full">
                <Link to="/salespersons">View All Team Members</Link>
              </Button>
            </CardFooter>
          </Card>
        </TabsContent>
      </Tabs>
    </div>
  )
}