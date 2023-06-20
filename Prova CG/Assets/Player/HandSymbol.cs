using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class HandSymbol : MonoBehaviour
{

    public DecalProjector decalProjector;

    public void AtualizarMaterial(Material tatuagem)
    {
        
        decalProjector.material = tatuagem;
    }
}
