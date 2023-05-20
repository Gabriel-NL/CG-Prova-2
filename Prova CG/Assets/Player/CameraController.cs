using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player_transform;
    public float sensibilidade = 5;
    public float suavizacao = 1.5f;

    private Vector2 velocidade_frame, velocidade_rotacao;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse_inputs = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 raw_velocidade_frame = Vector2.Scale(mouse_inputs,Vector2.one*sensibilidade);
        
        velocidade_frame = Vector2.Lerp(velocidade_frame, raw_velocidade_frame, 1 / suavizacao);
        velocidade_rotacao += velocidade_frame;
        velocidade_rotacao.y = Mathf.Clamp(velocidade_rotacao.y, -80, 80);

        transform.localRotation = Quaternion.AngleAxis(-velocidade_rotacao.y, Vector3.right);
        player_transform.localRotation=Quaternion.AngleAxis(velocidade_rotacao.x,Vector3.up);

    }
}
