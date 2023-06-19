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
    private int custo=190;

    private bool magiaPronta;
    private int magiaAtual=0;

    //Scripts
    public PlayerData pd;

    private void Start()
    {
        // Initially set the transparency of the image to 0 (invisible)
        SetImageTransparency(0f);
        magiaPronta = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {

            if (magiaPronta)
            {
                pd.PegarMagiaNova(magiaAtual);

            }
            else
            {
                if (pd.GetPontosDevocao() >= custo)
                {
                    pd.ConsumirPontosDevocao(custo);
                    MagiaAleatoria();
                }
                else
                {
                    Debug.Log("Você não tem pontos o suficiente!");
                }


            }
            // Trigger the "MagiaAleatoria" function when F key is held down

            
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            // Set the visibility flag to true when collision with the jogador_objeto occurs
            pd.classe_interface_usuario.AtualizarMensagem("Gerar magia aleatória");
            isVisible = true;

        }

        if (c.collider.CompareTag("Player") && magiaPronta)
        {
            // Set the visibility flag to true when collision with the jogador_objeto occurs
            pd.classe_interface_usuario.AtualizarMensagem("Segure F para equipar "+ pd.tm.getMagia(magiaAtual).Nome);
            isVisible = true;

        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.collider.CompareTag("Player")){
            pd.classe_interface_usuario.AtualizarMensagem("");
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
        sortingSpeed = 5;

        // Start sorting the image options
        SetImageTransparency(1f);
        StartCoroutine(SortImages());
    }

    private IEnumerator SortImages()
    {

        // Keep sorting the images until the sorting speed reaches 0
        while (sortingSpeed > 0f)
        {
            // Randomly select the next index (excluding the current index)
            int nextIndex = Random.Range(0, imageOptions.Length - 1);
            if (nextIndex >= magiaAtual)
            {
                nextIndex++;
            }

            // Set the current index to the next index
            magiaAtual = nextIndex;

            // Change the sprite of the image to the current index option
            floatingImage.texture = imageOptions[magiaAtual].texture;

            // Gradually slow down the sorting speed
            sortingSpeed -= (Time.deltaTime);

            yield return sortingSpeed;
        }

        // Set the final image to the target index
        floatingImage.texture = imageOptions[magiaAtual].texture;
        magiaPronta = true;
        // Set the changing image flag to false
        isChangingImage = false;

        // Set the transparency of the image to 1 (fully visible)
    }

    public void PegarMagia()
    {

    }

    private void SetImageTransparency(float transparency)
    {
        Color imageColor = floatingImage.color;
        imageColor.a = transparency;
        floatingImage.color = imageColor;
    }
}
