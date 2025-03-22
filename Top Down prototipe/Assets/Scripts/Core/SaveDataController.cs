using System.Collections;
using UnityEngine;

public class SaveDataController : MonoBehaviour
{
    private string saveDataPath;
    void Start()
    {
        saveDataPath = Application.persistentDataPath + "/saveData.json";
        if (System.IO.File.Exists(saveDataPath))
        {
            Debug.Log("Save data exists!");
            LoadGame();
        }
        else
        {
            Debug.Log("Save data does not exist!");
        }
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


    public void DeleteSave()//untuk menghapus save data
    {
        if (System.IO.File.Exists(saveDataPath))
        {
            System.IO.File.Delete(saveDataPath);
        }
    }


}
