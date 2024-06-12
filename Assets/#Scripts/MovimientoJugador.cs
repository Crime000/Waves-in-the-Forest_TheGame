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
    public CinemachineVirtualCamera virtualCamera;
    public InputActionReference Recoger, Abrir, Inventario;

    public Transform cam, mano;

    public float velocidad;
    private bool ActInv = false;
    
    

    // 
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    //
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        Vector2 leido = playerInput.actions["Movimiento"].ReadValue<Vector2>();

        Vector3 Direction = new Vector3(leido.x, 0, leido.y);
        Direction = cam.transform.forward * leido.y + cam.transform.right * leido.x;
        Direction.y = 0f;
        rb.velocity = Direction * velocidad;

        mano.localRotation = 
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        Recoger.action.started += recoger;
        Abrir.action.started += abrir;
        Inventario.action.started += inventario;
    }

    private void OnDisable()
    {
        Recoger.action.started -= recoger;
        Abrir.action.started -= abrir;
        Inventario.action.started -= inventario;
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
    public void recoger(InputAction.CallbackContext context)
    {
        Debug.Log("Recoger");
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void abrir(InputAction.CallbackContext context)
    {
        Debug.Log("Abrir");
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void inventario(InputAction.CallbackContext context)
    {
        AccionarInventario();
    }
}
