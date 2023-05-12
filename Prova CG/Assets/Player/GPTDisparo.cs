using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPTDisparo : MonoBehaviour
{
    public GameObject objetoPrefab; 
    public ParticleSystem particleSystemPrefab; 
    public float forcaDisparo = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Conjurar();
        }
    }

    void Conjurar()
    {
        // Obtém a direção da câmera
        Vector3 direcao = Camera.main.transform.forward;

        // Instancia uma cópia do objeto e a posiciona na posição da câmera
        GameObject objeto = Instantiate(objetoPrefab, Camera.main.transform.position, Quaternion.identity);

        // Obtém o componente Rigidbody do objeto
        Rigidbody rigidbody = objeto.GetComponent<Rigidbody>();

        // Dispara o objeto na direção da câmera
        rigidbody.AddForce(direcao * forcaDisparo, ForceMode.Impulse);

        // Instancia uma cópia do Particle System e a faz seguir o objeto
        ParticleSystem particleSystem = Instantiate(particleSystemPrefab, objeto.transform.position, Quaternion.identity);
        particleSystem.transform.parent = objeto.transform;

        // Define o tamanho da partícula em relação ao tamanho do objeto
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startSizeMultiplier = objeto.transform.localScale.magnitude * 3f;
    }

}

