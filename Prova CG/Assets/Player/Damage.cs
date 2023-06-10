using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {
    public int vida = 100;
    public string cena;

    void Awake() {
        transform.tag = "Player";
    }
    //Start is called before the first frame update
    void Start() {
        
    }

    //Update is called once per frame
    void Update() {
        if(vida <= 0) {
            vida = 0;
            Death();
        }
    }

    void Death() {
        SceneManager.LoadScene(cena);
    }
}
