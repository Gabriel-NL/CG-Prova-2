using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    //Scripts
    public Estrutura spell;
    public PlayerData pd;

    //Componentes
    public Camera cam;
    public Transform RHFirePoint;
    public Animator animatorPlayer;
    
    //Variaveis
    private float cadencia_timer;
    private Vector3 destination;
    private readonly float projectileSpeed = 30; 
    private readonly float arcRange = 1;

    public void CastingSystem()
    {
        this.spell = pd.GetDadosDaMagiaAtual();
        if (this.cadencia_timer > 0)
        {
            this.cadencia_timer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && pd.GetCargas() > 0)
            {
                cadencia_timer = 1f/ pd.GetDadosDaMagiaAtual().Cadencia;
                pd.ConsumirCarga();
                //this.animatorPlayer.SetBool("shooting", true);
                HandleCasting();
            }
            else
            {
                //this.animatorPlayer.SetBool("shooting", false);
            }
        }
    }

    private void HandleCasting()
    {
        Ray ray = this.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        GameObject projectileObj;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        projectileObj = Instantiate(this.spell.Vfx, this.RHFirePoint.position, Quaternion.identity);

        projectileObj.GetComponent<Rigidbody>().velocity = (destination - this.RHFirePoint.position).normalized * projectileSpeed;
        Projetil script = projectileObj.GetComponent<Projetil>();
        script.InicializandoValores(this.spell, this.pd);
        

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }





}
