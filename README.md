# Ruta de mapas – Grafos

Aplicación de escritorio en **C# / Windows Forms** para crear, editar y analizar grafos de forma visual. El usuario coloca vértices sobre un lienzo, los conecta con aristas (dirigidas o no dirigidas, ponderadas o no ponderadas) y consulta la estructura resultante mediante la matriz de adyacencia, la lista de adyacencia y recorridos **BFS** y **DFS**.

---

## Características principales

- **Edición visual del grafo**: clic en el lienzo para ubicar un vértice, arrastre de vértices con el ratón y doble clic en un espacio vacío para enfocar el campo de nombre.
- **Vértices y aristas**: alta y baja de vértices (la baja elimina automáticamente las aristas conectadas) y de aristas.
- **Modos de grafo**: dirigido (`A -> B`) o no dirigido (`A <-> B`), y ponderado (con peso entero de 1 a 9999) o no ponderado.
- **Tres implementaciones intercambiables** de la misma interfaz (`BaseGraph`), seleccionables en tiempo de ejecución:
  - Lista simple propia (`SimpleListGraph`, con `SimpleList<T>`).
  - `LinkedList<T>` de .NET (`LinkedListGraph`).
  - `List<T>` de .NET (`ListGraph`).
- **Verificación de adyacencia** entre dos vértices y consulta de vecinos (sucesores, en grafos dirigidos).
- **Matriz de adyacencia** y **lista de adyacencia** en ventanas independientes.
- **Recorridos BFS** (con cola, incluye distancia mínima en aristas) y **DFS** (iterativo, con pila), con insignias de orden de visita sobre el lienzo.
- **Bitácora de operaciones** con marca de tiempo y categoría.

---

## Requisitos previos y tecnologías

| Elemento | Detalle |
|---|---|
| Sistema operativo | Windows (la aplicación usa Windows Forms y fuentes como *Segoe UI*). |
| Framework | **.NET 10** (`net10.0-windows` según `Ruta de mapas/Ruta de mapas.csproj`). |
| SDK | .NET 10 SDK, o Visual Studio con soporte para .NET 10. |
| Formato de solución | `Ruta de mapas.slnx` (formato XML de solución; requiere herramientas recientes que lo soporten). |
| Lenguaje | C# con `<Nullable>enable</Nullable>` e `<ImplicitUsings>enable</ImplicitUsings>`. |
| Dependencias externas | Ninguna: el proyecto sólo referencia el SDK de .NET y Windows Forms. No hay paquetes NuGet. |

---

## Instalación paso a paso

1. **Instalar el SDK de .NET 10** desde el sitio oficial de Microsoft, o instalar Visual Studio con la carga de trabajo *Desarrollo de escritorio .NET*.
2. **Obtener el código**: descargar el repositorio como ZIP o clonarlo:
   ```bash
   git clone <URL-del-repositorio>
   cd Ruta-de-mapas-Grafos--master
   ```
3. **Abrir la solución** `Ruta de mapas.slnx` en Visual Studio, o desde la terminal:
   ```bash
   dotnet restore "Ruta de mapas.slnx"
   ```
4. **Compilar**:
   ```bash
   dotnet build "Ruta de mapas.slnx" -c Debug
   ```
5. **Ejecutar**:
   ```bash
   dotnet run --project "Ruta de mapas/Ruta de mapas.csproj"
   ```
   También puede ejecutarse con F5 desde Visual Studio.

> Estos pasos son los estándar para un proyecto .NET. **No se verificaron en este entorno**, ya que el contenedor de análisis no tiene el SDK de .NET instalado.

---

## Instrucciones de uso con ejemplos

### 1. Crear vértices
- **Con clic**: haz clic en un espacio vacío del lienzo; el siguiente vértice se creará en esa posición.
- **Desde el panel**: escribe el nombre en *Nombre del vértice* y pulsa **Nuevo Vértice**. Si no se hizo clic antes, la posición se calcula automáticamente.

### 2. Conectar vértices
1. Elige el vértice **origen** y **destino** en los desplegables de *Inserción*. También puedes seleccionar vértices haciendo clic sobre ellos en el lienzo.
2. Marca **Arista Ponderada (con peso)** y ajusta el peso si lo necesitas.
3. Pulsa **Conectar Vértices (Arista)**.

Ejemplo: en modo *No Dirigido* y *No Ponderado*, conectar `Centro` con `Norte` produce el mensaje:
`Conexión no dirigida (<->) NO PONDERADA agregada entre 'Centro' y 'Norte'.`

