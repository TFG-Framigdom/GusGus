
[System.Serializable]
public class MazeSettings
{
    public int[] Tamano;
    public int Tiempo;
    public int[] PJugador; 
    public int[] Pmeta;
    public int[] Laberinto;   

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

}
