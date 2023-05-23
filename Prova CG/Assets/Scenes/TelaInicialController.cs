using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicialController : MonoBehaviour
{
    public string JogoPrincipal;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(JogoPrincipal);
        }
    }
}
