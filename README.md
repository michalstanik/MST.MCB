# MST.MCB

## How to run it on local environment:
Setup of multiple startup projects:

**1. MCB.APi =>**
  - App URL: https://localhost:9001 | Launch browser: https://localhost:9001/api
  - AppConfiguration__DeleteData: false
  - ASPNETCORE_ENVIRONMENT: Development
  - AppConfiguration__RemoveLogsOlderThanHours: 12
  - AppConfiguration__RecreateDB: false
  
**2. MST.IDP.Admin =>**
  - App URL: https://localhost:9000 
  
**3. MST.IDP.Admin.Api =>**
  - App URL: https://localhost:5002
  
**4. MST.IDP.STS.Identity =>**
  - App URL: https://localhost:5001 
  
**5. Angular =>**
  - App URL: https://localhost:4200 
