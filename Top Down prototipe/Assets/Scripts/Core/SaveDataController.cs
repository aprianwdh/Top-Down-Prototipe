using UnityEngine;

public class SaveDataController : MonoBehaviour
{
    private string saveDataPath;
    void Start()
    {
        saveDataPath = Application.persistentDataPath + "/saveData.json";
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.playerPosition = FindAnyObjectByType<Player>().transform.position;//menyimpan posisi player
        string json = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(saveDataPath, json);
    }

    public void LoadGame()
    {
        if (System.IO.File.Exists(saveDataPath))
        {
            string json = System.IO.File.ReadAllText(saveDataPath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(saveData.playerPosition);

            FindAnyObjectByType<Player>().transform.position = saveData.playerPosition;//opsional entar diganti
        }
    }


}
