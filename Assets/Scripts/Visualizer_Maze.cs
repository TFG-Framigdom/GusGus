using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;



public class Visualizer_Maze : MonoBehaviour
{
    
    [SerializeField] MazeAleatorioSO mazeAleatorio;

    [SerializeField] LecturaFicheroSO lecturaFichero;

    public Button button{get {return GetComponent<Button>();}}

    private int[,] matrizLevel1;

    private int[,] matrizLevel2;

    private int[,] matrizLevel3;

    private System.Random rand;

    private Maze_Generator maze = new Maze_Generator(15);

    private string dataPath; 

    void Awake() 
    {
        dataPath = SaveSystem.filePath;
        
    }

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ReadJsonMaze);
    }
 

    public void ReadJsonMaze()
    {
        WriteJSON(dataPath);
        string jsonContent = File.ReadAllText(dataPath);
        MazeSettings settings =  JsonUtility.FromJson<MazeSettings>(jsonContent);
        lecturaFichero.tiempo = settings.Tiempo;
        lecturaFichero.TamañoX = settings.Tamano[0];
        lecturaFichero.TamañoY = settings.Tamano[1];
        int[,] mazeValido = settings.CheckMazeBorders(settings.Laberinto);
        int[,] mazeValidoLevel2 = settings.CheckMazeBorders(settings.LaberintoLevel2);
        int[,] mazeValidoLevel3 = settings.CheckMazeBorders(settings.LaberintoLevel3);

        
        lecturaFichero.laberinto = mazeValido;
        lecturaFichero.laberintoLevel2 = mazeValidoLevel2;
        lecturaFichero.laberintoLevel3 = mazeValidoLevel3;
        
    }

    public void WriteJSON(string filePath)
    {
        int[] matrizLevel1 = maze.PlaceEnemiesRandomlyLevel1(maze.GenerateMaze()).Cast<int>().ToArray();
        int[] matrizLevel2 = maze.PlaceEnemiesRandomlyLevel2(maze.GenerateMaze()).Cast<int>().ToArray();
        int[] matrizLevel3 = maze.PlaceEnemiesRandomlyLevel3(maze.GenerateMaze()).Cast<int>().ToArray();
        mazeAleatorio.laberintoAleatorio = matrizLevel1;
        mazeAleatorio.laberintoAleatorioLevel2 =  matrizLevel2;
        mazeAleatorio.laberintoAleatorioLevel3 = matrizLevel3;



        int[] tamano = new int[2];
        tamano[0] = 15;
        tamano[1] = 15;
        // Crear un objeto anónimo con los atributos "tiempo", "tamano" y "laberinto"
        var jsonObj = new
        {
            Tamano = tamano,
            Tiempo = 35,
            Laberinto = matrizLevel1,
            LaberintoLevel2 = matrizLevel2,
            LaberintoLevel3 = matrizLevel3
        };
        // Serializar el objeto a formato JSON
        string jsonString = JsonConvert.SerializeObject(jsonObj);
        // Guardar el JSON en un fichero
        SaveSystem.Init();
        if (!File.Exists(dataPath))
        {
            File.WriteAllText(dataPath, jsonString);
        }else{
            File.Delete(dataPath);
            File.WriteAllText(dataPath, jsonString);
        }

    }



    void ImprimirMaze(int[,] maze)
    {
        string mazeString = "";
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            mazeString += "[";
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                mazeString += maze[i, j] + ",";
            }
            mazeString += "]\n";
        }
        Debug.Log(mazeString);
    }
    
}



    
