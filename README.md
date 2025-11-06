
# School Managment Api

api diseñada para el manejo de una institucion educativa con capacidad de registro para estudiantes profesores cursos y sus respectivas inscripciones.

esta api esta pensada para el manejo de entornos educativos basado en ecosistemas reales de aprendizage, se plantea un encarpetado construido por capas apuntando a una estructura exagonal.

## datos relebantes a tener en cuenta en el desarrollo

esta es una api basada en controladores que utiliza el motor **.NET** en su version del **sdk y runtime 8.0** utilizando librerias para el mapeado y gestion de la base de datos (E.F.) asi como componentes nativos de **.NET**, se implementa seguridad con **JWT** para el sistema de roles en la aplicacion.


## API Reference

### Notas generales
- Base URL: `https://null` o `http://null`
- Todas las rutas, salvo `/api/auth/register` y `/api/auth/login`, requieren el header: Authorization: Bearer <JWT_TOKEN>
- Formato de datos: `application/json`.


## Autenticación

### Registro de usuario

**POST /api/auth/register**

**Descripción:** Registra un nuevo usuario (Admin / Teacher / Student).

**Headers**

| Parameter | Type     | Description |
| :-------- | :------- | :---------- |
| `Content-Type` | `string` | **Required.** `application/json` |

**Body**

| Parameter | Type | Description |
| :-------- | :--- | :---------- |
| `name` | `string` | **Required.** Nombre. |
| `lastName` | `string` | **Required.** Apellido. |
| `docNumber` | `string` | Opcional. Documento de identidad. |
| `email` | `string` | **Required.** Email único. |
| `phone` | `string` | Opcional. Teléfono. |
| `userName` | `string` | **Required.** Nombre de usuario único. |
| `password` | `string` | **Required.** Contraseña (se encripta en BD). |
| `role` | `string` | **Required.** `Admin` \| `Teacher` \| `Student` |

**Response (201 Created)**

```json
{
  "message": "Usuario registrado correctamente.",
  "userId": 1
}
```
---
### Login

**POST /api/auth/login**

**Descripción:** Autentica usuario y retorna JWT.

**Headers**

| Parameter      | Type     | Description                      |
| :------------- | :------- | :------------------------------- |
| `Content-Type` | `string` | **Required.** `application/json` |

**Body**

| Parameter  | Type     | Description                                                   |
| :--------- | :------- | :------------------------------------------------------------ |
| `userName` | `string` | **Required.** Nombre de usuario o email según implementación. |
| `password` | `string` | **Required.** Contraseña.                                     |

**Response (200 OK)**

```json
{
  "token": "JWT_TOKEN",
  "expiration": "2025-12-01T00:00:00Z"
}
```

---
### Usuarios

**Nota:** Listar y eliminar usuarios deben estar restringidos al rol `Admin`.

**Obtener todos los usuarios**

**GET /api/users**

**Headers**

| Parameter       | Type     | Description                                       |
| :-------------- | :------- | :------------------------------------------------ |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>` (rol `Admin`). |

**Response (200 OK)**

```json
[
  {
    "id": 1,
    "userName": "admin",
    "email": "admin@example.com",
    "role": "Admin",
    "name": "Admin",
    "lastName": "User"
  }
]
```

**Obtener usuario por ID**

**GET /api/users/{id}**

**Headers**

| Parameter       | Type     | Description                         |
| :-------------- | :------- | :---------------------------------- |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>`. |

**Path Parameter**

| Parameter | Type  | Description                             |
| :-------- | :---- | :-------------------------------------- |
| `id`      | `int` | **Required.** ID del usuario a obtener. |

**Response (200 OK)**

```json
{
  "id": 2,
  "userName": "juan123",
  "email": "juan@example.com",
  "role": "Student",
  "name": "Juan",
  "lastName": "Gonzalez",
  "phone": "3001234567"
}
```

**Actualizar Usuario**

**PUT /api/users/{id}**

**Headers**

| Parameter       | Type     | Description                         |
| :-------------- | :------- | :---------------------------------- |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>`. |
| `Content-Type`  | `string` | **Required.** `application/json`.   |

**Path Parameters**

| Parameter | Type  | Description                   |
| :-------- | :---- | :---------------------------- |
| `id`      | `int` | **Required.** ID del usuario. |

**Body**

| Parameter | Type     | Description                         |
| :-------- | :------- | :---------------------------------- |
| `email`   | `string` | Opcional. Nuevo email.              |
| `phone`   | `string` | Opcional. Nuevo teléfono.           |
| `role`    | `string` | Opcional. Cambiar rol (solo Admin). |

**Response (200 OK)**

```json
{
  "message": "Usuario actualizado correctamente."
}
```

**Elimonar Usuario**

**DELETE /api/users/{id}**

**Headers**

| Parameter       | Type     | Description                                       |
| :-------------- | :------- | :------------------------------------------------ |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>` (rol `Admin`). |

**Path Parameter**
| Parameter | Type  | Description                              |
| :-------- | :---- | :--------------------------------------- |
| `id`      | `int` | **Required.** ID del usuario a eliminar. |

**Response (204 No Content)**

---

### Estudiantes

**POST /api/students**

**header**

