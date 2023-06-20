using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantaCarnivora : MonoBehaviour
{
    //scripts
    public TodasAsMagias tm;
    
    //Imagem e array de imagens
    public RawImage floatingImage;

    //Variaveis
    private bool isVisible;
    private bool isChangingImage;
    private float sortingSpeed = 0f;
    private int custo=800;
    private bool ativo=true;

    private bool magiaPronta;
    [SerializeField] private int magiaAtual=0;

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
        PlantaCarnivoraHandler();
        
        

    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            

            if (magiaPronta)
            {
                pd.classe_interface_usuario.AtualizarMensagem("Aperte F para equipar " + pd.tm.getMagia(magiaAtual).Nome);
            }
            else
            {
                // Set the visibility flag to true when collision with the jogador_objeto occurs
                pd.classe_interface_usuario.AtualizarMensagem("Aperte F para oferecer tributo(" + custo + ")");
            }
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

        pd.ConsumirPontosDevocao(custo);

        // Set the initial sorting speed
        sortingSpeed = 5;

        // Start sorting the image options
        SetImageTransparency(1f);
        StartCoroutine(SortImages());


    }

    private IEnumerator SortImages()
    {
        // Keep sorting the images until the sorting speed reaches 0
            this.magiaAtual = Random.Range(0, 3);
        while (sortingSpeed > 0f)
        {
            // Randomly select the next index (excluding the current index)
            if (this.magiaAtual < 3)
            {
                this.magiaAtual += 1;
            }
            else
            {
                this.magiaAtual = 0;
            }

            // Set the current index to the next index
            

            // Change the sprite of the image to the current index option
            
            floatingImage.texture = tm.getMagia(magiaAtual).tatuagem.mainTexture;
            // Gradually slow down the sorting speed
            sortingSpeed -= (Time.deltaTime);

            yield return sortingSpeed;
        }

        // Set the final image to the target index
        Debug.Log(this.magiaAtual);
        floatingImage.texture = tm.getMagia(magiaAtual).tatuagem.mainTexture;
        
        magiaPronta = true;
        // Set the changing image flag to false
        isChangingImage = false;

        // Set the transparency of the image to 1 (fully visible)
    }

    public void PegarMagia()
    {
        pd.PegarMagiaNova(magiaAtual);
        magiaPronta = false;
        isVisible = false;
        SetImageTransparency(0f);
    }

    public IEnumerator Intervalo()
    {
        ativo = false;
        yield return new WaitForSeconds(2);
    }

    public void PlantaCarnivoraHandler()
    {
        
        if (Input.GetKey(KeyCode.F) && ativo)
        {

            if (!magiaPronta)
            {
                if (pd.GetPontosDevocao() >= custo)
                {
                        MagiaAleatoria();
                }
                else
                {
                    Debug.Log("Você não tem pontos o suficiente!");
                }
            }
            else
            {
                PegarMagia();
                StartCoroutine(Intervalo());
                ativo = true;
            }

        }


    }

    private void SetImageTransparency(float transparency)
    {
        Color imageColor = floatingImage.color;
        imageColor.a = transparency;
        floatingImage.color = imageColor;
    }
}
