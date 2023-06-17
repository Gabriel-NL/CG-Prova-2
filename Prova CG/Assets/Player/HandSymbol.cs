using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSymbol : MonoBehaviour
{
    public List<Texture2D> symbolTextures;
    public List<RawImage> symbolRawImages;
    public Transform playerHand;

    private int currentTextureIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentTextureIndex = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            currentTextureIndex = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            currentTextureIndex = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            currentTextureIndex = 3;

        // Atualiza as RawImages com base no índice da textura selecionada
        if (currentTextureIndex >= 0 && currentTextureIndex < symbolTextures.Count)
        {
            Texture2D selectedTexture = symbolTextures[currentTextureIndex];
            foreach (RawImage rawImage in symbolRawImages)
            {
                rawImage.texture = selectedTexture;

                // Define a posição da RawImage próxima à posição da mão do jogador
                rawImage.transform.position = playerHand.position;
                rawImage.transform.rotation = playerHand.rotation;
            }
        }
    }
}
