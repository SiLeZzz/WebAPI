INFORMATION ABOUT CI/CD AND AZURE CONFIGURATION

1. CI/CD configuration

Workflow is configured to run on merge or push to the master branch.

The pipeline is responsible for:
  setup .NET version to 8.0.x
  restore nuget packages
  build the project in Release configuration
  publish to ./publish path
  deploy the changes to Azure App Service

2. Azure configuration
   
   To make the API work properly on Azure we need:
     Web App Service with .NET 8
     Azure Database for PostgreSQL

   Configuration:
     put publishing profile in Action Secrets (secret name: AZURE_PUBLISH_PROFILE),
     configure Firewall in Azure Database to allow traffic from the API,
     add connection string to environmet variables in Web App Service,
     connect API with database using environment variable (in Program.cs file),
     create database

I hope this is all about CI/CD pipeline and Azure configuration.
Aplication is avaliable on: https://contract-settlement-interview.azurewebsites.net/swagger/index.html
     
