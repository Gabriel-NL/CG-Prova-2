using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Lógica de movimento do inimigo aqui...
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Verifica se o inimigo está se movendo
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            // Ativa a animação de movimento
            isMoving = true;
        }
        else
        {
            // Desativa a animação de movimento
            isMoving = false;
        }

        // Atualiza o parâmetro "IsMoving" no Animator
        animator.SetBool("IsMoving", isMoving);
    }
}