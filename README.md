Ruta de mapas – Grafos

Aplicación de escritorio en C# / Windows Forms para crear, visualizar y analizar grafos. El usuario coloca vértices en un lienzo, los conecta con aristas (dirigidas o no dirigidas, con o sin peso) y consulta la estructura mediante la matriz de adyacencia, la lista de adyacencia y los recorridos BFS y DFS.

Tecnologías: .NET 10 (net10.0-windows), Windows Forms, GDI+. No usa paquetes externos.

Estructura del proyecto
Ruta-de-mapas-Grafos--master/
├── Ruta de mapas.slnx             Solución
└── Ruta de mapas/
    ├── Program.cs                 Punto de entrada: abre GraphForm
    ├── TraversalAlgorithms.cs     BFS y DFS (clase TravesalAlgorithms)
    ├── TraversalResult.cs         Resultado de un recorrido
    ├── Forms/                     Interfaz: ventana principal y ventanas de matriz y lista
    ├── Controls/                  GraphCanvasPanel (lienzo con doble búfer)
    ├── Graphs/                    Núcleo: BaseGraph y tres implementaciones
    ├── Models/                    Vertex, Edge, AdjacentElement, AdjacencyListEntry
    ├── Structures/                SimpleList<T> y SimpleListNode<T> (estructuras propias)
    └── Configuration/             Mensajes, colores y categorías de la bitácora
Estructura lógica
Capa de interfaz (Forms/, Controls/): GraphForm captura los eventos, dibuja el lienzo y coordina las operaciones. Las ventanas de matriz y lista sólo muestran datos.
Núcleo de grafos (Graphs/): BaseGraph es una clase abstracta que define el contrato (alta y baja de vértices y aristas, adyacencia, búsqueda, matrices y listas). Cada implementación guarda los datos en una estructura distinta:
SimpleListGraph: lista enlazada propia (SimpleList<T>).
LinkedListGraph: LinkedList<T> de .NET.
ListGraph: List<T> de .NET.
La interfaz puede cambiar de implementación en tiempo de ejecución y copia el grafo a la nueva estructura.
Algoritmos (TraversalAlgorithms.cs): BFS usa una cola y calcula distancias mínimas. DFS es iterativo y usa una pila. Ambos construyen primero una lista de adyacencia indexada, con complejidad O(V + E), y sólo leen el grafo a través de BaseGraph.
Modelo (Models/): Vertex tiene nombre y coordenadas. Edge tiene origen, destino y peso opcional (nulo si no es ponderada). Los nombres de vértice no distinguen mayúsculas.
Reglas principales
Vértices: el nombre no puede estar vacío ni repetirse, sin importar mayúsculas.
Aristas: no se permiten bucles ni duplicados. En grafos no dirigidos, A–B y B–A cuentan como la misma arista.
Ponderación: las aristas ponderadas requieren un peso. En la interfaz el peso va de 1 a 9999.
Eliminación de vértice: se eliminan también todas sus aristas conectadas.
Recorridos: BFS y DFS empiezan en el origen elegido. Los vértices no alcanzables se reportan aparte.
Flujo principal
Program.Main abre GraphForm con la estructura Lista Simple Propia.
El usuario agrega vértices (con clic en el lienzo o desde el panel) y aristas.
Cada operación delega en la implementación activa de BaseGraph, que valida y devuelve un mensaje.
La ventana actualiza los desplegables, la bitácora y el lienzo.
Los recorridos llaman a TravesalAlgorithms y dibujan el orden de visita sobre los vértices.
