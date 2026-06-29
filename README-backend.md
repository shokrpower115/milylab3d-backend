# 🔧 MilyLab 3D — Backend
API REST construida con ASP.NET Core 8 + PostgreSQL para el sistema de gestión de MilyLab, empresa de impresión 3D en Culiacán, Sinaloa.

---

## 🛠️ Stack Tecnológico

| Tecnología | Versión | Uso |
|-----------|---------|-----|
| ASP.NET Core | 8.0 | Framework principal |
| Entity Framework Core | 8.0 | ORM |
| PostgreSQL | 16 | Base de datos |
| Npgsql | 8.0 | Driver PostgreSQL |
| JWT Bearer | 8.0 | Autenticación |
| Docker | 29.6+ | Contenedores |
| Nginx | 1.24+ | Reverse proxy |

---

## 📁 Estructura del Proyecto

```
MilyLab.API/
├── Controllers/
│   ├── ProductosController.cs     ← CRUD productos
│   ├── CotizacionesController.cs  ← Sistema de cotizaciones
│   └── AuthController.cs          ← Login y registro
├── Models/
│   ├── Producto.cs
│   ├── Cotizacion.cs
│   ├── Usuario.cs
│   ├── Pedido.cs
│   └── PedidoProducto.cs
├── Data/
│   └── AppDbContext.cs            ← Contexto EF Core
├── Services/
│   ├── ProductoService.cs
│   ├── CotizacionService.cs
│   └── AuthService.cs
├── DTOs/
│   ├── ProductoDTO.cs
│   ├── CotizacionDTO.cs
│   └── AuthDTO.cs
├── Migrations/                    ← Migraciones EF Core
├── Dockerfile
├── docker-compose.yml
└── Program.cs
```

---

## ⚙️ Requisitos Previos

Tener instalado en tu PC:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)

---

## 🚀 Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/shokrpower115/milylab3d-backend.git
cd milylab3d-backend
git checkout develop
```

### 2. Crear archivos de configuración

Los archivos `appsettings.json` y `appsettings.Development.json` están excluidos del repositorio por seguridad. Créalos manualmente:

**`appsettings.json`**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=milylab_db;Username=milylab_user;Password=milylab2024"
  },
  "Jwt": {
    "Key": "MilyLab$2024#SecretKey!Culiacan@Sinaloa",
    "Issuer": "MilyLab.API",
    "Audience": "MilyLab.Frontend",
    "ExpiresInHours": 8
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "FrontendUrl": "http://localhost:5500"
}
```

**`appsettings.Development.json`**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=milylab_db;Username=milylab_user;Password=milylab2024"
  },
  "Jwt": {
    "Key": "MilyLab$2024#SecretKey!Culiacan@Sinaloa",
    "Issuer": "MilyLab.API",
    "Audience": "MilyLab.Frontend",
    "ExpiresInHours": 8
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "FrontendUrl": "http://localhost:5500"
}
```

### 3. Levantar PostgreSQL con Docker

```bash
docker compose up -d postgres
```

### 4. Restaurar dependencias y aplicar migraciones

```bash
dotnet restore
dotnet ef database update
```

### 5. Correr la API

```bash
dotnet run --launch-profile https
```

### 6. Verificar en Swagger

```
https://localhost:7109/swagger
```

---

## 📋 Endpoints Disponibles

### Productos (público GET, admin POST/PUT/DELETE)
```
GET    /api/Productos              → Listar productos
GET    /api/Productos/{id}         → Obtener producto
POST   /api/Productos              → Crear producto (🔒 admin)
PUT    /api/Productos/{id}         → Editar producto (🔒 admin)
DELETE /api/Productos/{id}         → Eliminar producto (🔒 admin)
```

### Cotizaciones
```
GET    /api/Cotizaciones           → Listar cotizaciones (🔒 admin)
POST   /api/Cotizaciones           → Crear cotización (público)
PATCH  /api/Cotizaciones/{id}/estado → Cambiar estado (🔒 admin)
```

### Autenticación
```
POST   /api/Auth/register          → Registrar usuario admin
POST   /api/Auth/login             → Login → retorna JWT token
```

---

## 🗄️ Base de Datos

### Tablas

| Tabla | Descripción |
|-------|-------------|
| Productos | Catálogo de productos 3D |
| Cotizaciones | Solicitudes de clientes |
| Usuarios | Administradores del sistema |
| Pedidos | Pedidos con pago |
| PedidoProductos | Relación pedido-producto |

### Credenciales locales

```
Base de datos: milylab_db
Usuario:       milylab_user
Contraseña:    milylab2024
Puerto:        5432
```

---

## 🐳 Docker

### Levantar todo (API + PostgreSQL)

```bash
docker compose up -d --build
```

### Comandos útiles

```bash
# Ver contenedores
docker ps

# Logs de la API
docker logs -f milylab-api

# Logs de PostgreSQL
docker logs milylab-postgres

# Detener todo
docker compose down

# Reconstruir tras cambios
docker compose up -d --build
```

---

## 🖥️ Deployment en VM

### Requisitos de la VM
```
OS:     Ubuntu Server 24.04 LTS
RAM:    2GB mínimo
Disco:  20GB mínimo
Docker: 29.6+
Nginx:  1.24+
```

### Copiar proyecto a la VM

```bash
scp -r ./MilyLab.API usuario@IP_VM:/home/usuario/
```

### Levantar en producción

```bash
ssh usuario@IP_VM
cd MilyLab.API
docker compose up -d --build
```

### URL de producción

```
http://IP_VM/api/Productos
```

---

## 🌿 Ramas

| Rama | Uso |
|------|-----|
| `main` | Código en producción (estable) |
| `develop` | Código en desarrollo |

---

## 📊 Estado del Proyecto

```
✅ CRUD Productos
✅ Sistema de Cotizaciones
✅ Autenticación JWT
✅ PostgreSQL + EF Core
✅ Docker + docker-compose
✅ Nginx reverse proxy
✅ Migraciones automáticas
🔲 MercadoPago
🔲 Panel de administración
🔲 Notificaciones por email
🔲 Webhooks n8n
```
