using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour 
{
	public void SendDamage (int dam)
	{
		hpplayer playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<hpplayer>();
		playerStats.TakeDamage(dam);
	}
}
