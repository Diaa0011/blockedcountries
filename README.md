# Blocked Countries API

## Overview
.NET Core API to manage blocked countries and validate IP
addresses using third-party geolocation APIs ( IPGeolocation.io). The
application doens't use a database and instead rely on in-memory data storage

## Features
- Adding a Blocked Country: 
([POST] http://"yourport"/api/countries/block) for adding countries to the permanent blocked list.
- Deleting a Blocked Country: 
([DELETE] /api/countries/block/{countryCode}) for removing countries from the blocked list.
- Getting All Blocked Countries:
([GET] /api/countries/blocked) with pagination and filtering by country code or name.
- IP Lookup to get Country:
([GET] /api/ip/lookup?ipAddress={ip}) to find the country information associated with an IP address using a third-party API.
- Checking if an IP is Blocked:
([GET] /api/ip/check-block) to check if the caller's country (based on IP) is in the blocked list.
- Logging Blocked Attempts:
([GET] /api/logs/blocked-attempts) for viewing logs of blocked attempts with pagination.
- Temporarily Blocking a Country:
([POST] /api/countries/temporal-block) to block a country temporarily for a specified duration.
## Setup Instructions

### 1. Clone the Repository
- Clone the repository to your local machine using:
```
git clone https://github.com/Diaa0011/blockedcountries
```
### 2. Restore Dependencies
```
dotnet restore  
```
### 3. Configure Environment Variables
- Set up the appsettings.json file with API keys for the IP geolocation service.
- Example appsettings.json:
```
{
  "IpGeolocationApiKey": "your-api-key-here"
}
```
### 4. Run the Project
```
dotnet run  
```
### 5. Access API Documentation
- Open http://localhost:5094/swagger in your browser to explore the API endpoints. 
### 6. Testing API Endpoints
- Use Postman or Insomnia to test various endpoints like previous examples in endpoints section

## Project Structure
```
BLOCKEDCOUNTRIES/  
├── bin/  
├── Controllers/  
│   ├── CountryController.cs  
│   ├── IpController.cs  
│   └── LogsController.cs  
├── Dtos/  
│   ├── BlockedLogsData.cs  
│   ├── BlockedLogsPaginationEntry.cs  
│   ├── BlockEntry.cs  
│   ├── Country.cs  
│   ├── IpGeoData.cs  
│   └── PaginationEntry.cs  
├── obj/  
├── Properties/  
├── Service/
|   ├── IService/   
│   |   ├── ICountryService.cs  
│   |   ├── IIpService.cs  
│   |   ├── ILogService.cs  
│   |   └── IUnBlockTempService.cs
|   └── Service/  
│       ├── CountryService.cs  
│       ├── IpService.cs  
│       ├── LogService.cs  
│       └── UnBlockTempService.cs  
├── Repositoriy/  
│   ├── IRepository.cs
|   |   ├── ICountryRepo.cs
|   |   ├── IIpRepo.cs
|   |   └── ILogRepo.cs
│   └── Repository.cs
|       ├── CountryRepo.cs
|       ├── IpRepo.cs
|       └── ILogRepo.cs
├── appsettings.Development.json  
├── appsettings.json  
├── BlockedCountries.csproj  
├── BlockedCountries.sln  
└── Program.cs
```
## Endpoints
### 1. **Add Country to Permanent Blocked List**
- **Endpoint**: `POST /api/Country/block`
- **Example**
    `http://"yourport"/api/Country/block`
- **Body**:
  ```json
  {
    "code": "NL",
    "name": "Netherlands",
    "temporalBlocked": false,
    "temporalBlockTime": 0
  }
### 2. **Add Country to Temporal Block List**
- **Endpoint**: `POST /api/Country/temporal-block`
- **Example**
    `http://"yourport"/api/Country/temporal-block`
- **Body**:
  ```json
  {
  "code": "NL",
  "name": "Netherlands",
  "temporalBlocked": true,
  "temporalBlockTime": 120
  }
### 3. **Get All Blocked Countries**
- **Endpoint**: `POST /api/Country/blocked`
- **Example**
    `http://"yourport"/api/Country/blocked`
- **Body**:
  ```json
  {
  "pageNumber": 1,
  "pageSize": 50,
  "searchString": null
  }
### 4. **Delete Country from Blocked List**
- **Endpoint**: `DELETE /api/Country/block/{code}`
- **Example**
    `DELETE http://"yourport"/api/Country/block/NL`

### 5. **Get Geolocation of IP Address**
- **Endpoint**: `GET /api/ip/lookup?ip={AnyCountryIP}`
- **Example**
    `GET http://"yourport"/api/ip/102.129.143.255`
  
### 6. **Get Geolocation of User IP Address (using HttpContext)**
- **Endpoint**: `GET /api/ip/lookup`
- **Example**
    `GET http://"yourport"/api/ip/lookup`
### 7. **Check if Your Country is Blocked**
- **Endpoint**: `GET /api/ip/check-block`
- **Example**
    `GET http://"yourport"/api/ip/check-block`
### 8. **Get Logs of Blocked Attempts**
- **Endpoint**: `GET /api/logs/blocked-attempts`
- **Example**
    `GET http://"yourport"/api/logs/blocked-attempts`

