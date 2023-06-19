using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantaCarnivora : MonoBehaviour
{
    //Imagem e array de imagens
    public RawImage floatingImage; 
    public RawImage[] imageOptions; 

    //Variaveis
    private bool isVisible;
    private bool isChangingImage;
    private float sortingSpeed = 0f;

    //Scripts
    public UI classe_interface_usuario;

    private void Start()
    {
        // Initially set the transparency of the image to 0 (invisible)
        SetImageTransparency(0f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            // Trigger the "MagiaAleatoria" function when F key is held down
            MagiaAleatoria();
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            // Set the visibility flag to true when collision with the jogador_objeto occurs
            classe_interface_usuario.AtualizarMensagem("Gerar magia aleatória");
            isVisible = true;

        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.collider.CompareTag("Player")){
            classe_interface_usuario.AtualizarMensagem("");
            isVisible = false;
        }
    }

    private void MagiaAleatoria()
    {
        if (!isVisible || isChangingImage)
        {
            // Do not proceed if the image is not visible or if it's currently changing
            return;
        }

        // Set the changing image flag to true
        isChangingImage = true;

        // Set the initial sorting speed
        sortingSpeed = 6;

        // Start sorting the image options
        SetImageTransparency(1f);
        StartCoroutine(SortImages());
    }

    private IEnumerator SortImages()
    {
        int currentIndex = 0;

        // Keep sorting the images until the sorting speed reaches 0
        while (sortingSpeed > 0f)
        {
            // Randomly select the next index (excluding the current index)
            int nextIndex = Random.Range(0, imageOptions.Length - 1);
            if (nextIndex >= currentIndex)
            {
                nextIndex++;
            }

            // Set the current index to the next index
            currentIndex = nextIndex;

            // Change the sprite of the image to the current index option
            floatingImage.texture = imageOptions[currentIndex].texture;

            // Gradually slow down the sorting speed
            sortingSpeed -= (Time.deltaTime);

            yield return sortingSpeed;
        }

        // Set the final image to the target index
        floatingImage.texture = imageOptions[currentIndex].texture;

        // Set the changing image flag to false
        isChangingImage = false;

        // Set the transparency of the image to 1 (fully visible)
    }

    private void SetImageTransparency(float transparency)
    {
        Color imageColor = floatingImage.color;
        imageColor.a = transparency;
        floatingImage.color = imageColor;
    }
}
