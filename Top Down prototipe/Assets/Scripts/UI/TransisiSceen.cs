using UnityEngine;

public class TransisiSceen : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
