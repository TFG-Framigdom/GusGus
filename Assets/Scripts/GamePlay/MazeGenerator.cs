using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    int nSize = 4;
    
    List<Vector2Int> stack = new List<Vector2Int>();
    MazeCell[,] cells;


    [SerializeField] MazeAleatorioSO mazeAleatorio;


    void Start(){
        cells = new MazeCell[nSize, nSize];

        GenerarAlg();
        RandomizedDepthFirstSearch();
        ImprimirMaze();
    }

    void ImprimirMaze()
    {
        List<int> maze = new List<int>();
        string matrizString = "";
        for (int i = 0; i < nSize*3; i++)
        {
            for (int j = 0; j < nSize*3; j++)
            {
                matrizString += cells[i/3, j/3].cells[i%3, j%3].value + ",";
                maze.Add(cells[i / 3, j / 3].cells[i % 3, j % 3].value);
            }
            matrizString += "\n";
        }

        mazeAleatorio.laberintoAleatorio = maze;
        


        Debug.Log(matrizString);
    }

    void GenerarAlg(){
        for (int i = 0; i < nSize; i++)
        {
            for (int j = 0; j < nSize; j++)
            {
                MazeCell mazecell = new MazeCell(i,j);
                //mazecell = new Cell(i*3,j*3);
                //cells[i, j] = new Cell(i, j);
                cells[i, j] = mazecell;


            }
            
        }

        int CellRandomx = UnityEngine.Random.Range(1, nSize);
        int CellRandomy = UnityEngine.Random.Range(1, nSize);

        Vector2Int CellRandom = new Vector2Int(CellRandomx, CellRandomy);
        stack.Add(CellRandom);

        cells[CellRandomx, CellRandomy].SetCellValue(0);

        //Cell cell = cells.Find(c => c.x == CellRandomx && c.y == CellRandomy);
        //Cell cell = cells[CellRandomx, CellRandomy];
        

    }

    void RandomizedDepthFirstSearch()
    {
        int n = 3;
        int limit = 0;

        while (stack.Count > 0 && limit<25)
        {
            limit++;
            Vector2Int currentCell = stack[stack.Count - 1];
            int checkWays = 0;
            bool isValidDirection = false;


            while (!isValidDirection && checkWays < 5)
            {
                checkWays++;
                isValidDirection = false;
                int randonDirection = UnityEngine.Random.Range(0, 4);
                switch (randonDirection)
                {
                   //West
                   case 0:
                       if (currentCell.x > 0)
                       {
                           //Cell westCell = cells.Find(c => c.x == currentCell.x - 1 && c.y == currentCell.y);
                           MazeCell westCell = cells[currentCell.x - 1, currentCell.y];
                           MazeCell currentMazeCell = cells[currentCell.x, currentCell.y];
                           //MazeCell westCellWay = cells[currentCell.x - 2, currentCell.y];
                           if (!westCell.cells[n-1, n/2].visited)
                           {

                                westCell.cells[n-1 , n/2].value = 0;
                                westCell.cells[n/2 , n/2].value = 0;
                                currentMazeCell.cells[0 , n/2].value = 0;
                                currentMazeCell.cells[0, n / 2].visited = true;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x - 1, (int)currentCell.y] = 0;
                                stack.Add(new Vector2Int(currentCell.x - 1, currentCell.y));

                               westCell.cells[n - 1, n / 2].visited = true;
                                
                               isValidDirection = true;

                               //cells[currentCell.x, currentCell.y].westCell = false;
                               currentMazeCell.cells[0, n / 2].westCell = false;



                               //NextCell(westCell);

                           }
                       }
                       break;
                   //East
                   case 1:
                       if (currentCell.x < nSize - 1)
                       {
                           //Cell eastCell = cells.Find(c => c.x == currentCell.x + 1 && c.y == currentCell.y);
                            MazeCell eastCell = cells[currentCell.x + 1, currentCell.y];
                            MazeCell currentMazeCell = cells[currentCell.x, currentCell.y];
                           if (!eastCell.cells[0, n / 2].visited)
                           {
                                eastCell.cells[0, n / 2].value = 0;
                                eastCell.cells[n / 2, n / 2].value = 0;
                                currentMazeCell.cells[n - 1, n / 2].value = 0;
                                currentMazeCell.cells[n - 1, n / 2].visited = true;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x + 1, (int)currentCell.y] = 0;

                                stack.Add(new Vector2Int(currentCell.x + 1, currentCell.y));
                                eastCell.cells[0, n/2].visited = true;
                                isValidDirection = true;

                               //cells[currentCell.x, currentCell.y].eastCell = false;
                                currentMazeCell.cells[n - 1, n / 2].eastCell = false;
                                
                                //NextCell(eastCell);
                           }
                       }
                       break;
                   //South
                   case 2:
                       if (currentCell.y > 0)
                       {
                           //Cell northCell = cells.Find(c => c.x == currentCell.x && c.y == currentCell.y - 1);
                           //Cell northCell = cells[currentCell.x, currentCell.y - 1];
                            MazeCell southCell = cells[currentCell.x, currentCell.y - 1];
                            MazeCell currentMazeCell = cells[currentCell.x, currentCell.y];

                           if (!southCell.cells[n / 2, n-1].visited)
                           {
                                southCell.cells[n / 2, n - 1].value = 0;
                                southCell.cells[n / 2, n / 2].value = 0;
                                currentMazeCell.cells[n / 2, 0].value = 0;
                                currentMazeCell.cells[n / 2, 0].visited = true;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y - 1] = 0;

                                stack.Add(new Vector2Int(currentCell.x, currentCell.y - 1));
                                southCell.cells[n/2,0].visited = true;
                                isValidDirection = true;

                               //cells[currentCell.x, currentCell.y].southCell = false;
                                currentMazeCell.cells[n / 2, 0].southCell = false;


                               //NextCell(southCell);
                           }
                       }
                       break;
                   //North
                   case 3:
                       if (currentCell.y < nSize - 1)
                       {
                           //Cell southCell = cells.Find(c => c.x == currentCell.x && c.y == currentCell.y + 1);
                           //Cell southCell = cells[currentCell.x, currentCell.y + 1];
                            MazeCell northCell = cells[currentCell.x, currentCell.y + 1];
                            MazeCell currentMazeCell = cells[currentCell.x, currentCell.y];
                           if (!northCell.cells[n / 2, 0].visited)
                           {
                                northCell.cells[n / 2, n - 1].value = 0;
                                northCell.cells[n / 2, n / 2].value = 0;
                                currentMazeCell.cells[n / 2, n - 1].value = 0;
                                currentMazeCell.cells[n / 2, n - 1].visited = true;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y + 1] = 0;

                                stack.Add(new Vector2Int(currentCell.x, currentCell.y + 1));
                                northCell.cells[n /2, n-1].visited = true;
                                isValidDirection = true;

                               //cells[currentCell.x, currentCell.y].northCell = false;
                                currentMazeCell.cells[n / 2, n - 1].northCell = false;

                               //NextCell(northCell);
                           }
                       }
                       break;

               }
           }

           if (!isValidDirection)
           {
               stack.RemoveAt(stack.Count - 1);
           }
           
       }

    }


    public void NextCell(MazeCell mazecell){
        int n = 3;
        if(mazecell.cells[n-1 , n / 2].westCell){
            mazecell.cells[n -1 , n / 2].value = 1;
            mazecell.cells[n -1 , 0].value = 1;
            mazecell.cells[n -1 , n -1].value = 1;
        }
        if(mazecell.cells[0, n / 2].eastCell){
            mazecell.cells[0, n / 2].value = 1;
            mazecell.cells[0, 0].value = 1;
            mazecell.cells[0, n -1].value = 1;
        }
        if(mazecell.cells[n / 2, 0].southCell){
            mazecell.cells[n / 2, 0].value = 1;
            mazecell.cells[n-1,0].value = 1;
            mazecell.cells[0, 0].value = 1;
        }
        if(mazecell.cells[n / 2, n-1].northCell){
            mazecell.cells[0, n-1].value = 1;
            mazecell.cells[n / 2 - 1,n-1].value = 1;
            mazecell.cells[n -1, n-1].value = 1;
        }
    }
}
