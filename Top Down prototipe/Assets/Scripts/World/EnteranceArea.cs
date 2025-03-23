using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceArea : MonoBehaviour,IInteractable
{
    [SerializeField] private int sceneIndex; // Perbaiki salah ketik "sceenIndex"

    public void Interact()
    {
        // Periksa apakah scene index valid sebelum berpindah scene
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
        else
        {
            Debug.LogError("Scene index tidak valid! Periksa pengaturan build.");
        }
    }

    
}
