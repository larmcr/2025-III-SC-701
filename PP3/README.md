# Práctica Programada 3

| Curso                   | Programación Avanzada en Web           |
| :---------------------- | :------------------------------------- |
| Código                  | SC-701                                 |
| Profesor                | Luis Andrés Rojas Matey                |
| Valor                   | 4 %                                    |
| Fecha y hora de entrega | Martes 21 de octubre antes de las 6 pm |

<br />

- [Introducción](#introducción)
- [Objetivo](#objetivo)
- [Especificaciones funcionales](#especificaciones-funcionales)
- [_Endpoint_ `/`](#endpoint-)
- [_Endpoint_ `/include`](#endpoint-include)
  - [Ejemplos](#ejemplos)
- [_Endpoint_ `/replace`](#endpoint-replace)
  - [Ejemplos](#ejemplos-1)
- [_Endpoint_ `/erase`](#endpoint-erase)
  - [Ejemplos](#ejemplos-2)
- [Especificaciones técnicas](#especificaciones-técnicas)
- [Entregables](#entregables)
- [Evaluación](#evaluación)

<br />

## Introducción

Los APIs sirven para la comunicación entre aplicaciones. En un entorno web, estos sirven para la comunicación entre un cliente (usualmente un _Web Browser_) y un servidor, usando el protocolo **HTTP** y sus respectivos métodos o verbos.

<br />

## Objetivo

Aplicar los conocimientos adquiridos al utilizar un _Minimal API_ con la herramienta `ASP.NET Core Minimal API` del _Framework_ `.NET 8.0`.

<br />

## Especificaciones funcionales

Al ser una **Web API**, una vez se ejecuta, este _Web Service_ podrá consumirse con cualquier cliente **HTTP**/**REST(ful)**, como lo es, por ejemplo, [Postman](https://www.postman.com). Este servicio tendrá cuatro (4) _Endpoints_:

- `/`
- `/include`
- `/replace`
- `/erase`

Para cada _Endpoint_, cuando se indican parámetros, todos serán obligatorios, excepto el `xml` que es opcional y tendrá un valor de `false` por defecto (_Default_).

Si alguna validación falla, entonces el _Response_ debe tener el _Status Code_ **400** (_Bad Request_). Así mismo, todos los mensajes de error serán en formato **JSON** (independientemente del parámetro `xml`) y su llave/clave (_Key_) será `error`. Ejemplo:

```json
{
  "error": "This is the error message"
}
```

Por el contrario (es decir, si el _Request_ es válido), entonces su _Response_ debe contener el _Status Code_ **200** (_OK_). Así mismo, cuando el resultado es en formato **JSON**, debe contener las siguientes llaves (_Keys_):

- `ori`: oración original
- `new`: oración nueva

Por ejemplo:

```json
{
  "ori": "This is just a test that shows how the 'include' endpoint works over some text of this sentence",
  "new": "Hello This is just a test that shows how the 'include' endpoint works over some text of this sentence"
}
```

Y este sería su equivalente en formato **XML**:

```xml
<?xml version="1.0" encoding="utf-16"?>
<Result xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Ori>This is just a test that shows how the 'include' endpoint works over some text of this sentence</Ori>
    <New>Hello This is just a test that shows how the 'include' endpoint works over some text of this sentence</New>
</Result>
```

<br />

## _Endpoint_ `/`

Este _Endpoint_ será de tipo **GET** y hará un _Redirect_ al _User Interface_ (UI) de **Swagger**, permitiendo observar la definición de los _Endpoints_ en una página web. Este _Endpoint_ no recibe ningún parámetro.

<br />

## _Endpoint_ `/include`

Este _Endpoint_ será de tipo **POST** y permitirá incluir una palabra en una posición específica de una oración. Dicha posición se basa en la cantidad de palabras que tenga dicha oración y su índice empieza en cero. Estos serían sus parámetros:

| Parámetro  | Representación           | Tipo     | Desde     | Validaciones               |
| :--------- | :----------------------- | :------- | :-------- | :------------------------- |
| `position` | La posición              | _int_    | _Route_   | Igual o mayor que cero     |
| `value`    | La palabra a incluir     | _string_ | _Query_   | Longitud mayor que cero    |
| `text`     | La oración               | _string_ | _Form_    | Longitud mayor que cero    |
| `xml`      | El formato del resultado | _bool_   | _Headers_ | Ninguna ya que es opcional |

Si el parámetro `position` es mayor que el largo de palabras de la oración, entonces la palabra se debe agregar al final de la oración.

<br />

### Ejemplos

Si el parámetro `text` tiene la siguiente oración: `This is just a test that shows how the 'include' endpoint works over some text of this sentence`.

Entonces el siguiente _Request_: `/include/0?value=Hello`

Retornaría este resultado en formato **JSON**:

```json
{
  "ori": "This is just a test that shows how the 'include' endpoint works over some text of this sentence",
  "new": "Hello This is just a test that shows how the 'include' endpoint works over some text of this sentence"
}
```

Y así cuando el parámetro `xml` es `true`:

```xml
<?xml version="1.0" encoding="utf-16"?>
<Result xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Ori>This is just a test that shows how the 'include' endpoint works over some text of this sentence</Ori>
    <New>Hello This is just a test that shows how the 'include' endpoint works over some text of this sentence</New>
</Result>
```

---

Este otro _Request_: `/include/3?value=Hello`

Retornaría esto:

```json
{
  "ori": "This is just a test that shows how the 'include' endpoint works over some text of this sentence",
  "new": "This is just Hello a test that shows how the 'include' endpoint works over some text of this sentence"
}
```

---

Así mismo, este otro _Request_: `/include/100?value=Hello`

Tendría que retornar esto:

```json
{
  "ori": "This is just a test that shows how the 'include' endpoint works over some text of this sentence",
  "new": "This is just a test that shows how the 'include' endpoint works over some text of this sentence Hello"
}
```

---

Con respecto a los errores, por ejemplo, este _Request_: `/include/-2?value=Hello`

Retornaría un mensaje de error similar a este (en formato **JSON**):

```json
{
  "error": "'position' must be 0 or higher"
}
```

---

Y esto otro _Request_: `/include/100?value=`

Retornaría algo similar a esto:

```json
{
  "error": "'value' cannot be empty"
}
```

<br />

## _Endpoint_ `/replace`

Este _Endpoint_ será de tipo **PUT** y permitirá reemplazar las palabras de una longitud específica dentro de una oración, por otra palabra. Es decir, buscará todas las palabras de dicha longitud y las reemplazará para una nueva palabra indicada. Estos son sus parámetros:

| Parámetro | Representación                       | Tipo     | Desde     | Validaciones               |
| :-------- | :----------------------------------- | :------- | :-------- | :------------------------- |
| `length`  | La longitud                          | _int_    | _Route_   | Mayor que cero             |
| `value`   | La palabra por la que se reemplazará | _string_ | _Query_   | Longitud mayor que cero    |
| `text`    | La oración                           | _string_ | _Form_    | Longitud mayor que cero    |
| `xml`     | El formato del resultado             | _bool_   | _Headers_ | Ninguna ya que es opcional |

<br />

### Ejemplos

Con el parámetro `text` conteniendo la siguiente oración: `This is just a test that shows how the 'replace' endpoint works over some text of this sentence`.

Este _Request_: `/replace/4?value=hello`

Retornaría este _Response_ en **JSON**:

```json
{
  "ori": "This is just a test that shows how the 'replace' endpoint works over some text of this sentence",
  "new": "hello is hello a hello hello shows how the 'replace' endpoint works hello hello hello of hello sentence"
}
```

Y así cuando se indica que sea **XML**:

```xml
<?xml version="1.0" encoding="utf-16"?>
<Result xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Ori>This is just a test that shows how the 'replace' endpoint works over some text of this sentence</Ori>
    <New>hello is hello a hello hello shows how the 'replace' endpoint works hello hello hello of hello sentence</New>
</Result>
```

<br />

## _Endpoint_ `/erase`

Este _Endpoint_ será de tipo **DELETE** y permitirá eliminar las palabras de una longitud específica dentro de una oración. Estos serían los parámetros:

| Parámetro | Representación           | Tipo     | Desde     | Validaciones               |
| :-------- | :----------------------- | :------- | :-------- | :------------------------- |
| `length`  | La longitud              | _int_    | _Route_   | Mayor que cero             |
| `text`    | La oración               | _string_ | _Form_    | Longitud mayor que cero    |
| `xml`     | El formato del resultado | _bool_   | _Headers_ | Ninguna ya que es opcional |

<br />

### Ejemplos

Si el parámetro `text` tiene la siguiente oración: `This is just a test that shows how the 'erase' endpoint works over some text of this sentence`.

Por lo tanto, este _Request_: `/erase/4`

Retornaría este _Response_ en **JSON**:

```json
{
  "ori": "This is just a test that shows how the 'erase' endpoint works over some text of this sentence",
  "new": "is a shows how the 'erase' endpoint works of sentence"
}
```

Y así en **XML**:

```xml
<?xml version="1.0" encoding="utf-16"?>
<Result xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Ori>This is just a test that shows how the 'erase' endpoint works over some text of this sentence</Ori>
    <New>is a shows how the 'erase' endpoint works of sentence</New>
</Result>
```

<br />

## Especificaciones técnicas

- El trabajo se debe realizar con el lenguaje de programación `C#`, la arquitectura `ASP.NET Core Minimal API` y el _Framework_ `.NET 8.0`.

- Debe contener un _Solution_ y un _Project_, así como el _Project_ incluido en el _Solution_.

- Se recomienda utilizar el editor [Visual Studio Code](https://code.visualstudio.com).

<br />

## Entregables

Esta es una tarea individual, por lo que en su respectivo repositorio de **Git**, específicamente en el _Branch_ principal (`main`), debe hallarse un directorio llamado `PP3`, el cual contenga:

- Todo el código fuente que incluya el archivo _Solution_ y la carpeta del _Project_. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

  - Puede copiar el archivo [`.gitignore`](https://github.com/larmcr/2025-III-SC-701/blob/main/.gitignore) del [repositorio del profesor](https://github.com/larmcr/2025-III-SC-701) en la raíz de su repositorio para excluir las carpetas indicadas.

- Un archivo de documentación llamado `README.md`, hecho en [Markdown](https://www.markdownguide.org) con su respectiva sintaxis, donde se indique lo siguiente:

  - Su nombre y carné.

  - Los comandos de `dotnet` utilizados (**CLI**).

  - Páginas web donde halló posibles soluciones a problemas encontrados o _Snippets_ de código.

  - _Prompts_ (consultas y respuestas) de los chatbots de IA (`Copilot`, `Gemini`, `ChatGPT`, etc.) que haya utilizado.

    - Este puede ser el vínculo compartido de dicho chatbot.

  - Las respuestas a las siguientes preguntas (deben ser respondidas por usted mismo):
    - ¿Es posible enviar valores en el _Body_ (por ejemplo, en el _Form_) del _Request_ de tipo **GET**?
    - ¿Qué ventajas y desventajas observa con el _Minimal API_ si se compara con la opción de utilizar _Controllers_?

Ejemplo de estructura:

```
Repo. [directorio]
└── PP3 [directorio]
    ├── MyProject [directorio]
    ├── MySolution.sln [archivo]
    └── README.md [archivo]
```

<br />

## Evaluación

La siguiente tabla muestra los rubros a evaluar, siempre y cuando el proyecto compile correctamente; así mismo, en caso de no compilar satisfactoriamente, se evaluará como que no fue entregado, es decir, con cero puntos.

|       | Rubros                     | Puntos |
| :---: | :------------------------- | :----: |
| **A** | Estructura                 |   2    |
| **B** | _Endpoint_ `/`             |   1    |
| **C** | _Endpoint_ `/include`      |   4    |
| **D** | _Endpoint_ `/replace`      |   4    |
| **E** | _Endpoint_ `/erase`        |   4    |
| **F** | Documentación <sup>1</sup> |   5    |
|       | **Total**                  | **20** |

1. Para el rubro de **Documentación**, se rebajará un punto por cada error ortográfico. Así mismo, si el archivo no es renderizado correctamente (ya que debe ser escrito usando la sintaxis del formato **Markdown**), se evaluará con cero puntos.
