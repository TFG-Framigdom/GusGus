using UnityEngine;
using System.IO;

public static class SaveSystem 
{
    //public static readonly string dataPath = Application.dataPath + "/Files/MazeGenerator/";
    public static readonly string dataPath = Application.dataPath + "/Files/MazeGenerator/";
    public static string filePath = Path.Combine(dataPath, "maze.json");

    public static void Init()
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
            if (!File.Exists(filePath))
            {
            File.Create(filePath).Dispose();
            }
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Dispose();
            }

        }
        else
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Dispose();
            }
            
        }
    }

}
