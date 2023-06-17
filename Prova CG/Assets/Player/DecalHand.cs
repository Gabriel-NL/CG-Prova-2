using System.Collections.Generic;
using UnityEngine;

public class DecalHand : MonoBehaviour
{
    public List<Texture2D> symbolTextures;
    public List<KeyCode> symbolKeys;
    public Projector symbolProjector;

    private Dictionary<KeyCode, Texture2D> symbolMap = new Dictionary<KeyCode, Texture2D>();

    private void Start()
    {
        // Mapeia as teclas aos símbolos correspondentes
        if (symbolTextures.Count == symbolKeys.Count)
        {
            for (int i = 0; i < symbolKeys.Count; i++)
            {
                symbolMap[symbolKeys[i]] = symbolTextures[i];
            }
        }
    }

    private void Update()
    {
        foreach (KeyCode key in symbolMap.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                // Define a textura do decal para o símbolo correspondente à tecla pressionada
                symbolProjector.material.SetTexture("_Texture", symbolMap[key]);
                break;
            }
        }
    }
}
