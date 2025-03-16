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

## 📦 CI/CD Pipeline Setup

### Prerequisites

1. Azure DevOps organization with appropriate permissions
2. Azure subscription
3. Following Azure resources:
   - App Service Plan for API
   - App Service for API
   - Azure Static Web App for client
   - Azure SQL Database

### Setting Up Pipeline Variables

In your Azure DevOps project:

1. Go to Pipelines > Library > Variable groups
2. Create a new variable group named "bespoked-bikes-variables"
3. Add the following variables:
   - `deployment_token`: Your Azure Static Web App deployment token
   - `api_app_name`: The name of your Azure App Service (e.g., "bespoke-bikes-server")
   - `API_URL`: The full URL to your API (e.g., "https://bespoke-bikes-server.azurewebsites.net/api")
   - `DB_CONNECTION_STRING`: Your Azure SQL Database connection string
   - `JWT_SECRET`: Secret key for JWT authentication
4. Mark sensitive variables like `DB_CONNECTION_STRING` and `JWT_SECRET` as secret (using the lock icon)
5. Save the variable group

### Setting Up Environment Variables

#### Security Best Practices

> ⚠️ **IMPORTANT**: Never commit actual secrets or sensitive configuration to version control.

Follow these practices for secure environment variable management:

- Use `.env.example` files to document required variables without real values
- Keep all `.env.*` files (except examples) in `.gitignore`
- Store sensitive variables in Azure DevOps variable groups or Azure Key Vault
- Mark sensitive variables as "secret" in Azure DevOps
- Use environment-specific settings in Azure for production values

#### For the Web App (React/Vite)

The web application uses Vite environment variables with the `VITE_` prefix:

- `VITE_API_URL`: The URL to the API server

These are set in:

- Local `.env.development` file (not committed to git) for local development
- Azure DevOps pipeline variables for CI/CD builds

#### For the API Server (.NET Core)

The API server reads environment variables directly:

- `DB_CONNECTION_STRING`: Database connection string
- `JWT_SECRET`: Secret for JWT authentication
- `CORS_ORIGINS`: Comma-separated list of allowed origins
- `PORT`: Server port
- `LOG_LEVEL`: Logging level

These are set in:

- `appsettings.json` for non-sensitive defaults
- Local `appsettings.Development.json` (not committed to git) for local development
- Azure DevOps pipeline variables for CI/CD
- Azure App Service application settings for production

### Running the Pipeline

The Azure pipeline will:

1. Build and deploy the API server to Azure App Service
2. Set environment variables for the API server in Azure App Service
3. Build the client with environment variables injected at build time
4. Deploy the client to Azure Static Web App

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
