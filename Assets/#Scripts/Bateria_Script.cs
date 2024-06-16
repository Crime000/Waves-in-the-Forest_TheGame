using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria_Script : MonoBehaviour
{
    MovimientoJugador jugador;
    public Light Linterna;
    public int Baterias = 0;
    public float Energia, EnergiaMaxima, intensidadLinterna, IntensidadMaxima;
    private string Jugador = "Jugador";

    // Start is called before the first frame update
    void Start()
    {
        intensidadLinterna = IntensidadMaxima;
        Energia = EnergiaMaxima;
        jugador = GetComponent<MovimientoJugador>();
    }

    private void FixedUpdate()
    {
        if(Baterias > 0)
        {
            Baterias -= 1;
            Energia = EnergiaMaxima;
        }

        Energia -= Time.deltaTime;

        intensidadLinterna = intensidadLinterna * Energia / EnergiaMaxima * 2f;

        if(intensidadLinterna > IntensidadMaxima)
        {
            intensidadLinterna = 4;
        }

        Linterna.intensity = intensidadLinterna;

    }

    //-------------------------------------------------------------------------------------------------------------------------
    public void RecogerBateria()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(Jugador);
        float DistanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);

        if(DistanciaAlJugador <= 1f)
        {
            Baterias += 1;
        }
    }

 //-------------------------------------------------------------------------------------------------------------------------
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
    }
}
