using System.IO;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Debug.Log("Name: " + data.sc);
            Debug.Log("Level: " + data.ic);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}