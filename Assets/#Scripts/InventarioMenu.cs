using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventarioMenu : MonoBehaviour
{
    PlayerInput input;
    public InputActionReference Inventario;
    public Canvas inventario;
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

    private void Salir()
    {
        
    }

    public void Cuaderno()
    {
        Debug.Log("Cuaderno");
    }

    public void Bateria()
    {
        Debug.Log("Bateria");
    }
}
