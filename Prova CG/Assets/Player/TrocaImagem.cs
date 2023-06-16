using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaImagem : MonoBehaviour
{
    public Material materialPalma;
    public Texture2D imagem1;
    public Texture2D imagem2;
    public Texture2D imagem3;
    public Texture2D imagem4;

    private int currentImageIndex = 0;
    private Texture2D[] images;

    void Start()
    {
        images = new Texture2D[] { imagem1, imagem2, imagem3, imagem4 };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentImageIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentImageIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentImageIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentImageIndex = 3;
        }

        materialPalma.mainTexture = images[currentImageIndex];
    }
}