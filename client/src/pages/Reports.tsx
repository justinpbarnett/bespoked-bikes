import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getCommissionReport } from "../services/api";
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
import { Download, FileSpreadsheet, Search } from "lucide-react";

export default function Reports() {
  const currentYear = new Date().getFullYear();
  const currentQuarter = Math.floor(new Date().getMonth() / 3) + 1;

  const [filter, setFilter] = useState({
    year: currentYear,
    quarter: currentQuarter,
  });

  const {
    data: report,
    isLoading,
    error,
    refetch,
  } = useQuery({
    queryKey: ["commissionReport", filter.year, filter.quarter],
    queryFn: () => getCommissionReport(filter.year, filter.quarter),
  });

  const handleYearChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setFilter((prev) => ({ ...prev, year: parseInt(e.target.value, 10) }));
  };

  const handleQuarterChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setFilter((prev) => ({ ...prev, quarter: parseInt(e.target.value, 10) }));
  };

  const formatDate = (dateString: string) => {
    return format(new Date(dateString), "MMM d, yyyy");
  };

  const exportToCSV = () => {
    if (!report) return;

    const headerRow = [
      "Salesperson ID",
      "First Name",
      "Last Name",
      "Total Sales",
      "Total Revenue",
      "Total Commission",
    ];

    const dataRows = report.commissions.map((commission) => [
      commission.salespersonId,
      commission.firstName,
      commission.lastName,
      commission.totalSales,
      `$${commission.totalRevenue.toFixed(2)}`,
      `$${commission.totalCommission.toFixed(2)}`,
    ]);

    const title = `Q${report.quarter} ${
      report.year
    } Commission Report (${formatDate(report.startDate)} - ${formatDate(
      report.endDate
    )})`;

    const csvContent = [
      title,
      "",
      headerRow.join(","),
      ...dataRows.map((row) => row.join(",")),
    ].join("\n");

    const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
    const url = URL.createObjectURL(blob);
    const link = document.createElement("a");
    link.setAttribute("href", url);
    link.setAttribute(
      "download",
      `commission_report_q${report.quarter}_${report.year}.csv`
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

      <div className="bg-white p-4 rounded-lg shadow">
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
            <Button onClick={() => refetch()} className="mb-0.5">
              <Search className="w-4 h-4 mr-2" />
              Generate Report
            </Button>
            {report && report.commissions.length > 0 && (
              <Button
                variant="outline"
                onClick={exportToCSV}
                className="mb-0.5"
              >
                <Download className="w-4 h-4 mr-2" />
                Export CSV
              </Button>
            )}
          </div>
        </div>

        {report && (
          <>
            <div className="mb-4">
              <h2 className="text-lg font-medium">
                Q{report.quarter} {report.year} Commission Report
              </h2>
              <p className="text-gray-500">
                {formatDate(report.startDate)} - {formatDate(report.endDate)}
              </p>
            </div>

            {report.commissions.length > 0 ? (
              <Table>
                <TableHeader>
                  <TableRow>
                    <TableHead>Salesperson</TableHead>
                    <TableHead>Total Sales</TableHead>
                    <TableHead>Total Revenue</TableHead>
                    <TableHead>Total Commission</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {report.commissions.map((commission) => (
                    <TableRow key={commission.salespersonId}>
                      <TableCell className="font-medium">
                        {commission.firstName} {commission.lastName}
                      </TableCell>
                      <TableCell>{commission.totalSales}</TableCell>
                      <TableCell>
                        ${commission.totalRevenue.toFixed(2)}
                      </TableCell>
                      <TableCell>
                        ${commission.totalCommission.toFixed(2)}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            ) : (
              <div className="bg-gray-50 p-8 text-center rounded-md">
                <FileSpreadsheet className="w-12 h-12 mx-auto text-gray-400 mb-2" />
                <h3 className="text-lg font-medium text-gray-900">
                  No commission data found
                </h3>
                <p className="text-gray-500 mt-1">
                  There are no sales recorded for this quarter.
                </p>
              </div>
            )}
          </>
        )}
      </div>
    </div>
  );
}
