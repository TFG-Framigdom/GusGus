
[System.Serializable]
public class MazeSettings
{
    public int[] Tamano;
    public int Tiempo;
    public int[] Laberinto;
    public int[] LaberintoLevel2;  

    //Convierte el array de 1D a 2D
    public int[,] Convert2DArray(int[] laberinto)
    {
        int[,] maze = new int[Tamano[0],Tamano[1]];

        for (int filas = 0; filas < maze.GetLength(0); filas++)
        {
            for (int col = 0; col < maze.GetLength(1); col++)
            {
                maze[filas,col] = laberinto[filas * maze.GetLength(1) + col];
            }
        }
        
        return maze;
    }

    
    public int[,] CheckMazeBorders(int[] laberinto)
    {
        int [,] maze = Convert2DArray(laberinto);
        int numRows = maze.GetLength(0);
        int numCols = maze.GetLength(1);
        bool hasExit = false;
        for (int i = 0; i < numRows; i++)
        {
            if (maze[i, 0] != 1)
            {
                if(maze[i, 0] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    maze[i, 0] = 1;
                }
            }
            if(maze[i, numCols - 1] != 1)
            {
                if(maze[i, numCols - 1] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    maze[i, numCols - 1] = 1;
                }
            }
        }
        for (int j = 0; j < numCols; j++)
        {
            if (maze[0, j] != 1)
            {
                if(maze[0, j] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    maze[0, j] = 1;
                }

            }
            if (maze[numRows - 1, j] != 1)
            {
                if(maze[numRows - 1, j] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    maze[numRows - 1, j] = 1;
                }

            }
        }
        if(!hasExit){
            maze[0, 1] = 3;
        }
        return maze;
    }


}
