# Refit Authenticated API Client – ASP.NET Core Example

This project demonstrates how to use [Refit](https://github.com/reactiveui/refit), a REST API interface library for .NET, with **token-based authentication** in an ASP.NET Core Web API application.

## 🔧 Features

- ✅ Refit for simplified HTTP client generation
- ✅ Token-based authentication using credentials
- ✅ Custom `HttpMessageHandler` to inject Bearer tokens
- ✅ Centralized token caching and management
- ✅ Clean separation of concerns using DI

---

## 📦 Technologies Used

- ASP.NET Core 8 / 9 (depending on your version)
- Refit (via `Refit.HttpClientFactory`)
- Microsoft.Extensions.Http
- Dependency Injection
- HttpClientFactory
- .NET 8/9

---

## 🔐 Authentication Flow

1. App requests token using username & password
2. The token is cached and attached to all future API calls via a custom `DelegatingHandler`
3. All protected API requests include `Authorization: Bearer {token}`

---

## 🗂 Project Structure

