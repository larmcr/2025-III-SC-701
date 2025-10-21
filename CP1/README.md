# Caso Práctico 1

| Curso                         | Programación Avanzada en Web          |
| :---------------------------- | :------------------------------------ |
| Código                        | SC-701                                |
| Profesor                      | Luis Andrés Rojas Matey               |
| Fecha y hora de entrega final | Martes 21 de agosto antes de las 9 pm |
| Valor                         | 15 %                                  |

<br />

- [Indicaciones generales](#indicaciones-generales)
- [Indicaciones específicas](#indicaciones-específicas)
  - [Console](#console)
    - [_Improvement_](#improvement)
    - [_Update_](#update)
  - [MVC](#mvc)
    - [_Improvement_](#improvement-1)
    - [_Update_](#update-1)
  - [WebApi](#webapi)
    - [_Improvement_](#improvement-2)
    - [_Update_](#update-2)
- [Rúbrica de evaluación](#rúbrica-de-evaluación)
- [Entregables](#entregables)

<br />

## Indicaciones generales

Este _Solution_ contiene tres _Projects_ hechos con el _Framework_ `.NET 8.0`, los cuales no tienen relación entre sí, es decir, son independientes:

- **Console**: una aplicación de Consola.
- **MVC**: una aplicación web con arquitectura _Model-View-Controller_.
- **WebApi**: un servicio web del tipo _Minimal API_.

Lo primero que debe hacer es copiar esta carpeta (`CP1`), con todo su contenido (incluyendo este archivo `README.md`), a su propio repositorio para que lo trabaje desde allí.

En cada proyecto se debe trabajar cada una de las siguientes tres secciones:

- **_Errors/Warnings_**: arreglar los errores y/o advertencias de compilación.
- **_Improvement_**: mejorar algún componente o lógica de ejecución.
- **_Update_**: incluir un nuevo componente o lógica de ejecución.

Los **_Errors_** sin arreglar no permiten la ejecución del proyecto, por lo que esto es lo primero que se debe resolver.

Los **_Warnings_** sin arreglar permiten la ejecución del proyecto, pero también se deberían resolver; es decir, durante la compilación no se debería mostrar ninguna advertencia. Se recomienda utilizar la opción `--no-incremental` durante la compilación para que siempre se muestren dichas advertencias:

```
$ dotnet build --no-incremental
```

<br />

## Indicaciones específicas

A continuación, las especificaciones funcionales y técnicas para cada uno de los tres proyectos.

### Console

Este proyecto contiene una única _Class_ llamada `Numbers`. El objetivo de este programa es la impresión de los denominados [Números Metálicos](https://es.wikipedia.org/wiki/N%C3%BAmero_met%C3%A1lico), utilizando tres estrategias: una fórmula directa, un algoritmo recursivo y otro iterativo.

Los únicos cambios de código (aparte de aquellos indicados por los errores de compilación) deben hacerse en los métodos privados (`private`), ya que los públicos (`public`) están correctos y funcionales. No está permitido cambiar el tipo de dato flotante utilizado (`double`) ni tampoco su redondeo (que utiliza 10 dígitos decimales).

El método `formula` contiene la implementación de la ecuación directa para el cálculo de cada número metálico: `formula(z) = (z + √(4 + z²)) / 2`. Por ejemplo:

- `formula(0) = (0 + √(4 + 0²)) / 2 ≈ 1.0`
- `formula(1) = (1 + √(4 + 1²)) / 2 ≈ 1.6180339887`
- ...
- `formula(9) = (9 + √(4 + 9²)) / 2 ≈ 9.1097722286`

El resultado final del proyecto (con todos los cambios de manera satisfactoria), al ejecutarse, debería desplegar lo siguiente:

```
$ dotnet run

[0] Platinum
 ↳ formula(0)   ≈ 1
 ↳ recursive(0) ≈ 1
 ↳ iterative(0) ≈ 1

[1] Golden
 ↳ formula(1)   ≈ 1.6180339887
 ↳ recursive(1) ≈ 1.6180339887
 ↳ iterative(1) ≈ 1.6180339887

[2] Silver
 ↳ formula(2)   ≈ 2.4142135624
 ↳ recursive(2) ≈ 2.4142135624
 ↳ iterative(2) ≈ 2.4142135624

[3] Bronze
 ↳ formula(3)   ≈ 3.3027756377
 ↳ recursive(3) ≈ 3.3027756377
 ↳ iterative(3) ≈ 3.3027756377

[4] Copper
 ↳ formula(4)   ≈ 4.2360679775
 ↳ recursive(4) ≈ 4.2360679775
 ↳ iterative(4) ≈ 4.2360679775

[5] Nickel
 ↳ formula(5)   ≈ 5.1925824036
 ↳ recursive(5) ≈ 5.1925824036
 ↳ iterative(5) ≈ 5.1925824036

[6] Aluminum
 ↳ formula(6)   ≈ 6.1622776602
 ↳ recursive(6) ≈ 6.1622776602
 ↳ iterative(6) ≈ 6.1622776602

[7] Iron
 ↳ formula(7)   ≈ 7.1400549446
 ↳ recursive(7) ≈ 7.1400549446
 ↳ iterative(7) ≈ 7.1400549446

[8] Tin
 ↳ formula(8)   ≈ 8.1231056256
 ↳ recursive(8) ≈ 8.1231056256
 ↳ iterative(8) ≈ 8.1231056256

[9] Lead
 ↳ formula(9)   ≈ 9.1097722286
 ↳ recursive(9) ≈ 9.1097722286
 ↳ iterative(9) ≈ 9.1097722286
```

<br />

#### _Improvement_

Actualice el método `recursive` para que calcule correctamente el `n`-ésimo valor de cada sucesión. La definición de la función recursiva (nombrada de ahora en adelante como `f`) del `n`-ésimo valor utilizando un factor `z` (que, para efectos prácticos, es el índice del arreglo de los metales), se define como:

- `f(z, n) =`
  - `1` si `n = 0`
  - `1` si `n = 1`
  - `z • f(z, n - 1) + f(z, n - 2)` si `n > 2`

Es decir:

```
f(z, 0) = 1
f(z, 1) = 1
f(z, n) = z • f(z, n - 1) + f(z, n - 2)
```

Por ejemplo, `f(2, 5) = 41`, ya que:

```
f(2, 0) = 1
f(2, 1) = 1
f(2, 2) = 2 • f(2, 1) + f(2, 0) = 2 • 1 + 1 = 2 + 1 = 3
f(2, 3) = 2 • f(2, 2) + f(2, 1) = 2 • 3 + 1 = 6 + 1 = 7
f(2, 4) = 2 • f(2, 3) + f(2, 2) = 2 • 7 + 3 = 14 + 3 = 17
f(2, 5) = 2 • f(2, 4) + f(2, 3) = 2 • 17 + 7 = 34 + 7 = 41
```

Una vez arreglado este método (`recursive`), ya se debería observar en la Consola (cuando se ejecute el programa), los valores de cada número metálico. Esto gracias a que utiliza la técnica de dividir el resultado del `n`-ésimo con su número anterior: `f(z, n) / f(z, n - 1)`. Es importante mencionar que se definió `25` como `n` para este programa de manera global, ya que se comprobó que no desborda la pila de ejecución, por lo que la razón (división) estará siempre dada por: `f(z, 25) / f(z, 24)`.

<br />

#### _Update_

Implemente el mismo algoritmo de modo iterativo, es decir, utilizando bucles (`do`, `for`, `while`). Para esto se debe actualizar el método `iterative`.

<br />

### MVC

Esta aplicación web contiene una sola página (posee un solo _Controller_ con un par de _Actions_, un _View_ y un solo _Model_). Dentro de dicha página hay un formulario que incluye un campo de texto y un botón.

En el campo de texto se debe agregar una frase cualquiera y, al darle clic al botón, desplegará (en la misma página) la cuenta de cada caracter en orden descendente de acuerdo a su cuenta, así como las versiones en solo mayúscula y solo minúscula de las frases sin caracteres de espacio. Por ejemplo:

```
Phrase: Hello World

Counts:
• 'l': 3
• 'o': 2
• 'd': 1
• 'r': 1
• 'W': 1
• 'e': 1
• 'H': 1

Lower case: helloworld
Upper case: HELLOWORLD
```

<br />

#### _Improvement_

Elimine los espacios (`' '`) como parte del conteo de caracteres y en los despliegues de mayúsculas y minúsculas. Dicha eliminación debe hacerse a nivel de _Character_ utilizando [LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/linq) en el _Action_ de **POST**, no de _String_ (por ejemplo, no se puede usar el método [Replace](https://learn.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-8.0) de _String_).

<br />

#### _Update_

Agregue atributos de validación (_Annotations_) al _Property_ `Phrase` del _Model_ (`TheModel`) para que compruebe lo siguiente:

- El valor es requerido, es decir, que no acepte _String_ vacío ni nulos.
- La longitud de la frase debe ser de 5 a 25 caracteres.

En caso de que alguna validación falle, se debe desplegar el mensaje de error correspondiente en la página.

<br />

### WebApi

Este _Web Service_, cuando se ejecuta, permite obtener, agregar y eliminar números aleatorios de tipo entero y flotante, en una misma estructura tipo [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0).

Este _Web Service_ tiene cinco _Endpoints_, todos a nivel del _Root_ (`"/"`). Estos son dichos _Endpoints_ y sus parámetros:

- **GET**: redirige a la página de _Swagger_ mostrando la definición de los _Endpoints_. No tiene parámetros.
- **POST**: permite obtener la lista. No usa parámetros.
- **PUT**: permite agregar elementos a la lista. Estos son sus parámetros, que se envían por medio del _Form_ del _Body_:
  - `quantity`: entero que indica la cantidad de elementos a agregar a la lista.
  - `type`: tipo de número aleatorio que se generará. Solo permite una de dos opciones:
    - `int`: los números aleatorios serán de tipo entero.
    - `float`: los números aleatorios serán de tipo flotante.
- **DELETE**: permite eliminar una cantidad de elementos de la lista, empezando por el primero. Este es su único parámetro que se envía por medio del _Form_ del _Body_:
  - `quantity`: cantidad de elementos a eliminar de la lista.
- **PATCH**: permite limpiar la lista, eliminando todos sus elementos. Sin parámetros.

Todos los _Endpoints_, al invocarse, deben retornar con un _Status Code_ **200** (_OK/Success_), excepto que se indique lo contrario.

<br />

#### _Improvement_

- En el _Endpoint_ **PUT**, verifique que el parámetro `quantity` sea mayor que cero y el `type` contenga alguno de los valores esperados (`int` o `float`).

- En el _Endpoint_ **DELETE**, verifique que el parámetro `quantity` sea mayor que cero y que la lista tenga al menos la cantidad de elementos indicado por dicho parámetro.

Si alguna de las validaciones falla, se debe retornar el error con un _Status Code_ **400** (_Bad Request_) y su mensaje en JSON usando el _Key_ `error`. Por ejemplo:

```JSON
{
  "error": "'quantity' must be higher than zero"
}
```

<br />

#### _Update_

- En el _Endpoint_ **POST**, agregue un parámetro opcional `xml` tipo _Boolean_, como parte de los _Headers_, con valor `false` por defecto (_Default_). En caso que su valor sea `true`, se debe retornar la lista en formato XML.

- Implemente el _Endpoint_ **PATCH**, para que al invocarse la lista se limpie, eliminando todos sus elementos.

<br />

## Rúbrica de evaluación

|                       | **Console** | **MVC** | **WebApi** |
| --------------------: | :---------: | :-----: | :--------: |
| **_Errors/Warnings_** |      1      |    1    |     1      |
|     **_Improvement_** |      2      |    2    |     2      |
|          **_Update_** |      2      |    2    |     2      |
|           **Totales** |    **5**    |  **5**  |   **5**    |

<br />

## Entregables

En la raíz de su repositorio, en el _Branch_ `main`, debe estar esta carpeta (`CP1`) y todo su contenido (incluyendo este archivo `README.md`), con todos los cambios en el código según las especificaciones. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

El código fuente debe incluir, en forma de comentarios, de dónde obtuvo la respuesta/implementación, ya sea con el vínculo (_Link_) de una página o el nombre del chatbot. Ejemplos:

```js
// https://en.wikipedia.org/wiki/Metallic_mean
...
// Gemini
...
```
