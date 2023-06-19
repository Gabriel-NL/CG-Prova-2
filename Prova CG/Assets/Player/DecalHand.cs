using System.Collections.Generic;
using UnityEngine;

public class DecalHand : MonoBehaviour
{
    public List<Texture2D> symbolTextures;
    public List<KeyCode> symbolKeys;
    public GameObject decalPrefab;
    public Transform decalContainer;

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
                // Cria um novo decal
                GameObject decal = Instantiate(decalPrefab, decalContainer);
                decal.transform.position = transform.position;
                decal.transform.rotation = transform.rotation;

                // Aplica a textura do símbolo no material do decal
                MeshRenderer decalRenderer = decal.GetComponent<MeshRenderer>();
                decalRenderer.material.SetTexture("_MainTex", symbolMap[key]);

                // Ajusta a escala, rotação ou qualquer outra propriedade do decal, se necessário

                break;
            }
        }
    }
}
