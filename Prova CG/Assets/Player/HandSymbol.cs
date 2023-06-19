using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSymbol : MonoBehaviour
{
    public List<Sprite> symbolSprites;
    public List<RectTransform> symbolImages;
    public Transform playerHand;

    private int currentSymbolIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentSymbolIndex = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            currentSymbolIndex = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            currentSymbolIndex = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            currentSymbolIndex = 3;

        // Atualiza as imagens com base no índice do símbolo selecionado
        if (currentSymbolIndex >= 0 && currentSymbolIndex < symbolSprites.Count)
        {
            Sprite selectedSprite = symbolSprites[currentSymbolIndex];
            foreach (RectTransform symbolImage in symbolImages)
            {
                symbolImage.gameObject.SetActive(true);
                symbolImage.GetComponent<Image>().sprite = selectedSprite;


                // Define a posição e a rotação da imagem próxima à posição da mão do jogador
                symbolImage.position = playerHand.position;
                symbolImage.rotation = playerHand.rotation;
            }
        }
        else
        {
            foreach (RectTransform symbolImage in symbolImages)
            {
                symbolImage.gameObject.SetActive(false);
            }
        }
    }
}
