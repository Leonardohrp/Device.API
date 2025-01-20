# CRUD API for Devices

This is a project for a RESTful API to manage devices. The project offers CRUD (Create, Read, Update, Delete) operations for devices, including filtering by **Id**, **Brand**, and **State**.

The API is built using **.NET 9** and is fully documented with **Swagger**. The database is configured to run alongside the API via **Docker Compose**.

## Features

The API allows the following operations:

- **Create** a new device
- **List** devices with filters (Id, Brand, State)
- **Update** device information
- **Delete** a device

Additionally, the API exposes **Swagger** for easy visualization and interactive testing of routes.

## Technologies Used

- **.NET 9**
- **ASP.NET Core** for building the API
- **Entity Framework Core** for database management
- **Docker** to run the database in a container
- **Swagger** for API documentation
- **Moq** and **NUnit** for automated testing

## Running the Project

### Prerequisites

Before running the project, make sure you have the following tools installed:

- **Docker**: To run the database using Docker Compose.
- **.NET 9 SDK**: To build and run the project.

### Running the Project with Docker Compose

1. Clone this repository to your local machine:

    ```bash
    git clone <REPOSITORY_URL>
    cd <REPOSITORY_FOLDER>
    ```

2. **Run Docker Compose**:

    The database will run in a Docker container. The **docker-compose.yml** file is configured to launch the database and automatically connect the API to it.

    Run the following command to start Docker Compose:

    ```bash
    docker-compose up -d
    ```

    This will:

    - Start the database in a container.
    - Run the API on **localhost** at port **8081**.


3. **Accessing the Swagger UI**:

    After the API is running, access the Swagger UI to interact with the API using the following URL in your browser:

    ```plaintext
    https://localhost:8081/index.html
    ```

    Swagger will display the API documentation and allow you to perform operations directly from the interface.

### Stopping the Containers

If you want to stop the containers, run:

## Tests
Unit tests for the API have been implemented using NUnit and Moq to simulate the behavior of the repository and ensure that all features are functioning correctly.

To run the tests, execute the following command:

```bash
dotnet test
```


# Next Steps and Future Improvements


### 1. **Add Authentication and Authorization**
   - **Objective**: Secure the API endpoints to allow only authorized users to perform CRUD operations on devices.
   - **Approach**:
     - Implement JWT (JSON Web Tokens) for authentication.
     - Add role-based authorization to restrict access based on user roles (e.g., Admin, User).
     - Create user registration and login endpoints.

### 2. **Improve Error Handling and Logging**
   - **Objective**: Improve the error handling mechanism and implement logging to track system performance and errors.
   - **Approach**:
     - Use a centralized error handler (e.g., middleware) to manage exceptions and return consistent error responses.
     - Implement logging (e.g., Serilog, NLog) to log important events, errors, and requests.
     - Return detailed error messages with appropriate HTTP status codes.
   
### 3. **Add Pagination to Device Listing**
   - **Objective**: Improve the listing of devices when there are a large number of records by adding pagination.
   - **Approach**:
     - Implement pagination on the `GET /devices` endpoint using query parameters like `page` and `pageSize`.
     - Return metadata in the response to inform users about the current page, total pages, and total records.
   
### 4. **Enhance Filtering Capabilities**
   - **Objective**: Improve the filtering functionality to allow more complex queries.
   - **Approach**:
     - Add additional filters (e.g., range filters for `state`, filtering by creation date, etc.).
     - Allow filtering on multiple fields simultaneously.
   
### 5. **Implement Better Data Validation for Device Inputs**
   - **Objective**: Add input validation to ensure that device data is correct and conforms to expected formats.
   - **Approach**:
     - Use data annotations or custom validation logic to validate input data before processing requests.
     - Return clear validation error messages when the input data is invalid.
  

## Future Improvements

### 1. **Add Unit and Integration Tests for Critical Components**
   - **Objective**: Improve test coverage by writing more unit and integration tests to verify that all components behave correctly.
   - **Approach**:
     - Implement unit tests for business logic (e.g., device CRUD operations, filtering).
     - Add integration tests to ensure that the API endpoints are functioning as expected when interacting with the database.

### 2. **Introduce Caching for Device Data**
   - **Objective**: Enhance performance by caching device data, especially for frequently accessed data.
   - **Approach**:
     - Use a caching solution (e.g., Redis, in-memory cache) to store device data temporarily.
     - Cache responses for frequent queries and implement cache invalidation strategies.
