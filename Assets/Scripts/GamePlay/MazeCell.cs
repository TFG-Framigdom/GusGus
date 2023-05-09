using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell 
{
  
    public Cell[,] cells;

    private int n = 3;

    public MazeCell(int x, int y)
    {
        cells = new Cell[n, n];
        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                cells[i, j] = new Cell(x * n + i, y * n + j); 
            }
        }

    }

    public Cell GetCell(int x, int y)
    {
        return new Cell(x,y);
    }


    public void SetCellValue(int value)
    {
        Cell celdaZero = cells[n / 2, n / 2];
        celdaZero.value = value;
        celdaZero.visited = true;
    }
}
