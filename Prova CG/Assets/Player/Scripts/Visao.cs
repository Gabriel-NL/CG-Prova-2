using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    private float sensibilidade = 5;
    private float suavizacao = 1.5f;

    private Vector2 velocidade_frame, velocidade_rotacao;
    
    //Instancia
    public static Visao instance;

    public static Visao Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Visao();
            }
            return instance;
        }
    }

    // Update is called once per frame
    public void CameraSystem(Transform player_transform,Transform camera)
    {

        Vector2 mouse_inputs = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 raw_velocidade_frame = Vector2.Scale(mouse_inputs, Vector2.one * sensibilidade);

        velocidade_frame = Vector2.Lerp(velocidade_frame, raw_velocidade_frame, 1 / suavizacao);
        velocidade_rotacao += velocidade_frame;
        velocidade_rotacao.y = Mathf.Clamp(velocidade_rotacao.y, -80, 80);

        camera.localRotation = Quaternion.AngleAxis(-velocidade_rotacao.y, Vector3.right);
        player_transform.localRotation = Quaternion.AngleAxis(velocidade_rotacao.x, Vector3.up);
    }
}
