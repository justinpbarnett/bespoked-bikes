import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getCommissionReport } from "../services/api";
import type {
  CommissionReport,
  DetailedSale,
  ExtendedSalespersonCommission,
} from "../types/index";
import { Button } from "../components/ui/button";
import { Label } from "../components/ui/label";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "../components/ui/table";
import { format } from "date-fns";
import {
  BarChart3,
  Calendar,
  Download,
  FileSpreadsheet,
  FilePlus2,
  FileText,
  PieChart,
  Search,
  UserCircle,
} from "lucide-react";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../components/ui/card";
import {
  Tabs,
  TabsContent,
  TabsList,
  TabsTrigger,
} from "../components/ui/tabs";

export default function Reports() {
  const [filter, setFilter] = useState({
    year: new Date().getFullYear(),
    quarter: Math.floor(new Date().getMonth() / 3) + 1,
  });

  const [showReport, setShowReport] = useState(false);
  const [selectedSalesperson, setSelectedSalesperson] =
    useState<ExtendedSalespersonCommission | null>(null);

  const {
    data: report,
    isLoading,
    error,
    refetch,
  } = useQuery<CommissionReport>({
    queryKey: ["commissionReport", filter.year, filter.quarter],
    queryFn: () => getCommissionReport(filter.year, filter.quarter),
    enabled: false, // Don't automatically fetch
  });

  const handleYearChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setFilter((prev) => ({ ...prev, year: parseInt(e.target.value, 10) }));
    setShowReport(false);
  };

  const handleQuarterChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setFilter((prev) => ({ ...prev, quarter: parseInt(e.target.value, 10) }));
    setShowReport(false);
  };

  const handleGenerateReport = async () => {
    await refetch();
    setShowReport(true);
    setSelectedSalesperson(null);
  };

  const formatDate = (dateString: string | undefined | null): string => {
    if (!dateString) return "N/A";
    return format(new Date(dateString), "MMM d, yyyy");
  };

  const formatCurrency = (amount: number) => {
    return new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
    }).format(amount);
  };

  const formatPercentage = (value: number) => {
    return `${value.toFixed(2)}%`;
  };

  const getMonthName = (monthNum: number) => {
    const months = [
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December",
    ];
    return months[monthNum - 1];
  };

  const exportToCSV = () => {
    if (!report) return;

    // Create a more comprehensive CSV with all report data
    const detailedReport = [
      `BeSpoked Bikes - Q${report.quarter} ${report.year} Commission Report`,
      `Period: ${formatDate(report.startDate)} - ${formatDate(report.endDate)}`,
      "",
      "QUARTER SUMMARY",
      `Total Sales,${report.quarterSummary.totalSales}`,
      `Total Revenue,${formatCurrency(report.quarterSummary.totalRevenue)}`,
      `Total Commission,${formatCurrency(
        report.quarterSummary.totalCommission
      )}`,
      `Average Commission Rate,${formatPercentage(
        report.quarterSummary.averageCommissionRate
      )}`,
      `Average Sale Price,${formatCurrency(
        report.quarterSummary.averageSalePrice
      )}`,
      `Salespersons with Sales,${report.quarterSummary.salespersonsWithSales} of ${report.quarterSummary.salespersonCount}`,
      "",
      "MONTHLY BREAKDOWN",
      "Month,Total Sales,Total Revenue,Total Commission",
      ...report.monthlySummary.map(
        (month) =>
          `${getMonthName(month.month)} ${month.year},${
            month.totalSales
          },${formatCurrency(month.totalRevenue)},${formatCurrency(
            month.totalCommission
          )}`
      ),
      "",
      "PRODUCT STYLE BREAKDOWN",
      "Style,Total Sales,Total Revenue,Total Commission,Average Price",
      ...report.productStyles.map(
        (style) =>
          `${style.style},${style.totalSales},${formatCurrency(
            style.revenue
          )},${formatCurrency(style.totalCommission)},${formatCurrency(
            style.averagePrice
          )}`
      ),
      "",
      "TOP PRODUCTS",
      "Product,Manufacturer,Total Sales,Total Revenue,Total Commission",
      ...report.topProducts.map(
        (product) =>
          `${product.productName},${product.manufacturer},${
            product.totalSales
          },${formatCurrency(product.totalRevenue)},${formatCurrency(
            product.totalCommission
          )}`
      ),
      "",
      "SALESPERSON COMMISSIONS",
      "Salesperson,Manager,Total Sales,Total Revenue,Total Commission,Avg Commission Rate,Highest Sale,Lowest Sale",
      ...report.commissions.map(
        (commission) =>
          `${commission.firstName} ${commission.lastName},${
            commission.manager || "N/A"
          },${commission.totalSales},${formatCurrency(
            commission.totalRevenue
          )},${formatCurrency(commission.totalCommission)},${formatPercentage(
            commission.averageCommissionRate
          )},${formatCurrency(commission.highestSale)},${formatCurrency(
            commission.lowestSale
          )}`
      ),
    ];

    // Add detailed sales for each salesperson if they have any
    report.commissions.forEach((sp: ExtendedSalespersonCommission) => {
      if (sp.detailedSales.length > 0) {
        detailedReport.push("");
        detailedReport.push(`DETAILED SALES - ${sp.firstName} ${sp.lastName}`);
        detailedReport.push(
          "Sale Date,Product,Customer,Sale Price,Commission Amount,Commission Rate"
        );

        sp.detailedSales.forEach((sale: DetailedSale) => {
          detailedReport.push(
            `${formatDate(sale.saleDate)},${sale.productName},${
              sale.customerName
            },${formatCurrency(sale.salePrice)},${formatCurrency(
              sale.commissionAmount
            )},${formatPercentage(sale.commissionRate)}`
          );
        });
      }
    });

    const csvContent = detailedReport.join("\n");
    const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
    const url = URL.createObjectURL(blob);
    const link = document.createElement("a");
    link.setAttribute("href", url);
    link.setAttribute(
      "download",
      `commission_report_q${report.quarter}_${report.year}_detailed.csv`
    );
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  };

  if (isLoading) {
    return <div>Loading report...</div>;
  }

  if (error) {
    return <div>Error loading report: {error.toString()}</div>;
  }

  const years = [];
  const currentYearNum = new Date().getFullYear();
  for (let year = currentYearNum - 5; year <= currentYearNum + 1; year++) {
    years.push(year);
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Quarterly Commission Report</h1>
      </div>

      <div className="bg-card p-4 rounded-lg shadow">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-4">
          <div className="space-y-2">
            <Label htmlFor="year">Year</Label>
            <select
              id="year"
              value={filter.year}
              onChange={handleYearChange}
              className="w-full h-10 px-3 py-2 rounded-md border border-input bg-[hsl(var(--background))]"
            >
              {years.map((year) => (
                <option key={year} value={year}>
                  {year}
                </option>
              ))}
            </select>
          </div>
          <div className="space-y-2">
            <Label htmlFor="quarter">Quarter</Label>
            <select
              id="quarter"
              value={filter.quarter}
              onChange={handleQuarterChange}
              className="w-full h-10 px-3 py-2 rounded-md border border-input bg-[hsl(var(--background))]"
            >
              <option value={1}>Q1 (Jan-Mar)</option>
              <option value={2}>Q2 (Apr-Jun)</option>
              <option value={3}>Q3 (Jul-Sep)</option>
              <option value={4}>Q4 (Oct-Dec)</option>
            </select>
          </div>
          <div className="flex items-end gap-2">
            <Button onClick={handleGenerateReport} className="mb-0.5" size="lg">
              <FilePlus2 className="w-5 h-5 mr-2" />
              Generate Report
            </Button>
          </div>
        </div>

        {showReport && report && (
          <>
            <div className="mb-4">
              <div className="flex justify-between items-center">
                <div>
                  <h2 className="text-xl font-semibold">
                    Q{report.quarter} {report.year} Commission Report
                  </h2>
                  <p className="text-gray-500">
                    {formatDate(report.startDate)} -{" "}
                    {formatDate(report.endDate)}
                  </p>
                </div>

                {report.commissions.length > 0 && (
                  <Button
                    variant="outline"
                    onClick={exportToCSV}
                    className="mb-0.5"
                  >
                    <Download className="w-4 h-4 mr-2" />
                    Export Detailed CSV
                  </Button>
                )}
              </div>
            </div>

            {report.quarterSummary.totalSales > 0 ? (
              <>
                {/* Quarter Summary Cards */}
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 mb-6">
                  <Card>
                    <CardHeader className="pb-2">
                      <CardTitle className="text-sm font-medium text-muted-foreground">
                        Total Sales
                      </CardTitle>
                    </CardHeader>
                    <CardContent>
                      <div className="text-2xl font-bold">
                        {report.quarterSummary.totalSales}
                      </div>
                      <p className="text-xs text-muted-foreground">
                        {formatCurrency(report.quarterSummary.totalRevenue)}{" "}
                        revenue
                      </p>
                    </CardContent>
                  </Card>

                  <Card>
                    <CardHeader className="pb-2">
                      <CardTitle className="text-sm font-medium text-muted-foreground">
                        Total Commission
                      </CardTitle>
                    </CardHeader>
                    <CardContent>
                      <div className="text-2xl font-bold">
                        {formatCurrency(report.quarterSummary.totalCommission)}
                      </div>
                      <p className="text-xs text-muted-foreground">
                        {formatPercentage(
                          report.quarterSummary.averageCommissionRate
                        )}{" "}
                        avg rate
                      </p>
                    </CardContent>
                  </Card>

                  <Card>
                    <CardHeader className="pb-2">
                      <CardTitle className="text-sm font-medium text-muted-foreground">
                        Average Sale
                      </CardTitle>
                    </CardHeader>
                    <CardContent>
                      <div className="text-2xl font-bold">
                        {formatCurrency(report.quarterSummary.averageSalePrice)}
                      </div>
                      <p className="text-xs text-muted-foreground">
                        per transaction
                      </p>
                    </CardContent>
                  </Card>

                  <Card>
                    <CardHeader className="pb-2">
                      <CardTitle className="text-sm font-medium text-muted-foreground">
                        Active Salespersons
                      </CardTitle>
                    </CardHeader>
                    <CardContent>
                      <div className="text-2xl font-bold">
                        {report.quarterSummary.salespersonsWithSales} /{" "}
                        {report.quarterSummary.salespersonCount}
                      </div>
                      <p className="text-xs text-muted-foreground">
                        made sales this quarter
                      </p>
                    </CardContent>
                  </Card>
                </div>

                {/* Main Report Tabs */}
                <Tabs defaultValue="salespersons" className="w-full">
                  <TabsList className="mb-4">
                    <TabsTrigger value="salespersons">
                      <UserCircle className="w-4 h-4 mr-2" />
                      Salespersons
                    </TabsTrigger>
                    <TabsTrigger value="products">
                      <PieChart className="w-4 h-4 mr-2" />
                      Products
                    </TabsTrigger>
                    <TabsTrigger value="monthly">
                      <Calendar className="w-4 h-4 mr-2" />
                      Monthly
                    </TabsTrigger>
                    {selectedSalesperson && (
                      <TabsTrigger value="details">
                        <FileText className="w-4 h-4 mr-2" />
                        {selectedSalesperson.firstName}{" "}
                        {selectedSalesperson.lastName}
                      </TabsTrigger>
                    )}
                  </TabsList>

                  {/* Salespersons Tab */}
                  <TabsContent value="salespersons" className="space-y-4">
                    <Card>
                      <CardHeader>
                        <CardTitle>Salesperson Commissions</CardTitle>
                        <CardDescription>
                          Quarterly performance of all salespersons
                        </CardDescription>
                      </CardHeader>
                      <CardContent>
                        <Table>
                          <TableHeader>
                            <TableRow>
                              <TableHead>Salesperson</TableHead>
                              <TableHead>Manager</TableHead>
                              <TableHead>Total Sales</TableHead>
                              <TableHead>Total Revenue</TableHead>
                              <TableHead>Commission</TableHead>
                              <TableHead>Rate</TableHead>
                              <TableHead>Details</TableHead>
                            </TableRow>
                          </TableHeader>
                          <TableBody>
                            {report.commissions.map(
                              (sp: ExtendedSalespersonCommission) => (
                                <TableRow key={sp.salespersonId}>
                                  <TableCell className="font-medium">
                                    {sp.firstName} {sp.lastName}
                                  </TableCell>
                                  <TableCell>{sp.manager || "N/A"}</TableCell>
                                  <TableCell>{sp.totalSales}</TableCell>
                                  <TableCell>
                                    {formatCurrency(sp.totalRevenue)}
                                  </TableCell>
                                  <TableCell>
                                    {formatCurrency(sp.totalCommission)}
                                  </TableCell>
                                  <TableCell>
                                    {formatPercentage(sp.averageCommissionRate)}
                                  </TableCell>
                                  <TableCell>
                                    {sp.totalSales > 0 && (
                                      <Button
                                        variant="ghost"
                                        size="sm"
                                        onClick={() => {
                                          setSelectedSalesperson(sp);
                                        }}
                                      >
                                        View
                                      </Button>
                                    )}
                                  </TableCell>
                                </TableRow>
                              )
                            )}
                          </TableBody>
                        </Table>
                      </CardContent>
                    </Card>
                  </TabsContent>

                  {/* Products Tab */}
                  <TabsContent value="products" className="space-y-4">
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                      {/* Top Products */}
                      <Card>
                        <CardHeader>
                          <CardTitle>Top Products</CardTitle>
                          <CardDescription>
                            Best-selling products by revenue
                          </CardDescription>
                        </CardHeader>
                        <CardContent>
                          <Table>
                            <TableHeader>
                              <TableRow>
                                <TableHead>Product</TableHead>
                                <TableHead>Sales</TableHead>
                                <TableHead>Revenue</TableHead>
                              </TableRow>
                            </TableHeader>
                            <TableBody>
                              {report.topProducts.map((product) => (
                                <TableRow key={product.productId}>
                                  <TableCell className="font-medium">
                                    {product.productName}
                                    <div className="text-xs text-muted-foreground">
                                      {product.manufacturer}
                                    </div>
                                  </TableCell>
                                  <TableCell>{product.totalSales}</TableCell>
                                  <TableCell>
                                    {formatCurrency(product.totalRevenue)}
                                  </TableCell>
                                </TableRow>
                              ))}
                            </TableBody>
                          </Table>
                        </CardContent>
                      </Card>

                      {/* Product Styles */}
                      <Card>
                        <CardHeader>
                          <CardTitle>Sales by Style</CardTitle>
                          <CardDescription>
                            Performance breakdown by product style
                          </CardDescription>
                        </CardHeader>
                        <CardContent>
                          <Table>
                            <TableHeader>
                              <TableRow>
                                <TableHead>Style</TableHead>
                                <TableHead>Sales</TableHead>
                                <TableHead>Avg Price</TableHead>
                                <TableHead>Revenue</TableHead>
                              </TableRow>
                            </TableHeader>
                            <TableBody>
                              {report.productStyles.map((style) => (
                                <TableRow key={style.style}>
                                  <TableCell className="font-medium">
                                    {style.style}
                                  </TableCell>
                                  <TableCell>{style.totalSales}</TableCell>
                                  <TableCell>
                                    {formatCurrency(style.averagePrice)}
                                  </TableCell>
                                  <TableCell>
                                    {formatCurrency(style.revenue)}
                                  </TableCell>
                                </TableRow>
                              ))}
                            </TableBody>
                          </Table>
                        </CardContent>
                      </Card>
                    </div>
                  </TabsContent>

                  {/* Monthly Tab */}
                  <TabsContent value="monthly" className="space-y-4">
                    <Card>
                      <CardHeader>
                        <CardTitle>Monthly Breakdown</CardTitle>
                        <CardDescription>
                          Sales and commission by month
                        </CardDescription>
                      </CardHeader>
                      <CardContent>
                        <div className="h-[300px] flex items-center justify-center text-muted-foreground">
                          <BarChart3 className="w-8 h-8 mr-2" />
                          <span>Monthly data visualization would be here</span>
                        </div>
                        <Table className="mt-4">
                          <TableHeader>
                            <TableRow>
                              <TableHead>Month</TableHead>
                              <TableHead>Sales</TableHead>
                              <TableHead>Revenue</TableHead>
                              <TableHead>Commission</TableHead>
                            </TableRow>
                          </TableHeader>
                          <TableBody>
                            {report.monthlySummary.map((month, index) => (
                              <TableRow key={index}>
                                <TableCell className="font-medium">
                                  {getMonthName(month.month)} {month.year}
                                </TableCell>
                                <TableCell>{month.totalSales}</TableCell>
                                <TableCell>
                                  {formatCurrency(month.totalRevenue)}
                                </TableCell>
                                <TableCell>
                                  {formatCurrency(month.totalCommission)}
                                </TableCell>
                              </TableRow>
                            ))}
                          </TableBody>
                        </Table>
                      </CardContent>
                    </Card>
                  </TabsContent>

                  {/* Salesperson Details Tab */}
                  {selectedSalesperson && (
                    <TabsContent value="details" className="space-y-4">
                      <Card>
                        <CardHeader>
                          <div className="flex justify-between items-center">
                            <div>
                              <CardTitle>
                                {selectedSalesperson.firstName}{" "}
                                {selectedSalesperson.lastName}
                              </CardTitle>
                              <CardDescription>
                                Detailed sales performance for Q{report.quarter}{" "}
                                {report.year}
                              </CardDescription>
                            </div>
                            <Button
                              variant="ghost"
                              size="sm"
                              onClick={() => setSelectedSalesperson(null)}
                            >
                              Back to Summary
                            </Button>
                          </div>
                        </CardHeader>
                        <CardContent className="space-y-6">
                          {/* Salesperson Profile */}
                          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
                            <div>
                              <h4 className="text-sm font-semibold mb-1">
                                Manager
                              </h4>
                              <p>{selectedSalesperson.manager || "N/A"}</p>
                            </div>
                            <div>
                              <h4 className="text-sm font-semibold mb-1">
                                Start Date
                              </h4>
                              <p>{formatDate(selectedSalesperson.startDate)}</p>
                            </div>
                            <div>
                              <h4 className="text-sm font-semibold mb-1">
                                First Sale
                              </h4>
                              <p>
                                {formatDate(selectedSalesperson.firstSaleDate)}
                              </p>
                            </div>
                            <div>
                              <h4 className="text-sm font-semibold mb-1">
                                Last Sale
                              </h4>
                              <p>
                                {formatDate(selectedSalesperson.lastSaleDate)}
                              </p>
                            </div>
                          </div>

                          {/* Performance Stats */}
                          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
                            <div className="bg-muted p-3 rounded-md">
                              <h4 className="text-sm font-semibold mb-1">
                                Total Sales
                              </h4>
                              <p className="text-xl font-bold">
                                {selectedSalesperson.totalSales}
                              </p>
                            </div>
                            <div className="bg-muted p-3 rounded-md">
                              <h4 className="text-sm font-semibold mb-1">
                                Total Revenue
                              </h4>
                              <p className="text-xl font-bold">
                                {formatCurrency(
                                  selectedSalesperson.totalRevenue
                                )}
                              </p>
                            </div>
                            <div className="bg-muted p-3 rounded-md">
                              <h4 className="text-sm font-semibold mb-1">
                                Total Commission
                              </h4>
                              <p className="text-xl font-bold">
                                {formatCurrency(
                                  selectedSalesperson.totalCommission
                                )}
                              </p>
                            </div>
                            <div className="bg-muted p-3 rounded-md">
                              <h4 className="text-sm font-semibold mb-1">
                                Avg Commission Rate
                              </h4>
                              <p className="text-xl font-bold">
                                {formatPercentage(
                                  selectedSalesperson.averageCommissionRate
                                )}
                              </p>
                            </div>
                          </div>

                          {/* Highest/Lowest Sales */}
                          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                            <div className="border border-border p-3 rounded-md">
                              <h4 className="text-sm font-semibold mb-1">
                                Highest Sale
                              </h4>
                              <p className="text-xl font-bold">
                                {formatCurrency(
                                  selectedSalesperson.highestSale
                                )}
                              </p>
                            </div>
                            <div className="border border-border p-3 rounded-md">
                              <h4 className="text-sm font-semibold mb-1">
                                Lowest Sale
                              </h4>
                              <p className="text-xl font-bold">
                                {formatCurrency(selectedSalesperson.lowestSale)}
                              </p>
                            </div>
                          </div>

                          {/* Detailed Sales Table */}
                          <div>
                            <h3 className="text-lg font-semibold mb-3">
                              Individual Sales
                            </h3>
                            {selectedSalesperson.detailedSales.length > 0 ? (
                              <Table>
                                <TableHeader>
                                  <TableRow>
                                    <TableHead>Date</TableHead>
                                    <TableHead>Product</TableHead>
                                    <TableHead>Customer</TableHead>
                                    <TableHead>Price</TableHead>
                                    <TableHead>Commission</TableHead>
                                    <TableHead>Rate</TableHead>
                                  </TableRow>
                                </TableHeader>
                                <TableBody>
                                  {selectedSalesperson.detailedSales.map(
                                    (sale: DetailedSale) => (
                                      <TableRow
                                        key={`${sale.saleDate}-${sale.productName}`}
                                      >
                                        <TableCell>
                                          {formatDate(sale.saleDate)}
                                        </TableCell>
                                        <TableCell>
                                          {sale.productName}
                                        </TableCell>
                                        <TableCell>
                                          {sale.customerName}
                                        </TableCell>
                                        <TableCell>
                                          {formatCurrency(sale.salePrice)}
                                        </TableCell>
                                        <TableCell>
                                          {formatCurrency(
                                            sale.commissionAmount
                                          )}
                                        </TableCell>
                                        <TableCell>
                                          {formatPercentage(
                                            sale.commissionRate
                                          )}
                                        </TableCell>
                                      </TableRow>
                                    )
                                  )}
                                </TableBody>
                              </Table>
                            ) : (
                              <div className="text-center p-6 bg-muted/30 rounded-md">
                                <p>No sales found for this salesperson.</p>
                              </div>
                            )}
                          </div>
                        </CardContent>
                      </Card>
                    </TabsContent>
                  )}
                </Tabs>
              </>
            ) : (
              <div className="bg-muted/30 p-8 text-center rounded-md">
                <FileSpreadsheet className="w-12 h-12 mx-auto text-gray-400 mb-2" />
                <h3 className="text-lg font-medium">
                  No commission data found
                </h3>
                <p className="text-muted-foreground mt-1">
                  There are no sales recorded for this quarter.
                </p>
              </div>
            )}
          </>
        )}

        {!showReport && (
          <div className="bg-muted/30 p-8 text-center rounded-md">
            <Search className="w-12 h-12 mx-auto text-gray-400 mb-2" />
            <h3 className="text-lg font-medium">
              Generate a report to view data
            </h3>
            <p className="text-muted-foreground mt-1">
              Select a year and quarter, then click 'Generate Report' to view
              commission data.
            </p>
          </div>
        )}
      </div>
    </div>
  );
}
