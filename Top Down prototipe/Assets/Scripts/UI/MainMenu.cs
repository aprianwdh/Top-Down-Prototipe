using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public SaveDataController saveDataController;
    public Button continueButton; // Tambahkan referensi tombol Continue
    private string saveDataPath;

    private void Start()
    {
        saveDataController = FindAnyObjectByType<SaveDataController>();
        saveDataPath = Application.persistentDataPath + "/saveData.json";

        // Periksa apakah save data ada dan aktifkan/ nonaktifkan tombol Continue
        if (continueButton != null)
        {
            continueButton.interactable = File.Exists(saveDataPath);
        }
    }

    public void NewGame()
    {
        saveDataController.DeleteSave();
        StartCoroutine(LoadScene(1));
    }

    public void ContinueGame()
    {
        if (File.Exists(saveDataPath)) // Cek apakah save data ada sebelum melanjutkan
        {
            StartCoroutine(LoadScene(2));
            //saveDataController.LoadGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        TransisiSceen transisi = FindAnyObjectByType<TransisiSceen>();
        transisi.FadeIn();
        yield return new WaitForSeconds(1.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
