using UnityEngine;

public class TransisiSceen : MonoBehaviour
{
    private Animator animator;
    public GameObject transisi;

    private void Start()
    {
        animator = GetComponent<Animator>();
        transisi.SetActive(true);
    }

    public void FadeOut()
    {
        animator.SetTrigger("Fade_Out");
    }

    public void FadeIn()
    {
        animator.SetTrigger("Fade_In");
    }
}
