using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpplayer : MonoBehaviour
{
	public int health; //O health iremos determinar em câmera, utilizando o script hpplayer

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("Health = " + health.ToString()); //Aqui irá aparecer a notificação de que o player tomou dano no debug
	}
}