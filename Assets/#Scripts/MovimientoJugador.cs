using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody rb;

    PlayerInput playerInput;
    public InventarioMenu inventory;
    public Puertas_Abrir interactuarPuertas;
    public Bateria_Recogible recogerBateria;
    public Bateria_Script energia;
    public Abrir_Candado interactuarConCandado;
    public Notas notas;
    public InputActionReference Recoger, Abrir, Inventario, Linterna;

    public Transform cam, mano;

    public float velocidad, caida, gravedad;
    private float multiplicadorGravedad = 3f;
    private bool ActInv = false;
    
    

    // 
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    //
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        Vector2 leido = playerInput.actions["Movimiento"].ReadValue<Vector2>();

        if(caida <= -5)
        {
            caida = -0.2f;
        }

        Vector3 Direction = new Vector3(leido.x, 0, leido.y);
        Direction = cam.transform.forward * leido.y + cam.transform.right * leido.x;
        caida += gravedad * multiplicadorGravedad * Time.deltaTime;
        Direction.y = caida;
        rb.velocity = Direction * velocidad;
        mano.localRotation = cam.localRotation;

    }


    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        Recoger.action.started += recoger;
        Abrir.action.started += abrir;
        Inventario.action.started += inventario;
        Linterna.action.started += encenderYapagar;
    }

    private void OnDisable()
    {
        Recoger.action.started -= recoger;
        Abrir.action.started -= abrir;
        Inventario.action.started -= inventario;
        Linterna.action.started -= encenderYapagar;
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private void AccionarInventario()
    {
        if(ActInv == false)
        {
            inventory.activo = true;
            Time.timeScale = 0f;
            ActInv = true;
        }
        else
        {
            inventory.activo = false;
            Time.timeScale = 1f;
            ActInv = false;
        }
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void InteractuarConPuertas()
    {
        interactuarPuertas.AbrirPuerta();
        interactuarConCandado.AbrirCandado();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void InteractuarConObjeto()
    {
        recogerBateria.RecogerBateria();
        interactuarConCandado.RecogerUnaLlave();
        notas.RecogerNota();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void AccionarLinterna()
    {
        energia.CambioDeEstado();
    }



    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void recoger(InputAction.CallbackContext context)
    {
        InteractuarConObjeto();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void abrir(InputAction.CallbackContext context)
    {
        InteractuarConPuertas();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void inventario(InputAction.CallbackContext context)
    {
        AccionarInventario();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void encenderYapagar(InputAction.CallbackContext context)
    {
        AccionarLinterna();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puerta"))
        {
            interactuarPuertas = other.GetComponent<Puertas_Abrir>();
        }
        if (other.gameObject.CompareTag("Bateria"))
        {
            recogerBateria = other.GetComponent<Bateria_Recogible>();
        }
        if (other.gameObject.CompareTag("Candado"))
        {
            interactuarConCandado = interactuarConCandado.GetComponent<Abrir_Candado>();
        }
        if (other.gameObject.CompareTag("Llave"))
        {
            interactuarConCandado = interactuarConCandado.GetComponent<Abrir_Candado>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            caida = -0.2f;
        }
    }
}
