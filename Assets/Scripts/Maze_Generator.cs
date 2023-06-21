using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;
using System;

public class Maze_Generator
{
    private Stack<Node> stack;
    private System.Random rand;
    private int[,] maze;
    private int dimension;

    public Maze_Generator(int dim)
    {
        maze = new int[dim, dim];
        dimension = dim;
        stack = new Stack<Node>();
        rand = new System.Random();
    }

    public int[,] GenerateMaze()
    {
        stack.Clear(); // Reiniciar la pila antes de generar el laberinto
        maze = new int[dimension, dimension]; // Reiniciar el laberinto antes de generar uno nuevo

        stack.Push(new Node(0, 0));
        while (stack.Count > 0)
        {
            Node next = stack.Pop();
            if (ValidNextNode(next))
            {
                maze[next.y, next.x] = 1;
                List<Node> neighbors = FindNeighbors(next);
                RandomlyAddNodesToStack(neighbors);
            }
            else
            {
                maze[next.y, next.x] = 0; // Cambiar el valor a 0 para tener caminos cerrados
            }
        }

        // Colocar al jugador en la esquina inferior derecha o en su diagonal
        int playerX = dimension - 2;
        int playerY = dimension - 2;
        maze[playerY, playerX] = 4; // Colocar al jugador en la posición determinada
        PlaceItemsRandomly(); // Colocar items aleatoriamente en el laberinto
        PlacePointsRandomly(); // Colocar puntos aleatoriamente en el laberinto

        return maze;
    }

    public void PlacePointsRandomly()
    {
        int contadorItems = 0;
        int numItems = rand.Next(1, 5); // Colocar entre 1 y 4 items
        while (contadorItems < numItems)
        {
            int x = rand.Next(1, dimension - 1);
            int y = rand.Next(1, dimension - 1);
            if (maze[y, x] == 0 && IsPositionValidForItem(x, y)) // Verificar si la posición es un camino y es válida para el item
            {
                maze[y, x] = 23; // Colocar un item en la posición determinada
                contadorItems++;
            }
        }

    }


    public void PlaceItemsRandomly()
    {
        int maxItems = 2; // Número máximo de items que se pueden colocar (uno de vida y uno de tiempo)
        int itemsPlaced = 0; // Contador de items colocados

        while (itemsPlaced < maxItems)
        {
            int randomX = rand.Next(1, dimension - 1); // Generar una posición aleatoria en el rango permitido
            int randomY = rand.Next(1, dimension - 1);

            if (maze[randomY, randomX] == 0 && IsPositionValidForItem(randomX, randomY)) // Verificar si la posición es un camino y es válida para el item
            {
                if (itemsPlaced == 0)
                {
                    maze[randomY, randomX] = 21; // Colocar item de vida
                }
                else if (itemsPlaced == 1)
                {
                    maze[randomY, randomX] = 22; // Colocar item de tiempo
                }

                itemsPlaced++;
            }
        }
    }

    private bool IsPositionValidForItem(int x, int y)
    {
        // Verificar si la posición está dentro de los bordes del laberinto
        if (x == 0 || x == dimension - 1 || y == 0 || y == dimension - 1)
        {
            return false;
        }

        // Verificar si la posición vecina está ocupada por una pared (valor 1)
        if (maze[y - 1, x] == 1 || maze[y + 1, x] == 1 || maze[y, x - 1] == 1 || maze[y, x + 1] == 1)
        {
            return false;
        }

        return true;
    }


    public string GetSymbolicMaze()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                sb.Append(maze[i, j] == 1 ? "1 " : "0 ");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    private bool ValidNextNode(Node node)
    {
        int numNeighboringOnes = 0;
        for (int y = node.y - 2; y <= node.y + 2; y += 2)
        {
            if (PointOnGrid(node.x, y) && maze[y, node.x] == 1)
            {
                numNeighboringOnes++;
            }
        }
        for (int x = node.x - 2; x <= node.x + 2; x += 2)
        {
            if (PointOnGrid(x, node.y) && maze[node.y, x] == 1)
            {
                numNeighboringOnes++;
            }
        }
        return numNeighboringOnes < 2 && maze[node.y, node.x] != 1;
    }

