
[System.Serializable]
public class MazeSettings
{
    public int[] Tamano;
    public int Tiempo;
    public int[] Laberinto;   

    //Convierte el array de 1D a 2D
    public int[,] Convert2DArray()
    {
        int[,] maze = new int[Tamano[0],Tamano[1]];

        for (int filas = 0; filas < maze.GetLength(0); filas++)
        {
            for (int col = 0; col < maze.GetLength(1); col++)
            {
                maze[filas,col] = Laberinto[filas * maze.GetLength(1) + col];
            }
        }
        
        return maze;
    }

    
    public int[,] CheckMazeBorders()
    {
        int [,] Laberinto = Convert2DArray();
        int numRows = Laberinto.GetLength(0);
        int numCols = Laberinto.GetLength(1);
        bool hasExit = false;
        for (int i = 0; i < numRows; i++)
        {
            if (Laberinto[i, 0] != 1)
            {
                if(Laberinto[i, 0] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    Laberinto[i, 0] = 1;
                }
            }
            if(Laberinto[i, numCols - 1] != 1)
            {
                if(Laberinto[i, numCols - 1] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    Laberinto[i, numCols - 1] = 1;
                }
            }
        }
        for (int j = 0; j < numCols; j++)
        {
            if (Laberinto[0, j] != 1)
            {
                if(Laberinto[0, j] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    Laberinto[0, j] = 1;
                }

            }
            if (Laberinto[numRows - 1, j] != 1)
            {
                if(Laberinto[numRows - 1, j] == 3 && !hasExit){
                    hasExit = true;
                }
                else{
                    Laberinto[numRows - 1, j] = 1;
                }

            }
        }
        if(!hasExit){
            Laberinto[0, 1] = 3;
        }
        return Laberinto;
    }


}
