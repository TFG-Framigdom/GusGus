using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class MazeALG : MonoBehaviour
{
    int n = 8;
    int m = 8;
    int[] numbers = new int[] {0, 1, 4, 3, 21, 22};

    int[,] matriz;
    System.Random random = new System.Random();
    
    void Start()
    {
        matriz = new int[n, m];
        GenerarMatriz();
        string matrizString = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrizString += matriz[i, j] + ",";
            }
            matrizString += "\n";
        }
        Debug.Log(matrizString);
    }
    
    // Generar números aleatorios en la matriz
    void GenerarMatriz()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i == 0 && j == 0)
                {
                    // El primer número de la matriz siempre es 0
                    matriz[i, j] = 0;
                }
                else if (i == n - 1 && j == m - 1)
                {
                    // El último número de la matriz siempre es 0
                    matriz[i, j] = 0;
                }
                else
                {
                    int randomNum = random.Next(0, 2);
                    matriz[i, j] = numbers[randomNum];
                    if (randomNum == 2 || randomNum == 3 || randomNum == 4 || randomNum == 5)
                    {
                        // Eliminar el número usado de la lista de números disponibles
                        numbers[randomNum] = numbers[numbers.Length - 1];
                        Array.Resize(ref numbers, numbers.Length - 1);
                    }
                }
            }
        }

        // Crear el camino de 4 a 3 lleno de 0
        int startX = -1;
        int startY = -1;
        int endX = -1;
        int endY = -1;

        // Buscar el número 4 y 3 en la matriz y guardar sus posiciones
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matriz[i, j] == 4)
                {
                    startX = i;
                    startY = j;
                }
                if (matriz[i, j] == 3)
                {
                    endX = i;
                    endY = j;
                }
            }
        }

        // Crear el camino lleno de 0 desde 4 a 3
        int x = startX;
        int y = startY;
        while (x != endX || y != endY)
        {
            matriz[x, y] = 0;
            if (x < endX)
            {
                x++;
            }
            else if (x > endX)
            {
                x--;
            }
            else if (y < endY)
            {
                y++;
            }
            else if (y > endY)
            {
                y--;
            }
        }
    }

}


