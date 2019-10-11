# Azure AD B2C with an external claims provider

This is an extended version of the Azure AD B2C ["Obtain additional claims" sample](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-rest-api-step-custom). 
It reads additional user information from a database (in this case Azure SQL or SQL Server, but it could be any database) and returns them as claims thorugh a REST API provided by an Azure Function. 
This sample can be easily extended to model other types of claims you want to read from an external store, e.g. for authorization.

- `policies`: Contains the requird Identity Experience Framework policies for Azure AD B2C. Note that these policies include Facebook as claims provider, but the sample inly requires local accounts.
- `src`: Contains the source code for the Azure Function and a simple Entity Framework Core data access layer. Requires local development tools as listed [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-local).
- `tools`: Contains a SQL script to create the necessary database table and a template file for [`local.setting.json`](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local#local-settings-file).
    