### 3. Verificar adyacencia y consultar vecinos
- En *Verificación de Adyacencia* selecciona dos vértices y pulsa **Verificar Adyacencia**: el resultado aparece en el panel y la arista se resalta en el lienzo.
- Con un solo vértice seleccionado, **Obtener Adyacentes** lista sus vecinos (en grafos dirigidos, los sucesores salientes).

### 4. Recorridos
- Elige el **origen** en *Traversals (BFS / DFS)* (por defecto, el primer vértice creado) y pulsa **BFS** o **DFS**.
- El lienzo muestra el orden de visita y, en BFS, la distancia `d=n` desde el origen.
- **Clear marks** limpia las marcas del recorrido.

### 5. Vistas de estructura
- **Matriz** abre la matriz de adyacencia. Las celdas con `1` son aristas no ponderadas y las celdas con número son aristas ponderadas.
- **Lista** abre la lista de adyacencia. Desde cualquiera de las dos ventanas se puede saltar a la otra.

### 6. Cambiar la estructura de datos
En *Sistema de Grafos* elige **Estructura** en el desplegable. El grafo actual se copia a la nueva implementación.

### 7. Vaciar el grafo
**Vaciar** elimina todos los vértices y aristas, previa confirmación.

---

## Estructura de carpetas

```
Ruta-de-mapas-Grafos--master/
├── .gitattributes                 Atributos de Git (fin de línea, etc.)
├── .gitignore                     Ignora bin/, obj/, .vs/ y otros artefactos
├── Ruta de mapas.slnx             Solución que incluye el proyecto principal
└── Ruta de mapas/
    ├── Ruta de mapas.csproj       Proyecto WinExe, net10.0-windows, WinForms
    ├── Program.cs                 Punto de entrada (Main, STAThread)
    ├── TraversalAlgorithms.cs     Algoritmos BFS y DFS (clase "TravesalAlgorithms")
    ├── TraversalResult.cs         Resultado de un recorrido (orden, distancias, no alcanzados)
    ├── Configuration/
    │   ├── LogCategories.cs       Categorías de la bitácora
    │   ├── Messages.cs            Mensajes de texto del sistema (en español)
    │   └── VisualConfig.cs        Colores, grosores y constantes de dibujo
    ├── Controls/
    │   └── GraphCanvasPanel.cs    Panel con doble búfer para dibujar sin parpadeo
    ├── Forms/
    │   ├── GraphForm.cs / .Designer.cs / .resx          Ventana principal
    │   ├── AdjacencyMatrixForm.cs / .Designer.cs / .resx Ventana de matriz de adyacencia
    │   └── AdjacencyListForm.cs / .Designer.cs           Ventana de lista de adyacencia
    ├── Graphs/
    │   ├── BaseGraph.cs           Clase abstracta: contrato común de los grafos
    │   ├── SimpleListGraph.cs     Implementación con lista simple propia
    │   ├── LinkedListGraph.cs     Implementación con LinkedList<T> de .NET
    │   └── ListGraph.cs           Implementación con List<T> de .NET
    ├── Models/
    │   ├── Vertex.cs              Vértice: nombre y coordenadas
    │   ├── Edge.cs                Arista: origen, destino, peso opcional
    │   ├── AdjacentElement.cs     Vecino con información de peso
    │   └── AdjacencyListEntry.cs  Entrada de la lista de adyacencia
    └── Structures/
        ├── SimpleList.cs          Lista enlazada simple genérica propia
        └── SimpleListNode.cs      Nodo de SimpleList<T>
```

---

## Observaciones conocidas

Estos puntos se detallan en el documento técnico PDF. Resumen:

- La lógica de los tres grafos está **duplicada** en `Graphs/` (unas 1.300 líneas con reglas casi idénticas), lo que aumenta el riesgo de que una corrección se aplique sólo en una implementación.
- La clase de recorridos se llama `TravesalAlgorithms` (errata: falta la *r*) dentro de `TraversalAlgorithms.cs`.
- Hay código sin uso: el método `GenerateAdjacencyMatrix` (matriz de enteros) y varios colores de `VisualConfig.cs` y de `AdjacencyMatrixForm.cs`.
- Cambiar de no dirigido a dirigido no reinterpreta las aristas existentes, y el cambio ocurre en silencio.
- En la matriz, una arista ponderada de peso 1 se muestra igual que una arista no ponderada.
- Parte de la interfaz de recorridos está en inglés, mientras que el resto de la aplicación está en español.
