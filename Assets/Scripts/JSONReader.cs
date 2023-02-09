using UnityEngine;

public class JSONReader
{
    public static MazeSettings ReadMazeSettings(string jsonFile)
    {
       return JsonUtility.FromJson<MazeSettings>(jsonFile);
    }
}
