# Práctica Programada 2

| Curso                   | Programación Avanzada en Web          |
| :---------------------- | :------------------------------------ |
| Código                  | SC-701                                |
| Profesor                | Luis Andrés Rojas Matey               |
| Valor                   | 4 %                                   |
| Fecha y hora de entrega | Martes 7 de octubre antes de las 6 pm |

<br />

- [Introducción](#introducción)
- [Objetivo](#objetivo)
- [Especificaciones funcionales](#especificaciones-funcionales)
  - [Validar los datos](#validar-los-datos)
  - [Efectuar operaciones](#efectuar-operaciones)
  - [Mostrar resultados](#mostrar-resultados)
- [Especificaciones técnicas](#especificaciones-técnicas)
- [Entregables](#entregables)
- [Evaluación](#evaluación)

<br />

## Introducción

La gran mayoría de computadoras y dispositivos digitales actuales utilizan el lenguaje binario para hacer sus cálculos. Este lenguaje permite la representación de números en dispositivos electrónicos que funcionan por medio de pulsos eléctricos que representan los valores de 0 y 1.

<br />

## Objetivo

Aplicar lo aprendido utilizando la plataforma `ASP.NET Core MVC` con el _Framework_ `.NET 8.0`.

<br />

## Especificaciones funcionales

Al ser un programa hecho con `ASP.NET Core MVC`, este se ejecutará en un navegador web.

Cuando se muestra la página web, debe contener un formulario para que el usuario pueda indicar dos cadenas de caracteres (_Strings_) que representen números binarios. Por lo tanto, este formulario debe tener al menos estos elementos:

- Dos etiquetas (_Labels_) que identifiquen los operandos. Estos deben mostrarse con las letras minúsculas `a` y `b`.

- Dos campos de texto (_Textboxes_) donde el usuario pueda digitar los dos _Strings_ que representen los valores binarios.

- Un botón (_Button_) para poder enviar el **HTTP POST** (_Submit Request_) con la información al servidor.

Una vez que el usuario cliquea el botón, deben ejecutarse estos tres pasos en el mismo orden:

1. Validar los datos
2. Efectuar operaciones
3. Mostrar resultados

<br />

### Validar los datos

Al ser cadenas de caracteres (_Strings_) que representan números binarios, cada uno (`a` y `b`) debe cumplir con los siguientes requisitos:

- Solo puede contener los caracteres `0` y `1`, por lo que cualquier otro carácter lo invalida.

- Su longitud:

  - Debe ser mayor que cero, es decir, un _String_ vacío no es válido.
  - No puede exceder los 8 caracteres (simulando un _Byte_), de lo contrario, no será válido.
  - Debe ser múltiplo de 2, es decir, el largo de cada _String_ debe ser exactamente 2, 4, 6 u 8 caracteres.

Si cualquiera de las validaciones anteriores falla, debe informarse al usuario por medio de uno o varios mensajes en la página.

Ejemplos:

- Válidos:

  - `00`
  - `01`
  - `0000`
  - `101010`
  - `01010101`

- No válidos:
  - ` ` (_String_ vacío)
  - `0` (longitud no es múltipo de 2)
  - `000` (longitud no es múltipo de 2)
  - `101010101` (longitud mayor que 8)
  - `1F100000` (carácter no válido)

<br />

### Efectuar operaciones

Si las validaciones "pasaron" (ambos _Strings_ son válidos), entonces se deben efectuar las siguientes operaciones:

- Operaciones binarias:

  - `a` **AND** `b`
  - `a` **OR** `b`
  - `a` **XOR** `b`

- Operaciones aritméticas:

  - `a` **+** `b` (suma)
  - `a` **•** `b` (multiplicación)

- Cambio de bases:
  - **Binaria** (`0`, `1`)
  - **Octal** (`0`, `1`, `2`, `3`, `4`, `5`, `6`, `7`)
  - **Decimal** (`0`, `1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`)
  - **Hexadecimal** (`0`, `1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `A`, `B`, `C`, `D`, `E`, `F`)

<br />

### Mostrar resultados

Ambos números binarios (`a` y `b`) y los resultados de las operaciones (tanto binarias como aritméticas) deben ser mostrados en todas las bases, siempre y cuando la validación haya "pasado".

Los valores binarios mostrados de `a` y `b` deben tener una longitud de un _Byte_, es decir, ocho dígitos. En caso de que un _String_ sea más corto, se le agregarán ceros (`0`) a su izquierda para completar.

Todos los valores serán representados con números positivos, mayores o iguales que cero, y deben ser mostrados en una única tabla.

Ejemplo:

- `a`: `1010`
- `b`: `11`

|                 |   Bin    | Oct | Dec | Hex |
| :-------------: | :------: | :-: | :-: | :-: |
|       `a`       | 00001010 | 12  | 10  |  A  |
|       `b`       | 00000011 |  3  |  3  |  3  |
| `a` **AND** `b` |    10    |  2  |  2  |  2  |
| `a` **OR** `b`  |   1011   | 13  | 11  |  B  |
| `a` **XOR** `b` |   1001   | 11  |  9  |  9  |
|  `a` **+** `b`  |   1101   | 15  | 13  |  D  |
|  `a` **•** `b`  |  11110   | 36  | 30  | 1E  |

<br />

## Especificaciones técnicas

- El trabajo se debe realizar con el lenguaje de programación `C#`, la plataforma `ASP.NET Core MVC` y el _Framework_ `.NET 8.0`.

- Debe contener un _Solution_ y un _Project_, así como el _Project_ incluido en el _Solution_.

- Al ser de arquitectura **MVC** (_Model-View-Controller_), debe haber al menos una clase como _Model_, una clase de _Controller_ y un _View_ utilizando **Razor**.

- La página donde estará el formulario, los mensajes con errores de validación y la tabla con los valores debe ser la de la ruta por defecto (_Default_).

- Las validaciones se deben hacer utilizando _Annotations_ en el _Model_, el cual tendrá, al menos, dos _Properties_ que representan los valores _String_ de `a` y `b`.

- Como parte del modelo (no necesariamente en la misma clase), se deben mantener todos los valores binarios de todos los ítemes, incluyendo los resultados de las operaciones. Estos deben ser siempre de tipo _String_.

- Las operaciones binarias (**AND**, **OR**, **XOR**) deben realizarse con métodos propios sobre los _Strings_; es decir, se debe iterar sobre cada carácter y hacer las comparaciones correspondientes. Para las demás operaciones (aritméticas y cambio de bases), se puede utilizar cualquier estrategia, ya sea con métodos propios o los proveídos por `.NET` (como por ejemplo la clase [**_Convert_**](https://learn.microsoft.com/en-us/dotnet/api/system.convert?view=net-8.0)), además de que es posible efectuarlas en la "capa" que considere oportuna.

- Se puede utilizar cualquier _Framework_ de estilos (CSS), o bien, puede utilizar sus propios. Así mismo, puede utilizar cualquier _Library_ de JavaScript, tal como [**_JQuery_**](https://jquery.com).

- Se recomienda utilizar el editor [Visual Studio Code](https://code.visualstudio.com).

<br />

## Entregables

Esta es una tarea individual, por lo que en su respectivo repositorio de **Git**, específicamente en el _Branch_ principal (`main`), debe hallarse un directorio llamado `PP2`, el cual contenga:

- Todo el código fuente que incluya el archivo _Solution_ y la carpeta del _Project_. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

  - Puede copiar el archivo [`.gitignore`](https://github.com/larmcr/2025-III-SC-701/blob/main/.gitignore) del [repositorio del profesor](https://github.com/larmcr/2025-III-SC-701) en la raíz de su repositorio para excluir las carpetas indicadas.

- Un archivo de documentación llamado `README.md`, hecho en [Markdown](https://www.markdownguide.org), donde se indique lo siguiente:

  - Su nombre y carné.

  - Los comandos de `dotnet` utilizados (**CLI**).

  - Páginas web donde halló posibles soluciones a problemas encontrados o _Snippets_ de código.

  - _Prompts_ (consultas y respuestas) de los chatbots de IA (`Copilot`, `Gemini`, `ChatGPT`, etc.) que haya utilizado.

    - Este puede ser el vínculo compartido de dicho chatbot.

  - Las respuestas a las siguientes preguntas:
    - ¿Cuál es el número que resulta al multiplicar, si se introducen los valores máximos permitidos en `a` y `b`? Indíquelo en todas las bases (binaria, octal, decimal y hexadecimal).
    - ¿Es posible hacer las operaciones en otra capa? Si sí, ¿en cuál sería?

Ejemplo de estructura:

```
Repo. [directorio]
└── PP2 [directorio]
    ├── MyProject [directorio]
    ├── MySolution.sln [archivo]
    └── README.md [archivo]
```

<br />

## Evaluación

La siguiente tabla muestra los rubros a evaluar, siempre y cuando el proyecto compile correctamente; así mismo, en caso de no compilar satisfactoriamente, se evaluará como que no fue entregado, es decir, con cero puntos.

|       | Rubros                  | Puntos |
| :---: | :---------------------- | :----: |
| **A** | Estructura              |   2    |
| **B** | Validaciones            |   2    |
| **C** | Operaciones binarias    |   2    |
| **D** | Operaciones aritméticas |   2    |
| **E** | Cambio de bases         |   2    |
| **F** | Tabla con valores       |   2    |
| **G** | Documentación           |   3    |
|       | **Total**               | **15** |
