# BeSpoked Bikes Sales Tracking Application

A modern sales tracking application for BeSpoked Bikes, a high-end bicycle shop, to manage sales, commissions, and quarterly bonuses.

## 🚀 Features

- **Sales Management**

  - Record and track bike sales
  - Calculate commissions automatically
  - Generate quarterly bonus reports
  - Apply and track product discounts

- **Data Management**

  - Products inventory and pricing
  - Salesperson information
  - Customer records
  - Sales history
  - Discount periods

- **Reporting**
  - Quarterly commission reports
  - Sales performance analytics
  - Filterable sales history
  - Export capabilities

## 🛠️ Tech Stack

- **Frontend**

  - React 18 with Vite
  - shadcn for components
  - TypeScript
  - TanStack Query for data fetching
  - React Router for navigation

- **Backend**

  - .NET Core 8.0
  - Entity Framework Core
  - Microsoft SQL Server
  - RESTful API architecture

## 📋 Prerequisites

- Node.js (v18 or higher)
- .NET Core SDK 8.0
- Microsoft SQL Server (2019 or higher)
- Git

## 🚀 Getting Started

1. **Clone the repository**

   ```bash
   git clone [repository-url]
   cd bespoked-bikes
   ```

2. **Set up the database**

   ```bash
   cd server
   dotnet ef database update
   ```

3. **Start the backend**

   ```bash
   dotnet run
   ```

4. **Start the frontend**

   ```bash
   cd ../client
   npm install
   npm run dev
   ```

5. **Access the application**
   - Frontend: http://localhost:3000
   - API: http://localhost:5000

## 📊 Data Models

### Product

- Name (unique)
- Manufacturer
- Style
- Purchase Price
- Sale Price
- Quantity On Hand
- Commission Percentage

### Salesperson

- First Name
- Last Name
- Address
- Phone
- Start Date
- Termination Date
- Manager

### Customer

- First Name
- Last Name
- Address
- Phone
- Start Date

### Sale

- Product
- Salesperson
- Customer
- Sales Date

### Discount

- Product
- Begin Date
- End Date
- Discount Percentage

## 👥 User Roles

- **Administrators**: Full system access
- **Managers**: Sales and commission management
- **Salespersons**: Sales recording and personal performance tracking

## 🔒 Security

- Role-based access control
- Secure authentication
- Data encryption
- Input validation

## 🧪 Testing

```bash
# Run backend tests
cd server
dotnet test

# Run frontend tests
cd client
npm test
```

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.
