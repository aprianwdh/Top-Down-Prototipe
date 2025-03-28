using UnityEngine;

public class SavePoint : MonoBehaviour, IInteractable
{
    [SerializeField] private SaveDataController saveDataController;

    private void Start()
    {
        if (saveDataController == null)
        {
            saveDataController = FindAnyObjectByType<SaveDataController>();

            if (saveDataController == null)
            {
                Debug.LogError("SaveDataController tidak ditemukan di scene!");
            }
        }
    }

    public void Interact()
    {
        if (saveDataController != null)
        {
            saveDataController.SaveGame();
            Debug.Log("Game berhasil disimpan!");
        }
        else
        {
            Debug.LogError("Gagal menyimpan game, SaveDataController tidak ditemukan!");
        }
    }
}
