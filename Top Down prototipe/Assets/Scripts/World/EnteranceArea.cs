using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceArea : MonoBehaviour
{
    [SerializeField] private int sceneIndex; // Perbaiki salah ketik "sceenIndex"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
}
