#!/usr/bin/env pwsh
# Azure deployment script for BeSpoked Bikes

# Configuration
$resourceGroup = "bespoked-bikes-rg"
$apiAppName = "bespoked-bikes-api"
$webAppName = "bespoked-bikes-client"
$location = "East US"  # Change to your preferred region

# Build the .NET API
Write-Host "Building .NET API for production..." -ForegroundColor Green
Set-Location ./server
dotnet publish -c Release

# Build the React client
Write-Host "Building React client for production..." -ForegroundColor Green
Set-Location ../client
npm ci
npm run build

# Deploy API to Azure
Write-Host "Deploying API to Azure App Service..." -ForegroundColor Green
Set-Location ../server/bin/Release/net8.0/publish
Compress-Archive -Path * -DestinationPath api.zip -Force

# Deploy using Azure CLI (requires Azure CLI to be installed)
# az webapp deployment source config-zip --resource-group $resourceGroup --name $apiAppName --src api.zip

Write-Host "API deployment package prepared at server/bin/Release/net8.0/publish/api.zip" -ForegroundColor Yellow
Write-Host "Client build completed at client/dist/" -ForegroundColor Yellow
Write-Host ""
Write-Host "Follow these steps to complete deployment:" -ForegroundColor Cyan
Write-Host "1. Log in to Azure Portal (https://portal.azure.com)" -ForegroundColor Cyan
Write-Host "2. Create resource group '$resourceGroup' if it doesn't exist" -ForegroundColor Cyan
Write-Host "3. Create App Service plans for API and client" -ForegroundColor Cyan
Write-Host "4. Create Web App '$apiAppName' for API" -ForegroundColor Cyan
Write-Host "5. Deploy API using the zip package at 'server/bin/Release/net8.0/publish/api.zip'" -ForegroundColor Cyan
Write-Host "6. Create Web App '$webAppName' for client" -ForegroundColor Cyan
Write-Host "7. Deploy client from 'client/dist/' folder" -ForegroundColor Cyan
Write-Host "8. Configure environment variables and connection strings in Azure App Service settings" -ForegroundColor Cyan

# Return to root directory
Set-Location ../../..