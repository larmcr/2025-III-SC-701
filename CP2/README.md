# Caso Práctico 2

| Curso                         | Programación Avanzada en Web            |
| :---------------------------- | :-------------------------------------- |
| Código                        | SC-701                                  |
| Profesor                      | Luis Andrés Rojas Matey                 |
| Fecha y hora de entrega final | Martes 2 de diciembre antes de las 9 pm |
| Valor                         | 15 %                                    |

<br />

- [Indicaciones generales](#indicaciones-generales)
- [Indicaciones específicas](#indicaciones-específicas)
  - [Entity Framework](#entity-framework)
  - [Dependency Injection](#dependency-injection)
  - [Unit Tests](#unit-tests)
- [Rúbrica de evaluación](#rúbrica-de-evaluación)
- [Entregables](#entregables)

<br />

## Indicaciones generales

Este _Solution_ (`CP2.sln`) contiene un solo _Project_ de tipo web con arquitectura **MVC** (_Model-View-Controller_) llamado `Transportation`, con el objetivo de evaluar tres secciones, cada una con un valor de 5 puntos, para un total de 15 puntos:

- **Entity Framework**.
- **Dependency Injection**.
- **Unit Tests**.

El archivo de configuración del _Project_ (`Transportation.csproj`) contiene todo lo necesario para la compilación y ejecución adecuada del programa; es decir, no es necesario agregar a dicho archivo ninguna otra configuración ni nuevos paquetes (de **NuGet**) para que funcione.

<br />

## Indicaciones específicas

Para poder efectuar las diferentes secciones, es necesario que se asegure de utilizar el _Framework_ `.NET 8.0`, así como tener instalado globalmente la última versión del `Entity Framework 9.0` (específicamente `9.0.11`).

El único _Controller_ (`HomeController`) contiene un solo _Action_ (`Index`), que es la página que se cargará al ejecutarse y cargarse en el navegador web en la ruta raíz.

También tomar en cuenta lo siguiente:

- No se debe agregar manualmente ningún archivo nuevo en ninguna de las capas (_Controllers_, _Interfaces_, _Models_, _Services_, _Tests_, _Views_).

- Ningún _View_ debe ser modificado bajo ninguna circunstancia.

- No se deben modificar los _Namespaces_.

- No se deben agregar más _Actions_ al _Controller_.

<br />

### Entity Framework

El objetivo de esta sección es utilizar la estrategía de _Database First_ para lograr observar en la página inicial (`Index`) del sitio web los datos correctos según la base de datos `Cars.db`. Dicha [base de datos](https://github.com/dtaivpp/car_company_database/blob/master/Car_Database.db) fue tomada de un [repositorio público](https://github.com/dtaivpp/car_company_database). Se recomienda observar su [diagrama relacional](https://raw.githubusercontent.com/dtaivpp/car_company_database/refs/heads/master/Car_Database_ER_Diagram.png) para una mejor comprensión de su estructura.

Específicamente, para esta sección se deben efectuar dos acciones:

- Primero, utilizando el **CLI** (`dotnet`), efectuar el _Scaffolding_ (según la estrategia _Database First_) para que la herramienta **Entity Framework** cree los _Entities_ y todo los necesario para la interacción con la base de datos (`DBSet`, `DbContext`, etc.), según las convenciones por defecto (_Default_). Para esto, utilice lo siguiente:

  - `Cars.db` como la base de datos (origen).

  - `SQLite` como _Database Provider_ (paquete `Microsoft.EntityFrameworkCore.Sqlite`).

  - `Models` como carpeta de salida (destino).

- Segundo, modifique el único _Action_ (`Index`) del único _Controller_ (`HomeController`) para que el _Key_ `Dealer` del `ViewData` contenga los valores correspondientes al nombre (_Name_) y dirección (_Address_) del `Dealer` del "carro de Minnie Mouse". Para esto, tome en cuenta lo siguiente:

  - Ambos valores (nombre y dirección) deben estar concatenados por un `-`; es decir, el resultado final sería: `Joes Autos - 123 Abc Lane Virginia`.

  - Debe utilizar la misma instancia del `CarsContext` (es decir, la variable `db`) con **LINQ** para hacer las consultas (_Queries_) correspondientes.

  - Note que una vez que el _Scaffolding_ haya sido efectuado, ya se debería poder ver (sin hacer ninguna modificación) la página web con algunos valores, como lo son la marca (_Brand_) y el modelo (_Model_) del "carro de Minnie Mouse". Para esto, debe descomentar las líneas que se encuentran comentadas en el _Action_ `Index`.

<br />

### Dependency Injection

El objetivo de esta parte es poder mostrar correctamente en la página web ambas implementaciones de la _Interface_ `IAirplanes` que se hallan en la carpeta `Services`. Estas implementaciones retornan la marca de cada avión y varios modelos de dichas marcas.

Como se puede observar, en la página web se están mostrando (erróneamente) solo los datos de una de las implementaciones (`Airbus`). El objetivo es que se muestren ambas (`Aitbus` y `Boeing`).

Para lograr lo anterior, se debe hacer uso de la técnica de **Dependency Injection** y modificar tanto los argumentos del _Action_ (`Index`) como las configuraciones de los _Services_ (en el `Program.cs`).

<br />

### Unit Tests

Como parte de los modelos (en la carpeta `Models`) se encuentra una _Class_ (en el archivo `Ships.cs`) que contiene varios métodos con respecto a las fechas de desuso de los famosos barcos **_Olympic_**, **_Titanic_** y **_Britannic_**. Así mismo, en la carpeta de pruebas (`Tests`) se halla una _Class_ (llamada `ShipsUnitTests`) que contiene los **Unit Tests** de para dicho _Model_.

Para esta parte, se debe hacer específicamente lo siguiente:

- En el archivo `Ships.cs`, modifique el método `EndOfTitanic` para que retorne la fecha (como tipo `DateTime`) correspondiente al 15 de abril de 1912.

- En el archivo `ShipsUnitTests.cs`, arregle el método `BritannicSankSpecificMonth` para que evalúe correctamente el mes.

- En el mismo archivo `ShipsUnitTests.cs`, agregue un nuevo método llamado `OlympicWasOutOfServiceSpecificDay` que evalúe el día (un valor entre `1` y `31`) de la fecha de desuso del **_Olympic_**, según lo retornado por el método `EndOfOlympic` (del archivo `Ships.cs`).

<br />

## Rúbrica de evaluación

|                    Rubro | Puntos |
| -----------------------: | :----: |
|     **Entity Framework** |   5    |
| **Dependency Injection** |   5    |
|           **Unit Tests** |   5    |
|            **_Totales_** | **15** |

<br />

## Entregables

En la raíz de su repositorio, en el _Branch_ `main`, debe estar esta carpeta (`CP2`) y todo su contenido (incluyendo este archivo `README.md`), con todos los cambios en el código según las especificaciones. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

El código fuente debe incluir, en forma de comentarios, de dónde obtuvo la respuesta/implementación, ya sea con el vínculo (_Link_) de una página o el nombre del chatbot. Ejemplos:

```js
// https://en.wikipedia.org/wiki/Olympic-class_ocean_liner
...
// Gemini
...
```
