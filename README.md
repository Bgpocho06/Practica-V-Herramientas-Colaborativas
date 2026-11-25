# Web de Seguimiento y Equipo — Práctica V (CódigoDeBarras)

Portal web desarrollado como parte de la **Práctica V: Herramientas colaborativas**. El objetivo de la página es centralizar la documentación de nuestro equipo de trabajo, mostrar el reparto de tareas entre los 5 integrantes y ofrecer un espacio de revisión para los Product Owners[cite: 1, 14, 15, 16].

---

## Contenido de la Web

El sitio consta de **3 páginas HTML** enlazadas entre sí y una única hoja de estilos (`css/styles.css`)[cite: 13]:

* **`index.html` (Proyecto):** Presentación general de la práctica, resumen de los tres entregables técnicos (Aplicación de consola en C#, Web Responsive y Consultas SQL sobre Steam) y métricas clave del sprint[cite: 16].
* **`equipo.html` (Equipo y Tareas):** Desglose individual de los 5 miembros del grupo (1 Jefe de Proyecto y 4 Desarrolladores), indicando su rol, las tareas realizadas, la rama de trabajo asociada y una tabla resumen con el estado actual de cada módulo[cite: 15].
* **`contacto.html` (Revisión PO):** Ficha de referencia de la organización y formulario destinado a los Product Owners (el profesor y el jefe de proyecto del otro grupo) para registrar nuevas peticiones o cambios en el *Backlog* clasificados por prioridad (`low`, `medium`, `high`)[cite: 14].

---

## Características Técnicas

* **HTML5 semántico:** Uso de etiquetas estructurales (`<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<footer>`) y validación nativa en los campos del formulario[cite: 14, 16].
* **CSS3 Responsive:** Diseño adaptable a ordenador, tablet y móvil mediante **CSS Grid**, **Flexbox** y *Media Queries* (`860px` y `640px`), incluyendo menú desplegable en móvil implementado únicamente con HTML y CSS[cite: 17].
* **Estética:** Tema oscuro minimalista con hoja de estilos centralizada mediante variables CSS (`:root`)[cite: 17].

---

## Integrantes

| **Edgar Barreto González** | 
| **Pedro Antonio Vargas Pallini** | 
| **Kevin Manuel Rodríguez Suárez** | 
| **Pablo Tejera González** | 
| **Enrico Bozzi Bustamante** | 

---

## Flujo de Trabajo en GitHub

* **Product Owners:** Profesor de la asignatura y Jefe de Proyecto del grupo asignado[cite: 1, 14].
* **Control de versiones:** Desarrollo aislado en ramas por funcionalidad (`feature/*`) sin modificaciones directas sobre `master`, integrando cada avance mediante **Pull Requests** revisadas por el Jefe de Proyecto[cite: 1, 14].
