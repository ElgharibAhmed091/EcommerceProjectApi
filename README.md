# 🛒 E-CommerceProAPI

**E-CommerceProAPI** is a professional, secure, and scalable RESTful API built with **ASP.NET Core 8**, designed to power modern e-commerce applications.  
Whether you’re building a web app with Angular/React or a mobile app with Flutter, this API provides the complete backend functionality you need.

---

## 🚀 Features

- ✅ User Authentication (JWT-based)
- ✅ User Registration & Login
- ✅ Product Management (CRUD)
- ✅ Category Management
- ✅ Add/Remove Items to Cart
- ✅ Order Creation & History
- ✅ Stripe Payment Integration
- ✅ Product Ratings
- ✅ Favorite Products
- ✅ Admin Dashboard Stats
- ✅ Swagger API Documentation

---

## 🧰 Technologies Used

- ASP.NET Core 8
- Entity Framework Core (Code First)
- SQL Server
- AutoMapper
- JWT Authentication
- Stripe.NET
- Swagger / Swashbuckle

---

## 💻 Compatible with Frontend

This API works with any frontend framework:
- 🌐 React, Angular, Vue
- 📱 Flutter, React Native
- 🔗 Any frontend that consumes RESTful APIs

---

## 📂 File Structure

```
EcommerceProAPI/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── CartController.cs
│   ├── CategoriesController.cs
│   ├── DashboardController.cs
│   ├── FavoritesController.cs
│   ├── OrdersController.cs
│   ├── ProductsController.cs
│   ├── RatingController.cs
│   └── StripeController.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── DTOs/
│   └── (All DTO classes for input/output)
│
├── Helpers/
│   └── JwtTokenGenerator.cs
│
├── Mappings/
│   └── AutoMapperProfile.cs
│
├── Migrations/
│   └── (EF Core migrations files)
│
├── Models/
│   ├── ApplicationUser.cs
│   ├── CartItem.cs
│   ├── Category.cs
│   ├── Favorite.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── Product.cs
│   ├── Rating.cs
│   └── StripeService.cs
│
├── Program.cs
├── appsettings.json
├── .gitignore
└── EcommerceProAPI.csproj
```

---

## 📦 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/ElgharibAhmed091/ECommerceProApi.git
   cd ECommerceProApi
   ```

2. **Set up your local environment**
   - Create your local SQL Server database.
   - Update `appsettings.json` with your connection string and Stripe keys.

3. **Run migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Test with Swagger**
   - Visit `https://localhost:{PORT}/swagger`

---

## 🔐 Security

- JWT tokens for secure authentication
- Role-based authorization
- Stripe keys stored securely in configuration
- ![Swagger Endpoints](./assets/Screenshot%202025-06-29%20002317.png)


---

## 🤝 Contributions & Feedback

This project is built entirely by [@ElgharibAhmed091](https://github.com/ElgharibAhmed091) as a self-initiative.  
Feel free to ⭐ the repo or suggest improvements!
