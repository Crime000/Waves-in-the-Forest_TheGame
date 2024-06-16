using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    MovimientoJugador jugador;
    public GameObject Nota;
    public LucesGenerales luces;

    public int numeroDeNotas;
    private string Jugador = "Jugador";

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<MovimientoJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecogerNota()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(Jugador);
        float DistanciaAlJugador = Vector3.Distance(Nota.transform.position, jugador.transform.position);

        if (DistanciaAlJugador <= 1f)
        {
            numeroDeNotas += 1;
            Nota.SetActive(false);
            luces.salon = false;
            luces.comedor = false;
        }
    }
}
