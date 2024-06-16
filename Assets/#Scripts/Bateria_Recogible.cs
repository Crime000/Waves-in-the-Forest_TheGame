using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria_Recogible : MonoBehaviour
{

    MovimientoJugador jugador;
    public Bateria_Script energia;
    private string Jugador = "Jugador";

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<MovimientoJugador>();
    }

    //-------------------------------------------------------------------------------------------------------------------------
    public void RecogerBateria()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(Jugador);
        float DistanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);

        if (DistanciaAlJugador <= 1f)
        {
            energia.Baterias += 1;
            gameObject.SetActive(false);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
    }
}