    private void RandomlyAddNodesToStack(List<Node> nodes)
    {
        while (nodes.Count > 0)
        {
            int targetIndex = rand.Next(nodes.Count);
            stack.Push(nodes[targetIndex]);
            nodes.RemoveAt(targetIndex);
        }
    }

    private List<Node> FindNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        int[] directions = { -2, 0, 2, 0, 0, -2, 0, 2 }; // Left, Right, Up, Down
        for (int i = 0; i < directions.Length; i += 2)
        {
            int x = node.x + directions[i];
            int y = node.y + directions[i + 1];
            if (PointOnGrid(x, y) && maze[y, x] != 1)
            {
                neighbors.Add(new Node(x, y));
            }
        }
        return neighbors;
    }

    private bool PointOnGrid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < dimension && y < dimension;
    }

    public int[,] PlaceEnemiesRandomlyLevel1(int[,] maze)
    {
        int numEnemies = 2; // Número de enemigos a colocar
        int enemiesPlaced = 0; // Contador de enemigos colocados

        while (enemiesPlaced < numEnemies)
        {
            int randomX = rand.Next(1, dimension - 1); // Generar una posición aleatoria en el rango permitido
            int randomY = rand.Next(1, dimension - 1);

            if (maze[randomY, randomX] == 0 && IsPositionFarFromPlayer(randomX, randomY)) // Verificar si la posición es un camino, es válida para el enemigo y está lejos del jugador
            {
                maze[randomY, randomX] = 52; // Colocar enemigo
                enemiesPlaced++;
            }
        }

        return maze;
    }

    public int[,] PlaceEnemiesRandomlyLevel2(int[,] maze)
    {
        int numEnemies = 3; // Número de enemigos a colocar
        int enemiesPlaced = 0; // Contador de enemigos colocados

        while (enemiesPlaced < numEnemies)
        {
            int randomX = rand.Next(1, dimension - 1); // Generar una posición aleatoria en el rango permitido
            int randomY = rand.Next(1, dimension - 1);

            if (maze[randomY, randomX] == 0 && IsPositionFarFromPlayer(randomX, randomY)) // Verificar si la posición es un camino, es válida para el enemigo y está lejos del jugador
            {
                maze[randomY, randomX] = 52; // Colocar enemigo
                enemiesPlaced++;
            }
        }

        return maze;
    }

    public int[,] PlaceEnemiesRandomlyLevel3(int[,] maze)
    {
        int numEnemies = rand.Next(3, 5); // Colocar entre 3 y 4 enemigos
        int enemiesPlaced = 0; // Contador de enemigos colocados

        while (enemiesPlaced < numEnemies)
        {
            int randomX = rand.Next(1, dimension - 1); // Generar una posición aleatoria en el rango permitido
            int randomY = rand.Next(1, dimension - 1);

            if (maze[randomY, randomX] == 0 && IsPositionFarFromPlayer(randomX, randomY)) // Verificar si la posición es un camino, es válida para el enemigo y está lejos del jugador
            {
                maze[randomY, randomX] = 52; // Colocar enemigo
                enemiesPlaced++;
            }
        }

        return maze;
    }


    private bool IsPositionFarFromPlayer(int x, int y)
    {
        int playerX = dimension - 2; // Posición X del jugador
        int playerY = dimension - 2; // Posición Y del jugador

        // Calcular la distancia entre la posición del enemigo y el jugador
        int distanceX = Math.Abs(x - playerX);
        int distanceY = Math.Abs(y - playerY);
        int distance = Math.Max(distanceX, distanceY);

        return distance >= 5; // Verificar si la distancia es mayor o igual a 5 casillas
    }
}

public class Node
{
    public int x;
    public int y;

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

