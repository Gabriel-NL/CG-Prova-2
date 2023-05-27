using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida_morte : MonoBehaviour
{
    
    //pegando instancia PlayerData
    private PlayerData pd = PlayerData.Instance;

    //Instancia
    public static Vida_morte instance;

    //Componentes
    private GameObject imagemDano;
    private RawImage canvasRI;

    //Variaveis
    public bool touchedEnemy;

    public static Vida_morte Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Vida_morte();
            }
            return instance;
        }
    }

    public void setObject(GameObject gm)
    {
        this.imagemDano = gm;
        canvasRI = imagemDano.GetComponent<RawImage>();
    }

    public IEnumerator IntervaloParatestes()
    {
        yield return new WaitForSeconds(2);
    }
}
