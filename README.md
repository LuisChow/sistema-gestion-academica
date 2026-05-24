# Sistema de Gestión Académica

Aplicación de escritorio para administrar la operación de una institución educativa: registro de personas (estudiantes y profesores), cursos, materias, secciones, inscripciones y notas. Desarrollada en C# con Windows Forms y respaldada por una base de datos PostgreSQL.

## Capturas de pantalla

### Menú principal

![Menú principal](screenshots/menu.png)

Pantalla de inicio con acceso a los cuatro módulos del sistema: Notas, Reportes, Inscripción y Mantenimiento.

### Inscripciones

![Inscripciones](screenshots/inscripciones.png)

Inscripción de estudiantes a cursos, con la grilla de secciones disponibles y la vista de horario semanal.

### Notas

![Notas](screenshots/notas.png)

Registro de calificaciones por materia y sección, con varias evaluaciones por estudiante.

### Planilla de notas

![Planilla de notas](screenshots/planilla-notas.png)

Resumen académico del estudiante: evaluaciones realizadas, puntos acumulados, porcentaje evaluado y estado.

### Mantenimiento de cursos

![Mantenimiento de cursos](screenshots/mantenimiento-curso.png)

Administración de cursos: materia, sección, profesor, período, horario, aula y cupo.

### Mantenimiento de personas

![Mantenimiento de personas](screenshots/mantenimiento-persona.png)

Gestión de estudiantes y profesores, con búsqueda y filtros.

## Características

- **Gestión de personas** — registro, edición, mantenimiento y filtrado de estudiantes y profesores.
- **Gestión académica** — administración de cursos, materias y secciones.
- **Inscripciones** — asignación de estudiantes a cursos y secciones.
- **Notas y evaluaciones** — registro de calificaciones, planillas de notas y planillas de evaluaciones.
- **Reportes** — generación de reportes sobre la información académica.
- **Respaldo de base de datos** — copia de la base de datos incluida en la carpeta `BDBackup/`.

## Stack tecnológico

- **C# / .NET 8.0** — lenguaje y plataforma.
- **Windows Forms** — interfaz gráfica de escritorio.
- **PostgreSQL** — base de datos relacional, accedida mediante el driver **Npgsql**.
- **Newtonsoft.Json** — lectura de la configuración y de las consultas SQL externas.

## Arquitectura

El proyecto separa la lógica de acceso a datos en una capa de componentes reutilizables dentro de `Components/`:

- **`DBComponent`** — encapsula la conexión a PostgreSQL, el manejo de transacciones y la ejecución de consultas. Puede instanciarse a partir de un archivo de configuración JSON.
- **`JsonLoader`** — carga de forma declarativa bloques de SQL (SELECT, INSERT, UPDATE, DELETE) definidos en archivos JSON externos, separando las consultas del código compilado.
- **`QueryConfig`** — modelo que representa la estructura de una consulta declarada en JSON.

Las consultas y las rutas de configuración viven en la carpeta `sql/` (`dbsettings.json`, `Queries_Joins.json`, `Rutas.json`), lo que permite modificar las sentencias SQL sin recompilar la aplicación.

## Requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- PostgreSQL 14 o superior
- Windows (la aplicación usa Windows Forms)

## Instalación y ejecución

1. Clona el repositorio:

```
git clone https://github.com/LuisChow/sistema-gestion-academica.git
cd sistema-gestion-academica
```

2. Crea una base de datos PostgreSQL para la aplicación.

3. Configura la cadena de conexión en `SistemaAcademia/sql/dbsettings.json`:

```
{
  "connectionString": "Host=localhost;Port=5432;Database=Academia;Username=tu_usuario;Password=tu_password"
}
```

4. Restaura la base de datos desde el respaldo incluido en `BDBackup/`.

5. Abre `SistemaAcademia.sln` en Visual Studio y ejecuta el proyecto (o usa `dotnet run` desde la carpeta `SistemaAcademia/`).

## Estructura del proyecto

```
.
├── SistemaAcademia.sln          # Solución de Visual Studio
├── BDBackup/                    # Respaldo de la base de datos
├── screenshots/                 # Capturas de pantalla de la aplicación
└── SistemaAcademia/
    ├── Program.cs               # Punto de entrada
    ├── Components/              # Capa de acceso a datos
    │   ├── DBComponent.cs       # Conexión, transacciones y consultas
    │   ├── JsonLoader.cs        # Carga de consultas SQL declarativas
    │   └── QueryConfig.cs       # Modelo de configuración de consultas
    ├── Forms/                   # Formularios de Windows Forms
    └── sql/                     # Configuración y consultas en JSON
```

## Autor

**Luis Fernando Chunwa Chow Cheung**
Estudiante de Ingeniería en Computación — Universidad Rafael Urdaneta
GitHub: [@LuisChow](https://github.com/LuisChow)
