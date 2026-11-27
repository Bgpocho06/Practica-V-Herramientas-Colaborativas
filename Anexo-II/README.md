# Control de Horas y Tareas — Práctica V (Herramientas Colaborativas)

Este directorio contiene la hoja de cálculo **`Práctica_V_Código_de_Barra.xlsx`**, utilizada para la planificación ágil (Scrum), el seguimiento diario de sesiones de trabajo y la auditoría de contribución equitativa del equipo durante la **Práctica V**.

---

## 👥 Equipo de Desarrollo

| Rol | Integrante | Responsabilidades principales |
| :--- | :--- | :--- |
| **Jefe de proyecto** | Edgar Barreto González | Organización GitHub, Wiki, tablero ágil, estructura base C# (`Anexo I`), revisión de PRs y cierre de sprint |
| **Desarrollador 1** | Pedro Antonio Vargas Pallini | Consultas SQL sobre dataset Steam (`Anexo II`), subconsultas, documentación PDF y control horario |
| **Desarrollador 2** | Kevin Manuel Rodríguez Suárez | Desarrollo de web responsive (`≥3 páginas + CSS`) y apoyo en consultas SQL (`Anexo II`) |
| **Desarrollador 3** | Pablo Tejera González | Módulos *Número*, *String* y *Decimales* en C# (`Anexo I`) y apoyo en consultas SQL (`Anexo II`) |
| **Desarrollador 4** | Enrico Bozzi Bustamante | Estilos CSS responsive, validación final de ramas/PRs y apoyo en consultas SQL (`Anexo II`) |

---

## 📑 Estructura del Libro Excel

El archivo **`Práctica_V_Código_de_Barra.xlsx`** está organizado en tres pestañas conectadas dinámicamente:

1. **`Equipo`**
   * Define los **5 integrantes** y sus roles dentro del proyecto.
   * Contiene los catálogos maestros que alimentan las listas desplegables de validación de datos:
     * **Proyectos:** `C# – Solución con menús (Anexo I)`, `Web responsive (≥3 páginas + CSS)` y `Consultas SQL Steam (Anexo II)`.
     * **Tamaño / Prioridad de Issue:** `low`, `medium`, `high` (las tareas `high` se subdividen al pasar al sprint).
     * **Estado (columnas del tablero GitHub):** `BACKLOG`, `TO DO`, `DOING`, `DONE`.
   * Incluye las reglas de uso y un ejemplo de registro.

2. **`Registro`**
   * Histórico cronológico de todas las sesiones de trabajo realizadas durante el **Sprint 1** (`24/11/2026` – `26/11/2026`).
   * Cada fila vincula el **Sprint**, **Fecha**, **Miembro**, **Proyecto**, **Issue / Tarea** (`#1` a `#12`), **Tamaño**, **Estado**, **Horas** invertidas, **Rama** de Git asociada y **PR / Notas** (incluyendo sesiones desarrolladas de forma colaborativa entre varios miembros).

3. **`Resumen`**
   * Cuadro de mando automatizado mediante fórmulas dinámicas (`SUMIFS`, `COUNTIFS`, `SUM`, `IFERROR`) que lee directamente de `Equipo` y `Registro`:
     * **1) Por miembro:** Horas totales, tareas registradas, tareas en `DONE`, porcentaje de finalización, horas desglosadas por proyecto y peso porcentual sobre el total.
     * **2) Por sprint (semanal):** Tareas registradas, tareas completadas, porcentaje de cumplimiento y carga horaria por sprint (`S1`–`S8`).
     * **3) Horas por miembro y sprint:** Matriz de seguimiento semanal para verificar el equilibrio de carga de trabajo.

---

## 📊 Resumen de Métricas (Sprint 1)

| Miembro | Rol | Horas totales | Tareas (`DONE`) | % Finalizadas | Horas C# | Horas Web | Horas SQL | % del total |
| :--- | :--- | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| **Edgar Barreto González** | Jefe de proyecto | 9,6 | 3 / 3 | 100,0% | 9,6 | 0,0 | 0,0 | 18,8% |
| **Pedro Antonio Vargas Pallini** | Desarrollador 1 | 9,2 | 3 / 3 | 100,0% | 0,0 | 0,0 | 9,2 | 18,0% |
| **Kevin Manuel Rodríguez Suárez** | Desarrollador 2 | 10,8 | 3 / 3 | 100,0% | 0,0 | 6,6 | 4,2 | 21,1% |
| **Pablo Tejera González** | Desarrollador 3 | 12,6 | 4 / 4 | 100,0% | 8,4 | 0,0 | 4,2 | 24,6% |
| **Enrico Bozzi Bustamante** | Desarrollador 4 | 9,0 | 3 / 3 | 100,0% | 1,2 | 3,6 | 4,2 | 17,6% |
| **TOTAL** | — | **51,2** | **16 / 16** | **100,0%** | **19,2** | **10,2** | **21,8** | **100,0%** |

---

## 🌿 Convenciones y Buenas Prácticas Aplicadas

* **Trazabilidad con GitHub:** Cada fila registrada corresponde a una *Issue* del proyecto y refleja la rama de desarrollo utilizada (`Anexo-I`, `Anexo-II`, `Web` y subramas específicas) junto con el estado de su *Pull Request*.
* **Contribución mínima por repositorio:** Todos los proyectos cuentan con participación de al menos dos desarrolladores y sus cambios se integran mediante *Pull Requests* revisados hacia las ramas de integración y `main`.
* **Integridad de fórmulas:** No se deben combinar celdas dentro de `Registro` ni sobreescribir valores manuales en `Resumen`; cualquier nueva sesión añadida en `Registro` utilizando los desplegables actualiza los totales automáticamente.
