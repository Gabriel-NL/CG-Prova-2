using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour //Sistema para aplicar dano ao player
{
	public void SendDamage (int dam)
	{
		hpplayer playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<hpplayer>();
		playerStats.TakeDamage(dam);
	}
}
