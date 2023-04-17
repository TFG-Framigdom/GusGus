using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    int [,] maze;
    int n = 8;
    
    List<Vector2Int> stack = new List<Vector2Int>();
    Cell[,] cells;

    void Start(){
        cells = new Cell[n, n];

        GenerarAlg();
        RandomizedDepthFirstSearch();
        ImprimirMaze();
    }

    void ImprimirMaze()
    {
        string matrizString = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrizString += cells[i, j].value + ",";
            }
            matrizString += "\n";
        }
        Debug.Log(matrizString);
    }

    void GenerarAlg(){
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cells[i, j] = new Cell(i, j);

            }
        }

        int CellRandomx = UnityEngine.Random.Range(0, n);
        int CellRandomy = UnityEngine.Random.Range(0, n);

        Vector2Int CellRandom = new Vector2Int(CellRandomx, CellRandomy);
        stack.Add(CellRandom);
        cells[CellRandomx, CellRandomy].value = 0;

        //Cell cell = cells.Find(c => c.x == CellRandomx && c.y == CellRandomy);
        Cell cell = cells[CellRandomx, CellRandomy];
        cell.visited = true;
        

    }

    void RandomizedDepthFirstSearch(){
        while(stack.Count > 0){
            Vector2Int currentCell = stack[stack.Count - 1];
            bool isValidDirection = false;
            int checkWays = 0;

            while(!isValidDirection && checkWays < 5){
                checkWays++;
                int randonDirection = UnityEngine.Random.Range(0, 4);
                switch(randonDirection){
                    //West
                    case 0:
                        if(currentCell.x >0){
                            //Cell westCell = cells.Find(c => c.x == currentCell.x - 1 && c.y == currentCell.y);
                            Cell westCell = cells[currentCell.x - 1, currentCell.y];
                            if(!westCell.visited){
                                cells[currentCell.x, currentCell.y].value = 0;
                                cells[currentCell.x - 1, currentCell.y].value = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x - 1, (int)currentCell.y] = 0;
                                stack.Add(new Vector2Int(currentCell.x - 1, currentCell.y));
    
                                westCell.visited = true;
                                isValidDirection = true;

                                cells[currentCell.x, currentCell.y].westCell = false;


                                NextCell(cells[currentCell.x,currentCell.y]);

                            }
                        }
                        break;
                    //East
                    case 1:
                        if(currentCell.x < n - 1){
                            //Cell eastCell = cells.Find(c => c.x == currentCell.x + 1 && c.y == currentCell.y);
                            Cell eastCell = cells[currentCell.x + 1, currentCell.y];
                            if(!eastCell.visited){
                                cells[currentCell.x, currentCell.y].value = 0;
                                cells[currentCell.x + 1, currentCell.y].value = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x + 1, (int)currentCell.y] = 0;
                                
                                stack.Add(new Vector2Int(currentCell.x + 1, currentCell.y));
                                eastCell.visited = true;
                                isValidDirection = true;

                                cells[currentCell.x, currentCell.y].eastCell = false;

                                NextCell(cells[currentCell.x,currentCell.y]);
                            }
                        }
                        break;
                    //South
                    case 2:
                        if(currentCell.y > 0){
                            //Cell northCell = cells.Find(c => c.x == currentCell.x && c.y == currentCell.y - 1);
                            Cell northCell = cells[currentCell.x, currentCell.y - 1];
                            if(!northCell.visited){
                                cells[currentCell.x, currentCell.y].value = 0;
                                cells[currentCell.x, currentCell.y - 1].value = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y - 1] = 0;
                                
                                stack.Add(new Vector2Int(currentCell.x, currentCell.y - 1));
                                northCell.visited = true;
                                isValidDirection = true;

                                cells[currentCell.x, currentCell.y].southCell = false;


                                NextCell(cells[currentCell.x,currentCell.y]);
                            }
                        }
                        break;
                    //North
                    case 3:
                        if(currentCell.y < n - 1){
                            //Cell southCell = cells.Find(c => c.x == currentCell.x && c.y == currentCell.y + 1);
                            Cell southCell = cells[currentCell.x, currentCell.y + 1];
                            if(!southCell.visited){
                                
                                cells[currentCell.x, currentCell.y].value = 0;
                                cells[currentCell.x, currentCell.y + 1].value = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y] = 0;
                                //maze[(int)currentCell.x, (int)currentCell.y + 1] = 0;
                                
                                stack.Add(new Vector2Int(currentCell.x, currentCell.y + 1));
                                southCell.visited = true;
                                isValidDirection = true;

                                cells[currentCell.x, currentCell.y].northCell = false;


                                NextCell(cells[currentCell.x,currentCell.y]);
                            }
                        }
                        break;

                }
            }

            if(!isValidDirection){
                stack.RemoveAt(stack.Count - 1);
            }

        }
    }


    public void NextCell(Cell cell){
        if(cell.westCell){
            cells[cell.x - 1, cell.y].value = 1;
        }
        if(cell.eastCell){
            cells[cell.x + 1, cell.y].value = 1;
        }
        if(cell.southCell){
            cells[cell.x, cell.y - 1].value = 1;
        }
        if(cell.northCell){
            cells[cell.x, cell.y + 1].value = 1;
        }
    }
}
