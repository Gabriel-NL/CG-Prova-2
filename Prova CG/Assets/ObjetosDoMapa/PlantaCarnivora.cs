using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantaCarnivora : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage floatingImage; // Reference to the Image component
    public RawImage[] imageOptions; // Array of sprite options for the floating image

    public bool isVisible; // Flag to track the visibility of the image
    private bool isChangingImage; // Flag to track if the image is currently changing
    public float sortingSpeed = 0f; // Speed at which the sorting slows down

    public Controlador controlador;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            // Set the visibility flag to true when collision with the player occurs
            controlador.classe_user_interface.mensagem = "Gerar magia aleatória";
            isVisible = true;

        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            controlador.classe_user_interface.mensagem = "";
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

        // Randomly select an index for the image options
        int randomIndex = Random.Range(0, imageOptions.Length);

        // Start sorting the image options
        SetImageTransparency(1f);
        StartCoroutine(SortImages(randomIndex));
    }

    private IEnumerator SortImages(int targetIndex)
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
