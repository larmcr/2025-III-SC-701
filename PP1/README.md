# Práctica Programada 1

| Curso                   | Programación Avanzada en Web             |
| :---------------------- | :--------------------------------------- |
| Código                  | SC-701                                   |
| Profesor                | Luis Andrés Rojas Matey                  |
| Valor                   | 4 %                                      |
| Fecha y hora de entrega | Martes 23 de setiembre antes de las 6 pm |

<br />

- [Introducción](#introducción)
- [Objetivo](#objetivo)
- [Especificaciones funcionales](#especificaciones-funcionales)
  - [Resumen](#resumen)
  - [Detalles](#detalles)
- [Especificaciones técnicas](#especificaciones-técnicas)
- [Entregables](#entregables)
- [Evaluación](#evaluación)

<br />

## Introducción

La fórmula de la suma aritmética de números enteros positivos (`1 + 2 + 3 + … + n`) se le atribuye a Carl Friedrich Gauss, sin embargo, tal parece que dicha atribución [pareciera más bien anecdótica](https://francis.naukas.com/2010/04/15/iii-carnaval-de-matematicas-toda-la-verdad-sobre-la-anecdota-de-gauss-el-nino-prodigio-su-profesor-y-la-suma-de-1-a-100).

<br />

## Objetivo

Familiarizarse con el lenguaje de programación `C#`, el entorno de desarrollo `.NET` y su interfaz de línea de comandos (**CLI**) `dotnet`, creando un programa capaz de calcular la suma de los primeros `n` números naturales, por medio de varias técnicas, así como investigar la razón de las diferencias entre dichas formas en cuanto a los valores calculados.

<br />

## Especificaciones funcionales

### Resumen

- Crear una aplicación para **Consola**.
- Implementar dos métodos: **SumFor** y **SumIte**.
- Validar ascendentemente desde `1` hasta `Max` con cada método hasta encontrar el último `sum` válido.
- Validar descendentemente desde `Max` hasta `1` con cada método hasta encontrar el primer `sum` válido.
- Mostrar resultados en la **Consola**.

<br />

### Detalles

Se debe crear un programa para **Consola** que contenga dos implementaciones de la suma de números naturales. Específicamente, este programa debe tener estos dos métodos establecidos:

- **SumFor**: retorna la suma de los primeros `n` números naturales utilizando la fórmula `Sum(n) = n * (n + 1) / 2`.

- **SumIte**: retorna igualmente la suma de los primeros números enteros positivos utilizando una versión iterativa equivalente a la siguiente función recursiva:
  - `SumRec(1) = 1`
  - `SumRec(n) = n + SumRec(n - 1)`

Ambos métodos (**SumFor** y **SumIte**) deben recibir un número entero `n` positivo (mayor que cero) y retornar un número entero (no necesariamente positivo). Por ejemplo, esta es una implementación de la versión recursiva:

```csharp
int SumRec(int n)
{
    return n > 1 ? n + SumRec(n - 1) : n;
}
```

Para efectos prácticos, no se debe validar el valor del parámetro `n`, pues se asume que siempre será un número natural mayor que cero. Igualmente, no se deben validar los valores calculados dentro de dichos métodos.

Cuando el programa se ejecuta (utilizando el comando `dotnet run`), se deben utilizar los métodos creados (**SumFor** y **SumIte**) para encontrar el último o primer valor de `n` que dé como resultado una suma válida de los enteros (este valor se denominará como `sum`). Un valor válido de suma significa que debe ser también entero positivo (mayor que cero). Para lograr esto, el valor del párametro `n` (con el cual se ejecutan los métodos **SumFor** y **SumIte**) debe recorrerse desde `1` hasta el máximo entero positivo con signo de 32 bits (`Max`) de forma ascendente (desde `1` hasta `Max`) y también de forma descendente (desde `Max` hasta `1`). Por ejemplo:

- Desde `1` hasta `Max` (ascendente): `1, 2, 3, 4, 5, ... Max`.
- Desde `Max` hasta `1` (descendente): `Max, Max - 1, Max - 2,... 1`.

En cada uno de los cuatro casos (dos para **SumFor** y dos para **SumIte**), el chequeo finaliza una vez se halla el último (de la estrategia ascendente) o primer (de la estrategia descendente) valor válido de `sum`. En otras palabras, se debe chequear cada valor de `n` hasta encontrar el último o primer valor válido de `sum` (dependiendo de la estrategia).

Por ejemplo, utilizando el método **SumFor** (`SumFor(n) = sum`) con la estrategia ascendente (`1 ... Max`), el parámetro `n` va desde `1` hasta `Max` hasta que encuentre el último valor de `n` que genere un valor de `sum` válido:

- `SumFor(1) = 1`
- `SumFor(2) = 3`
- `SumFor(3) = 6`
- ...
- `SumFor(46340) = 1073720970` (este es el último `sum` válido)
- `SumFor(46341) = -1073716337` (este `sum` no es válido por ser negativo)

Así mismo, con el mismo método pero de forma descendente (`Max ... 1`):

- `SumFor(2147483647) = -1073741824`
- `SumFor(2147483646) = -1073741823`
- `SumFor(2147483645) = -1073741821`
- ...
- `SumFor(2147437307) = -20854`
- `SumFor(2147437306) = 25487` (este es el primer `sum` válido)

Una vez encontrado el último o primer `sum` válido (dependiendo de la estrategia, ya sea ascendente o descendente), este se imprimirá en la **Consola**, mostrando el método utilizado, la estrategia (ascendente o descendente), así como los valores válidos de `n` y `sum`. Ejemplo:

```bash
$ dotnet run

• SumFor:
        ◦ From 1 to Max → n: 46340 → sum: 1073720970
        ◦ From Max to 1 → n: 2147437306 → sum: 25487

• SumIte:
        ◦ From 1 to Max → n: 65535 → sum: 2147450880
        ◦ From Max to 1 → n: 2147483646 → sum: 1073741825
```

<br />

## Especificaciones técnicas

- El trabajo debe realizarse con el lenguaje de programación [`C#`](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp) del _Framework_ [`.NET 8.0`](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), utilizando su correspondiente _Command Line Interface_ ([`dotnet`](https://learn.microsoft.com/en-us/dotnet/core/tools)).

- Debe contener un _Solution_ y un _Project_, así como el _Project_ incluido en el _Solution_.

- Todos los valores numéricos deben ser de tipo `int` ([`System.Int32`](https://learn.microsoft.com/en-us/dotnet/api/system.int32?view=net-8.0)), por lo que su valor máximo será `2147483647` (tal como lo indica la propiedad [`MaxValue`](https://learn.microsoft.com/en-us/dotnet/api/system.int32.maxvalue?view=net-8.0)).

<br />

## Entregables

Este es una tarea individual, por lo que en su respectivo repositorio de **Git**, específicamente en el _Branch_ principal (`main`), debe hallarse una carpeta llamada `PP1`, la cual contenga:

- Todo el código fuente que incluya el archivo _Solution_ y la carpeta del _Project_. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

  - Puede copiar el archivo [`.gitignore`](https://github.com/larmcr/2025-III-SC-701/blob/main/.gitignore) del [repositorio del profesor](https://github.com/larmcr/2025-III-SC-701) en la raíz de su repositorio para excluir las carpetas indicadas.

- Un archivo de documentación llamado `README.md`, hecho en [Markdown](https://www.markdownguide.org), donde se indique lo siguiente:

  - Su nombre y carné.

  - Los comandos de `dotnet` utilizados (**CLI**).

  - Páginas web donde halló posibles soluciones a problemas encontrados o _Snippets_ de código.

  - _Prompts_ (consultas y respuestas) de los chatbots de IA (`Copilot`, `Gemini`, `ChatGPT`, etc.) que haya utilizado.

    - Este puede ser el vínculo compartido de dicho chatbot.

  - La respuesta a la siguientes preguntas:
    - ¿Por qué todos los valores resultantes tanto de `n` como de `sum` difieren entre métodos (fórmula e implementación iterativa) y estrategias (ascendente y descendente)?
    - ¿Qué cree que sucedería si se utilizan las mismas estrategias (ascendente y descendente) pero con el método recursivo de suma (**SumRec**)? [si desea puede implementarlo y observar qué sucede en ambos escenarios]

<br />

## Evaluación

La siguiente tabla muestra los ítemes a evaluar, siempre y cuando el proyecto compile correctamente; así mismo, en caso de no compilar satisfactoriamente, se evaluará como que no fue entregado, es decir, con cero puntos.

|       | Ítemes                                                                               | Puntos |
| :---: | :----------------------------------------------------------------------------------- | :----: |
| **A** | Estructura correcta del proyecto (directorio **PP1**, _Solution_ y _Project_, etc.)  |   1    |
| **B** | Implementación correcta de métodos de sumas (**SumFor** y **SumIte**)                |   2    |
| **C** | Implementación correcta de estrategias de valores válidos (ascendente y descendente) |   2    |
| **D** | Presentación correcta de valores en **Consola**                                      |   2    |
| **E** | Documentación correcta                                                               |   3    |
|       | **Total**                                                                            | **10** |
