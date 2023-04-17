using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class MazeALG : MonoBehaviour
{
    int n = 8;
    int[] numbers = new int[] {0, 1, 4, 3, 21, 22};

    int[,] matriz;
    System.Random random = new System.Random();

    int iInicio = 0;
    int jInicio = 0;

    
    void Start()
    {
        matriz = new int[n, n];
        GenerarAlg();
        ColocarInicioPrueba();
        ColocarSalidaPrueba(iInicio, jInicio);
        ImprimirMatriz();
    }

    void ImprimirMatriz()
    {
        string matrizString = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrizString += matriz[i, j] + ",";
            }
            matrizString += "\n";
        }
        Debug.Log(matrizString);
    }
    
    // Generar números aleatorios en la matriz
    // void GenerarMatriz()
    // {
    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < m; j++)
    //         {
    //             if (i == 0 && j == 0)
    //             {
    //                 // El primer número de la matriz siempre es 0
    //                 matriz[i, j] = 0;
    //             }
    //             else if (i == n - 1 && j == m - 1)
    //             {
    //                 // El último número de la matriz siempre es 0
    //                 matriz[i, j] = 0;
    //             }
    //             else
    //             {
    //                 int randomNum = random.Next(0, 2);
    //                 matriz[i, j] = numbers[randomNum];
    //                 if (randomNum == 2 || randomNum == 3 || randomNum == 4 || randomNum == 5)
    //                 {
    //                     // Eliminar el número usado de la lista de números disponibles
    //                     numbers[randomNum] = numbers[numbers.Length - 1];
    //                     Array.Resize(ref numbers, numbers.Length - 1);
    //                 }
    //             }
    //         }
    //     }

    //     // Crear el camino de 4 a 3 lleno de 0
    //     int startX = -1;
    //     int startY = -1;
    //     int endX = -1;
    //     int endY = -1;

    //     // Buscar el número 4 y 3 en la matriz y guardar sus posiciones
    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < m; j++)
    //         {
    //             if (matriz[i, j] == 4)
    //             {
    //                 startX = i;
    //                 startY = j;
    //             }
    //             if (matriz[i, j] == 3)
    //             {
    //                 endX = i;
    //                 endY = j;
    //             }
    //         }
    //     }

    //     // Crear el camino lleno de 0 desde 4 a 3
    //     int x = startX;
    //     int y = startY;
    //     while (x != endX || y != endY)
    //     {
    //         matriz[x, y] = 0;
    //         if (x < endX)
    //         {
    //             x++;
    //         }
    //         else if (x > endX)
    //         {
    //             x--;
    //         }
    //         else if (y < endY)
    //         {
    //             y++;
    //         }
    //         else if (y > endY)
    //         {
    //             y--;
    //         }
    //     }
    // }


    void GenerarAlg(){
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matriz[i, j] = UnityEngine.Random.Range(0, 2);
            }
        }
    }

    // private void ColocarSalida()
    // {
    //     int borde = UnityEngine.Random.Range(0, 4); // elegir un borde al azar

    //     switch (borde)
    //     {
    //         case 0: // borde superior
    //             int j0 = UnityEngine.Random.Range(0, n); // elegir columna al azar
    //             matriz[0, j0] = 3; // colocar salida en fila 0, columna j0
    //             break;

    //         case 1: // borde inferior
    //             int j1 = UnityEngine.Random.Range(0, n); // elegir columna al azar
    //             matriz[n-1, j1] = 3; // colocar salida en fila n-1, columna j1
    //             break;

    //         case 2: // borde izquierdo
    //             int i0 = UnityEngine.Random.Range(0, n); // elegir fila al azar
    //             matriz[i0, 0] = 3; // colocar salida en fila i0, columna 0
    //             break;

    //         case 3: // borde derecho
    //             int i1 = UnityEngine.Random.Range(0, n); // elegir fila al azar
    //             matriz[i1, n-1] = 3; // colocar salida en fila i1, columna n-1
    //             break;
    //     }
    // }

    // void ColocarInicio()
    // {
    //     int[,] distancias = new int[n, n];

    //     int salida_i= 0 ;
    //     int salida_j = 0 ;


    //     // calcular distancias de Manhattan desde cada posición hasta la salida
    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < n; j++)
    //         {
    //             if (matriz[i, j] == 3)
    //             {
    //                 salida_i = i;
    //                 salida_j = j;
    //                 // si la posición es la salida, la distancia es 0
    //                 distancias[i, j] = 0;
    //             }
    //             else
    //             {
    //                 salida_i = i;
    //                 salida_j = j;
    //                 // calcular distancia de Manhattan desde la posición a la salida
    //                 distancias[i, j] = Mathf.Abs(i - salida_i ) + Mathf.Abs(j - salida_j);
    //             }
    //         }
    //     }

    //     // encontrar la posición con la distancia de Manhattan máxima
    //     int maxDistancia = 0;
    //     int iInicio = 0;
    //     int jInicio = 0;

    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < n; j++)
    //         {
    //             if (matriz[i, j] == 0 && distancias[i, j] > maxDistancia)
    //             {
    //                 maxDistancia = distancias[i, j];
    //                 iInicio = i;
    //                 jInicio = j;
    //             }
    //         }
    //     }

    //     matriz[iInicio, jInicio] = 4; // colocar inicio en posición con distancia de Manhattan máxima
    // }

    






    void ColocarInicioPrueba()
    {
        iInicio = UnityEngine.Random.Range(1, n-1);
        jInicio = UnityEngine.Random.Range(1, n-1);
        // mientras la posición aleatoria esté en los bordes, seguir seleccionando una nueva posición
        while (iInicio == 0 || iInicio == n-1 || jInicio == 0 || jInicio == n-1)
        {
            iInicio = UnityEngine.Random.Range(1, n-1);
            jInicio = UnityEngine.Random.Range(1, n-1);
        }
        Debug.Log("He salido del while");
        // seleccionar una posición aleatoria dentro de la matriz que no esté en los bordes

        matriz[iInicio, jInicio] = 4; // colocar inicio en posición aleatoria dentro de la matriz

    }

    void ColocarSalidaPrueba(int iInicio, int jInicio)
    {
        int maxDistancia = -1; // inicializar con un valor negativo para que cualquier distancia sea mayor
        int iSalida = 0;
        int jSalida = 0;

        // recorrer el borde superior de la matriz (excepto las esquinas)
        for (int j = 1; j < n-1; j++) {
            int distancia = Mathf.Abs(iInicio - 0) + Mathf.Abs(jInicio - j); // distancia Manhattan
            if (distancia > maxDistancia) {
                maxDistancia = distancia;
                iSalida = 0;
                jSalida = j;
            }
        }

        // recorrer el borde derecho de la matriz (excepto las esquinas)
        for (int i = 1; i < n-1; i++) {
            int distancia = Mathf.Abs(iInicio - i) + Mathf.Abs(jInicio - (n-1)); // distancia Manhattan
            if (distancia > maxDistancia) {
                maxDistancia = distancia;
                iSalida = i;
                jSalida = n-1;
            }
        }

        // recorrer el borde inferior de la matriz (excepto las esquinas)
        for (int j = 1; j < n-1; j++) {
            int distancia = Mathf.Abs(iInicio - (n-1)) + Mathf.Abs(jInicio - j); // distancia Manhattan
            if (distancia > maxDistancia) {
                maxDistancia = distancia;
                iSalida = n-1;
                jSalida = j;
            }
        }

        // recorrer el borde izquierdo de la matriz (excepto las esquinas)
        for (int i = 1; i < n-1; i++) {
            int distancia = Mathf.Abs(iInicio - i) + Mathf.Abs(jInicio - 0); // distancia Manhattan
            if (distancia > maxDistancia) {
                maxDistancia = distancia;
                iSalida = i;
                jSalida = 0;
            }
        }

        // colocar la salida en la posición más alejada
        matriz[iSalida, jSalida] = 3;

    }

}


