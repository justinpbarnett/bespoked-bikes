# Azure Deployment Guide for BeSpoked Bikes

This guide provides detailed steps for deploying the BeSpoked Bikes application to Azure using Azure DevOps CI/CD pipelines.

## Prerequisites

- Azure Account
- Azure DevOps organization
- Appropriate permissions to create resources

## Azure Resources Setup

### 1. Create Resource Group

```bash
az group create --name bespoked-bikes-rg --location eastus
```

### 2. Create SQL Server and Database

```bash
# Create SQL Server
az sql server create \
  --name bespoked-bikes-sql \
  --resource-group bespoked-bikes-rg \
  --location eastus \
  --admin-user sqlAdmin \
  --admin-password "YourSecurePassword123!"

# Allow Azure services to access server
az sql server firewall-rule create \
  --name AllowAzureServices \
  --resource-group bespoked-bikes-rg \
  --server bespoked-bikes-sql \
  --start-ip-address 0.0.0.0 \
  --end-ip-address 0.0.0.0

# Create SQL Database
az sql db create \
  --name BeSpoked \
  --resource-group bespoked-bikes-rg \
  --server bespoked-bikes-sql \
  --edition Basic \
  --capacity 5
```

### 3. Create App Service Plan and Web App for API

```bash
# Create App Service Plan
az appservice plan create \
  --name bespoked-api-plan \
  --resource-group bespoked-bikes-rg \
  --location eastus \
  --sku B1

# Create Web App
az webapp create \
  --name bespoke-bikes-server \
  --resource-group bespoked-bikes-rg \
  --plan bespoked-api-plan \
  --runtime "DOTNET|8.0"
```

### 4. Create Static Web App for Frontend

```bash
# Create Static Web App
az staticwebapp create \
  --name bespoked-bikes \
  --resource-group bespoked-bikes-rg \
  --location eastus \
  --sku Free
```

## Setting Up Azure DevOps

### 1. Create a New Project (if you don't have one)

1. Go to Azure DevOps portal
2. Create a new project named "BeSpoked Bikes"

### 2. Import Repository

1. In your Azure DevOps project, go to Repos
2. Import your Git repository from its current location

### 3. Set Up Pipeline Variables

1. Go to Pipelines > Library
2. Create a new variable group named "bespoked-bikes-variables"
3. Add the following variables:

   - `deployment_token`: Your Azure Static Web App deployment token (get this from Azure portal)
   - `api_app_name`: "bespoked-bikes-server"
   - `API_URL`: "https://bespoke-bikes-server.azurewebsites.net/api"
   - `DB_CONNECTION_STRING`: Your Azure SQL connection string
   - `JWT_SECRET`: A secure random string for JWT authentication

   > ⚠️ **IMPORTANT**: Mark sensitive variables like `DB_CONNECTION_STRING` and `JWT_SECRET` as secret by clicking the lock icon. Never store actual secrets in environment files checked into version control.

### 4. Set Up the Pipeline

1. Go to Pipelines > New Pipeline
2. Select Azure Repos Git as the source
3. Select your repository
4. Configure your pipeline by selecting "Existing Azure Pipelines YAML file"
5. Select `/azure-pipelines.yml` from the dropdown
6. Run the pipeline

## Database Migration

After your first deployment, you'll need to run database migrations:

### Option 1: Manual Migration

1. Connect to your Azure Web App using SSH from Azure Portal
2. Navigate to the app directory
3. Run `dotnet ef database update`

### Option 2: Add Migration Task to Pipeline

Add this task to your Azure pipeline YAML:

```yaml
- task: DotNetCoreCLI@2
  displayName: "Apply EF Migrations"
  inputs:
    command: "custom"
    custom: "ef"
    arguments: "database update --project server/server.csproj"
  env:
    DB_CONNECTION_STRING: $(DB_CONNECTION_STRING)
```

## Configuring Environment Variables in Azure Portal

You can also set/verify environment variables in the Azure portal:

### For API (App Service)

1. Go to Azure Portal > App Services > bespoke-bikes-server
2. Navigate to Settings > Configuration
3. Check the following Application settings:
   - `PORT`: 80
   - `ASPNETCORE_ENVIRONMENT`: "Production"
   - `DB_CONNECTION_STRING`: Your connection string
   - `JWT_SECRET`: Your JWT secret
   - `CORS_ORIGINS`: "https://bespoked-bikes.azurestaticapps.net"
   - `LOG_LEVEL`: "Information"

### For Client (Static Web App)

Static Web Apps don't support runtime environment variables for client-side code. All environment variables must be set at build time in the pipeline.

## Troubleshooting

### API Connection Issues

- Check that CORS is properly configured in both API and client
- Verify your API URL is correctly set in the pipeline and app
- Check that the App Service is running correctly

### Database Issues

- Verify the connection string is correct
- Check that the firewall allows connections from the App Service
- Ensure migrations have been applied

### Static Web App Issues

- Check that the build output path matches the app_location in your pipeline
- Verify the deployment token is correct and not expired

## Maintenance

### Updating the Application

1. Push your changes to the repository
2. The pipeline will automatically build and deploy the changes

### Scaling

- To scale the API, change the App Service Plan to a higher tier
- To scale the database, update the SQL Database tier

### Monitoring

- Set up Azure Application Insights for monitoring performance and issues
- Configure alerting for critical application metrics
