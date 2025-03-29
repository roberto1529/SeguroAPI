# Documentación de la API de Asegurados

## Introducción
Esta API permite la gestión de asegurados, incluyendo la creación, consulta, actualización y eliminación de registros en la base de datos.

## Tecnologías utilizadas
- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server**
- **Swagger** (para documentación interactiva)

---

## Configuración de la base de datos
### Archivo `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=SeguroDB;User Id=sa;Password=Atlantic2025**;TrustServerCertificate=True"
  }
}
```
### Migraciones y base de datos
Ejecutar los siguientes comandos para aplicar las migraciones:
```sh
cd ./db
docker-compose up -d

```

### Montaje y ejecucion de contenedor de base de datos 
Ejecutar los siguientes comandos para aplicar las migraciones:
```sh
dotnet ef migrations add InitialCreate --context SeguroDbContext
dotnet ef migrations add UpdateNumeroIdentificacion --context SeguroDbContext

dotnet ef database update
dotnet ef database update --context SeguroDbContext


---

## Endpoints de la API

### 1. Obtener asegurados con paginación
**GET** `/api/asegurados?page=1&pageSize=10`

#### Respuesta exitosa:
```json
[
  {
    "numeroIdentificacion": 1,
    "primerNombre": "Juan",
    "segundoNombre": "Carlos",
    "primerApellido": "Pérez",
    "segundoApellido": "Gómez",
    "telefonoContacto": "555-1234",
    "email": "juan@example.com",
    "fechaNacimiento": "1990-05-15T00:00:00",
    "valorEstimadoSeguro": 100000,
    "observaciones": "Cliente VIP"
  }
]
```

---

### 2. Obtener asegurado por ID
**GET** `/api/asegurados/{id}`

#### Respuesta exitosa:
```json
{
  "numeroIdentificacion": 1,
  "primerNombre": "Juan",
  "segundoNombre": "Carlos",
  "primerApellido": "Pérez",
  "segundoApellido": "Gómez",
  "telefonoContacto": "555-1234",
  "email": "juan@example.com",
  "fechaNacimiento": "1990-05-15T00:00:00",
  "valorEstimadoSeguro": 100000,
  "observaciones": "Cliente VIP"
}
```

---

### 3. Crear un asegurado
**POST** `/api/asegurados`
#### Cuerpo de la solicitud:
```json
{
  "numeroIdentificacion": 2,
  "primerNombre": "María",
  "segundoNombre": "Elena",
  "primerApellido": "Rodríguez",
  "segundoApellido": "Lopez",
  "telefonoContacto": "555-5678",
  "email": "maria@example.com",
  "fechaNacimiento": "1985-10-20T00:00:00",
  "valorEstimadoSeguro": 200000,
  "observaciones": "Cliente frecuente"
}
```
#### Respuesta exitosa:
**HTTP 201 Created**

---

### 4. Actualizar un asegurado
**PUT** `/api/asegurados/{id}`
#### Cuerpo de la solicitud:
```json
{
  "numeroIdentificacion": 2,
  "primerNombre": "María",
  "segundoNombre": "Elena",
  "primerApellido": "Rodríguez",
  "segundoApellido": "Lopez",
  "telefonoContacto": "555-9999",
  "email": "maria.nueva@example.com",
  "fechaNacimiento": "1985-10-20T00:00:00",
  "valorEstimadoSeguro": 250000,
  "observaciones": "Cliente premium"
}
```
#### Respuesta exitosa:
**HTTP 204 No Content**

---

### 5. Eliminar un asegurado
**DELETE** `/api/asegurados/{id}`
#### Respuesta exitosa:
**HTTP 204 No Content**

---

## Modelo de datos
```csharp
public class Asegurado
{
    public int NumeroIdentificacion { get; set; }
    public required string PrimerNombre { get; set; }
    public required string SegundoNombre { get; set; }
    public required string PrimerApellido { get; set; }
    public required string SegundoApellido { get; set; }
    public required string TelefonoContacto { get; set; }
    public required string Email { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public decimal ValorEstimadoSeguro { get; set; }
    public required string Observaciones { get; set; }
}
```

---

## Seguridad
- Habilitar HTTPS (`UseHttpsRedirection()` en `Program.cs`).
- Agregar autenticación en el futuro si es necesario.

---

## Despliegue
Para ejecutar la API:
```sh
dotnet run
```
Para generar un archivo ejecutable:
```sh
dotnet publish -c Release -o out
```

---

## Contacto
Para soporte, contactar a **Roberto** a través del correo `soporte@techniza.mx`.

