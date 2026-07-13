# 📚 Sistema Escolar

Sistema de gestión escolar desarrollado en **C#**, **Windows Forms** y **SQL Server** como proyecto universitario.

El sistema permite administrar materias, profesores, alumnos, calificaciones y estadísticas mediante distintos tipos de usuarios desde una única aplicación.

---

# 🛠 Tecnologías utilizadas

- C#
- .NET Framework
- Windows Forms
- SQL Server
- ADO.NET
- Programación Orientada a Objetos (POO)
- Exportación de datos a Excel

---

# 🧠 Conceptos aplicados

Durante el desarrollo del proyecto se implementaron los siguientes conceptos:

- Programación Orientada a Objetos (POO)
- Herencia
- Interfaces
- Enumeraciones (Enum)
- Manejo de excepciones
- Pruebas unitarias (MSTest)

---

# 🚀 Funcionalidades principales

- 🔐 Inicio de sesión con distintos tipos de usuarios.
- 📚 Administración de materias.
- 👨‍🏫 Gestión de profesores.
- 🎓 Gestión de alumnos.
- 📝 Registro de exámenes y calificaciones.
- 📊 Estadísticas por materia.
- 📄 Exportación de materias a Excel.
- 💾 Persistencia de datos mediante SQL Server.

---

# 📸 Capturas

## Login

Permite iniciar sesión como **Administrador**, **Profesor** o **Alumno**.

Los botones laterales autocompletan usuarios de prueba para facilitar la demostración del sistema.

![Login](imagenes/login.png)

---

## Panel de Administrador

Desde esta ventana el administrador puede visualizar todas las materias registradas junto con:

- Estado
- Nombre
- Cuatrimestre
- Profesor asignado
- Alumno
- Primer parcial
- Segundo parcial
- Promedio
- Correlatividad
- Asistencia

Además puede administrar las materias, crear usuarios, exportar información y consultar estadísticas.

![Administrador](imagenes/administrador.png)

---

## Nueva Materia

Permite registrar nuevas materias indicando:

- Nombre
- Cuatrimestre
- Profesor asignado

Si la materia pertenece al segundo o tercer cuatrimestre también es posible seleccionar:

- Correlatividad
- Materia correlativa

Una vez completados los datos, la materia queda registrada en la base de datos.

![Nueva Materia](imagenes/nueva-materia.png)

---

## Nuevo Usuario

Permite crear nuevos usuarios para el sistema.

Los tipos disponibles son:

- Administrador
- Profesor
- Alumno

Cada usuario queda almacenado en la base de datos para poder iniciar sesión posteriormente.

![Nuevo Usuario](imagenes/nuevo-usuario.png)

---

## Estadísticas

El sistema permite visualizar estadísticas por materia, mostrando información como:

- Promedio de alumnos inscriptos.
- Promedio de notas de la materia.

![Estadísticas](imagenes/estadisticas.png)

---

## Panel del Profesor

Cada profesor visualiza únicamente las materias que tiene asignadas.

Desde esta ventana puede:

- Crear un nuevo examen.
- Definir la fecha del examen.
- Asignar un nombre al examen.
- Visualizar los alumnos inscriptos.
- Registrar la nota del primer parcial.
- Registrar la nota del segundo parcial.
- Actualizar automáticamente el promedio del alumno.

La lista superior muestra los exámenes creados durante la sesión con su fecha y nombre.

![Profesor](imagenes/profesor.png)

---

## Panel del Alumno

El alumno dispone de dos tablas principales.

### Materias cursadas

Permite visualizar:

- Estado
- Nombre
- Cuatrimestre
- Profesor
- Primer parcial
- Segundo parcial
- Promedio
- Correlatividad
- Asistencia

### Inscripción a materias

El alumno puede seleccionar una materia disponible para inscribirse.

Al hacerlo, el sistema muestra:

- Materia
- Profesor
- Cuatrimestre
- Asistencia

Finalmente puede completar la inscripción desde la misma ventana.

![Alumno](imagenes/alumno.png)

---

# 🗄 Base de datos

Toda la información del sistema se almacena en **SQL Server**.

Entre los datos persistidos se encuentran:

- Usuarios
- Profesores
- Alumnos
- Materias
- Inscripciones
- Calificaciones

El repositorio incluye un script SQL para crear la base de datos con las tablas y los datos necesarios para probar la aplicación.

---

# ⚙ Instalación

1. Clonar el repositorio.

```bash
git clone https://github.com/IHaruI/Sistema-Escolar.git
```

2. Abrir la solución en **Visual Studio**.

3. Abrir **SQL Server Management Studio**.

4. Ejecutar el archivo:

```
2do_Parcial_Scripts.sql
```

5. Si es necesario, modificar la cadena de conexión a SQL Server.

6. Ejecutar el proyecto.

---

# 📂 Estructura del proyecto

```
Sistema-Escolar
│
├── Biblioteca
├── Parcial_y_TP
├── Test
├── imagenes
├── 2do_Parcial_Scripts.sql
├── Patricio_Galimany_2°E.sln
└── README.md
```

---

# 🎯 Objetivos del proyecto

Este proyecto fue desarrollado para poner en práctica conocimientos sobre:

- Programación Orientada a Objetos.
- Arquitectura en capas.
- Manejo de bases de datos SQL Server.
- Windows Forms.
- ADO.NET.
- Gestión de usuarios mediante roles.
- Desarrollo de interfaces de escritorio.

---

# 📄 Licencia

Proyecto desarrollado con fines educativos y de aprendizaje.
