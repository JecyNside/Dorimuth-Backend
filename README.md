# 🎬 Dorimuth Backend
 
API REST para un sistema de gestión de cine — consulta de películas, funciones y salas en tiempo real.
 
---
 
## 🛠️ Stack
 
- **Framework:** ASP.NET Core 8.0
- **ORM:** Entity Framework Core
- **Base de datos:** SQL Server
- **Patrón:** Arquitectura en capas (Controllers → Services → Repository → Data)
---
 
## ✨ ¿Qué hace?
 
- Listar y consultar el catálogo de películas
- Filtrar películas por título, género, sala u horario
- Ver todas las funciones disponibles y sus detalles
- Consultar qué funciones hay para una película específica
---
 
## 📡 Endpoints
 
### Películas
 
| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/movies` | Todas las películas |
| `GET` | `/api/movies/{id}` | Una película por ID |
| `GET` | `/api/movies/filter` | Filtrar por título, género, sala u hora |
 
### Funciones (Showtimes)
 
| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/showtimes` | Todas las funciones |
| `GET` | `/api/showtimes/{id}` | Una función por ID |
| `GET` | `/api/showtimes/by-movie/{id}` | Funciones de una película |
 
---
 
## 🗂️ Modelo de datos
 
| Entidad | Descripción |
|---------|-------------|
| `Movie` | Película (título, sinopsis, género, duración, imagen) |
| `Showtime` | Función (horario, boletos disponibles, sala asignada) |
| `Room` | Sala de cine (nombre y capacidad) |
| `Customer` | Cliente (datos personales y de contacto) |
| `Reservation` | Reserva (número de ticket vinculado a cliente y función) |
 
---
 
## 🚀 Cómo correrlo
 
```bash
# Clona el repositorio
git clone https://github.com/tu-usuario/dorimuth-backend.git
cd dorimuth-backend
 
# Configura tu cadena de conexión en appsettings.json
# "ConnectionStrings": { "DefaultConnection": "Server=...;Database=CinemaDb;..." }
 
# Aplica las migraciones
dotnet ef database update
 
# Ejecuta el proyecto
dotnet run
```
 
La API estará disponible en `https://localhost:5001` (o el puerto configurado).
 
---
 
## 📁 Estructura del proyecto
 
```
DorimuthBackend/
├── Controllers/      # Endpoints REST
├── Services/         # Lógica de negocio
├── Repository/       # Acceso a datos (patrón repositorio)
├── Data/             # DbContext y configuración EF Core
└── DTOs/             # Objetos de transferencia de datos
```
 
---
 
> Proyecto backend desarrollado con .NET 8 como parte del sistema de gestión **Dorimuth Cinema**.
