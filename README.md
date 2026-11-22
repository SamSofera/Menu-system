# Menu-system

FOP Final Project: a console menu system written in C# (.NET Framework 4.7.2) with three user roles.

## How to run

1. Open `Menu-system.sln` in Visual Studio 2017 or newer.
2. Press **F5** (or Ctrl+F5) to build and run.

## Login

Choose a role, then log in with:

- Username: `<Username>_<Role>`
- Password: `<Username>_<Password>`

Example (default admin): username `SamDhaniel_Admin`, password `SamDhaniel_ABCD1234`.

## Roles and features

| Role | Features |
|------|----------|
| **Admin** | Update passwords, inactivate users, add users, display all / active / inactive users, display products, display orders |
| **Warehouse** | Add products (existing products get their quantity increased), display products |
| **User** | Place orders from the product list, display orders |

## Project structure

```
Menu-system/
├── Menu-system.sln
└── FinalProject/
    ├── FinalProject.csproj
    ├── Program.cs          # Login and role selection
    ├── Models/User.cs
    ├── Data/DataStorage.cs # In-memory users, products, orders
    └── Menus/              # AdminMenu, WarehouseMenu, UserMenu
```

Data is stored in memory only, so it resets every time the program closes.
