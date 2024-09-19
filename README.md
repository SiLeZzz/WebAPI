INFORMATION ABOUT CI/CD AND AZURE CONFIGURATION

1. CI/CD configuration

	Workflow is configured to run on merge or push to the master branch.
	
	The pipeline is responsible for: </br>
		  -setup .NET version to 8.0.x </br>
		  -restore nuget packages </br>
		  -build the project in Release configuration </br>
		  -publish to ./publish path </br>
		  -deploy the changes to Azure App Service </br>

2. Azure configuration
   
   To make the API work properly on Azure we need:</br>
     -Web App Service with .NET 8</br>
     -Azure Database for PostgreSQL</br>

   Configuration:</br>
     -put publishing profile in Action Secrets (secret name: AZURE_PUBLISH_PROFILE),</br>
     -configure Firewall in Azure Database to allow traffic from the API,</br>
     -add connection string to environmet variables in Web App Service,</br>
     -connect API with database using environment variable (in Program.cs file),</br>
     -create database</br>

I hope this is all about CI/CD pipeline and Azure configuration.</br>
Aplication is avaliable on: https://contract-settlement-interview.azurewebsites.net/swagger/index.html
     
