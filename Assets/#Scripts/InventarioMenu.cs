using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventarioMenu : MonoBehaviour
{
    PlayerInput input;
    public InputActionReference Inventario;
    public Bateria_Script baterias;
    public Notas numeroNotas;
    public GameObject MenuNotas;
    public Canvas inventario;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI textoNotas;

    public bool activo = false;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        inventario.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activo == true)
        {
            inventario.enabled = true;
        }
        else
        {
            inventario.enabled = false;
        }
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Atras()
    {
        MenuNotas.SetActive(false);
    }

    public void Cuaderno()
    {
        if(numeroNotas.numeroDeNotas == 0)
        {
            StartCoroutine(mensajes(2));
        }
        if(numeroNotas.numeroDeNotas > 0)
        {
            MenuNotas.gameObject.SetActive(true);
        }
        
    }

    public void Bateria()
    {
        if (baterias.Baterias > 0)
        {
            baterias.Baterias -= 1;
            baterias.Energia = baterias.EnergiaMaxima;
        }
        else
        {
           StartCoroutine(mensajes(1));
        }
    }

    IEnumerator mensajes(int mensaje)
    {
        if(mensaje == 1)
        {
            texto.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            texto.gameObject.SetActive(false);
        }
        if(mensaje == 2)
        {
            textoNotas.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            textoNotas.gameObject.SetActive(false);
        }

    }
}
