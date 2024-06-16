using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Puertas_Abrir : MonoBehaviour
{
    public GameObject puertaCerrada, puertaAbierta;
    private string Jugador = "Jugador";
    public Transform centroPuerta;
    public bool estaCerrada;

    void Start()
    {
        puertaCerrada.SetActive(true);
        puertaAbierta.SetActive(false);
    }

 //-------------------------------------------------------------------------------------------------------------------------
    public void AbrirPuerta()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(Jugador);
        float DistanciaAlJugador = Vector3.Distance(centroPuerta.position, jugador.transform.position);

        if (DistanciaAlJugador <= 1)
        {
            if (estaCerrada == true)
            {
                estaCerrada = false;
                Debug.Log("Funciona");
                puertaCerrada.SetActive(false);
                puertaAbierta.SetActive(true);
            }
            if (estaCerrada == false)
            {
                estaCerrada = true;
                Debug.Log("No Funciona");
                puertaCerrada.SetActive(true);
                puertaAbierta.SetActive(false);
            }
            
        }
    }

 //-------------------------------------------------------------------------------------------------------------------------
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(centroPuerta.position, new Vector3(1,2,1));
    }
}
