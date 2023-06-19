using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi pressionado
        {
            animator.SetTrigger("MagicHandTrigger"); // Ativa o gatilho "MagicHandTrigger" no Animator
        }
    }
}
