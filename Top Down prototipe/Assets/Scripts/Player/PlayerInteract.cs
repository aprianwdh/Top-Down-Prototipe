using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable interactable;
    public GameObject iconInteract; // Pastikan ini sudah di-assign di Inspector

    private void Start()
    {
        iconInteract.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            print("Interact with " + collision.name);
            iconInteract.SetActive(true);

            // Simpan referensi IInteractable jika ada
            interactable = collision.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            iconInteract.SetActive(false);
            interactable = null; // Hapus referensi saat keluar dari area trigger
        }
    }

    private void Update()
    {
        // Jika tombol E ditekan dan ada objek yang bisa diinteraksi
        if (Input.GetKeyDown(KeyCode.E) && interactable != null)
        {
            interactable.Interact(); // Panggil fungsi Interact()
        }
    }
}