| Parameter       | Type     | Description                         |
| :-------------- | :------- | :---------------------------------- |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>`. |
| `Content-Type`  | `string` | **Required.** `application/json`.   |

**Body**

| Parameter   | Type            | Description                                    |
| :---------- | :-------------- | :--------------------------------------------- |
| `userId`    | `int`           | Opcional. ID del usuario asociado (si existe). |
| `name`      | `string`        | **Required.** Nombre del estudiante.           |
| `lastName`  | `string`        | **Required.** Apellido.                        |
| `career`    | `string`        | Opcional. Carrera.                             |
| `startDate` | `string (date)` | Opcional. Fecha inicio (ISO).                  |
| `status`    | `boolean`       | Opcional. Estado activo/inactivo.              |

**Response (201 Created)**

```json
{
  "id": 10,
  "message": "Estudiante creado correctamente."
}
```

**Obtener todos los estudiantes**

**GET /api/students**

**Headers**

| Parameter       | Type     | Description                         |
| :-------------- | :------- | :---------------------------------- |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>`. |

**Response (200 OK)**

Array de estudiantes con sus atributos.

**Obtener estudiante por ID**

**GET /api/students/{id}**

**Path Parameters**

| Parameter | Type  | Description                      |
| :-------- | :---- | :------------------------------- |
| `id`      | `int` | **Required.** ID del estudiante. |

**Response (200 OK)**

```json
{
  "id": 3,
  "name": "Carlos",
  "lastName": "Lopez",
  "career": "Ingeniería de Sistemas",
  "startDate": "2023-08-01",
  "status": true
}
```

**Actualizar estudiante**

**PUT /api/students/{id}**

**Body**

| Parameter   | Type            | Description |
| :---------- | :-------------- | :---------- |
| `career`    | `string`        | Opcional.   |
| `startDate` | `string (date)` | Opcional.   |
| `status`    | `boolean`       | Opcional.   |

**Response (200 OK)**

```json
{
  "message": "Estudiante actualizado correctamente."
}
```

**Eliminar estudiante**

**DELETE /api/students/{id}**

**Response (204 No Content)**

---

### Profesores (Teachers)

**Crear profesor**

**POST /api/teachers**

**Body**

| Parameter        | Type     | Description   |
| :--------------- | :------- | :------------ |
| `name`           | `string` | **Required.** |
| `lastName`       | `string` | **Required.** |
| `specialization` | `string` | Opcional.     |

**Response (201 Created)**
```json
{
  "id": 5,
  "message": "Profesor creado correctamente."
}
```

**Obtener todos los profesores**

**GET /api/teachers**

**Obtener profesor por ID**

**GET /api/teachers/{id}**

**Actualizar profesor**

**PUT /api/teachers/{id}**

**Eliminar profesor**

**DELETE /api/teachers/{id}**

---

### Cursos (Courses)

**Crear curso**

**POST /api/courses**

**Body**

| Parameter    | Type            | Description                                |
| :----------- | :-------------- | :----------------------------------------- |
| `courseName` | `string`        | **Required.** Nombre del curso.            |
| `code`       | `string`        | **Required.** Código del curso (único).    |
| `teacherId`  | `int`           | **Required.** ID del profesor responsable. |
| `startDate`  | `string (date)` | Opcional.                                  |
| `endDate`    | `string (date)` | Opcional.                                  |

**Response (201 Created)**

```json
{
  "id": 7,
  "message": "Curso creado correctamente."
}
```

**Obtener todos los cursos**

**GET /api/courses**

**Path Parameters**

| Parameter | Type  | Description                 |
| :-------- | :---- | :-------------------------- |
| `id`      | `int` | **Required.** ID del curso. |

**Actualizar curso**

**UT /api/courses/{id}**

**Eliminar curso**

**DELETE /api/courses/{id}**

### Inscripciones (Enrollments)

**Crear inscripción**

**POST /api/enrollments**

| Parameter        | Type            | Description                           |
| :--------------- | :-------------- | :------------------------------------ |
| `studentId`      | `int`           | **Required.** ID del estudiante.      |
| `courseId`       | `int`           | **Required.** ID del curso.           |
| `grade`          | `number`        | Opcional. Nota o calificación.        |
| `enrollmentDate` | `string (date)` | Opcional. Fecha de inscripción (ISO). |

**Response (201 Created)**
```json
{
  "id": 12,
  "message": "Inscripción creada correctamente."
}
```

**Obtener todas las inscripciones**

**GET /api/enrollments**

**Obtener inscripción por ID**

**GET /api/enrollments/{id}**

**Path Parameters**

| Parameter | Type  | Description                         |
| :-------- | :---- | :---------------------------------- |
| `id`      | `int` | **Required.** ID de la inscripción. |

**Actualizar inscripción**

**PUT /api/enrollments/{id}**

**Eliminar inscripción**

**DELETE /api/enrollments/{id}**

### Tablas de parámetros comunes (resumen)

**Header Authorization**

| Parameter       | Type     | Description                        |
| :-------------- | :------- | :--------------------------------- |
| `Authorization` | `string` | **Required.** `Bearer <JWT_TOKEN>` |

**Path parameter `id`**

| Parameter | Type  | Description                                                                              |
| :-------- | :---- | :--------------------------------------------------------------------------------------- |
| `id`      | `int` | **Required.** Identificador del recurso (usuario, student, teacher, course, enrollment). |

**Ejemplo de errores comunes**

401 Unauthorized
```json
{
  "error": "Unauthorized",
  "message": "Token inválido o expirado."
}
```

403 Forbidden
```json
{
  "error": "Forbidden",
  "message": "No tiene permisos para acceder a este recurso."
}
```

404 Not Found
```json
{
  "error": "NotFound",
  "message": "Recurso no encontrado."
}
```

400 Bad Request
```json
{
  "error": "BadRequest",
  "message": "Validación fallida. Campos requeridos faltan o son inválidos."
}
```
---