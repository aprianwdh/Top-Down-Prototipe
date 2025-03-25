using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EntranceArea : MonoBehaviour,IInteractable
{
    [SerializeField] private int sceneIndex; // Perbaiki salah ketik "sceenIndex"

    public void Interact()
    {
        // Periksa apakah scene index valid sebelum berpindah scene
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadSceen());
        }
        else
        {
            Debug.LogError("Scene index tidak valid! Periksa pengaturan build.");
        }
    }

    IEnumerator LoadSceen()
    {
        TransisiSceen transisi = FindAnyObjectByType<TransisiSceen>();
        transisi.FadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneIndex);
    }

    
}
