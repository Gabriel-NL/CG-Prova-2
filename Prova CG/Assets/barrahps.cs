using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barrahps : MonoBehaviour
{
        public Slider healthBar;
        hpplayer hpplayer;

        void Start ()
        {
             hpplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<hpplayer>();

        }

        void Update ()
        {
            healthBar.value = hpplayer.health;

        }

}