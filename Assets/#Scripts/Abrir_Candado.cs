using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrir_Candado : MonoBehaviour
{
    public GameObject candado;
    public GameObject llave;
    public LucesGenerales luces;

    MovimientoJugador jugador;
    private string Jugador = "Jugador";

    public bool tieneLlave = false;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<MovimientoJugador>();
    }

    //-------------------------------------------------------------------------------------------------------------------------
    public void AbrirCandado()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(Jugador);
        float DistanciaAlJugadorDeCandado = Vector3.Distance(candado.transform.position, jugador.transform.position);

        if (DistanciaAlJugadorDeCandado <= 1f && tieneLlave == true)
        {
            tieneLlave = false;
            candado.SetActive(false);
        }
    }


    public void RecogerUnaLlave()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(Jugador);
        float DistanciaAlJugadorDeLlave = Vector3.Distance(llave.transform.position, jugador.transform.position);

        if (DistanciaAlJugadorDeLlave <= 1f)
        {
            tieneLlave = true;
            llave.SetActive(false);
            luces.cocina = false;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(llave.transform.position, new Vector3(1f, 1f, 1f));
        Gizmos.DrawWireCube(candado.transform.position, new Vector3(1f, 1f, 1f));
    }
}
