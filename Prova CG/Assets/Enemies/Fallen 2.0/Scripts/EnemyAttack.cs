using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f; // Distância mínima para iniciar o ataque
    public Animator animator; // Referência ao componente Animator do inimigo

    private Transform player; // Referência ao transform do jogador
    private bool isAttacking = false; // Verifica se já está atacando

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontra o objeto do jogador pelo tag e obtém sua referência
    }

    private void Update()
    {
        // Calcula a distância entre o inimigo e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Verifica se o jogador está próximo o suficiente para iniciar o ataque
        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            // Inicia a animação de ataque
            animator.SetTrigger("AttackTrigger");
            isAttacking = true;
        }
    }

    // Método chamado no evento de fim de animação de ataque
    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
    }
}