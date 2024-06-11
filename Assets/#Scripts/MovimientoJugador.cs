using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput playerInput;
    public float velocidad;
    private Quaternion rotacionActual;
    public Transform cam;
    public InputActionReference Recoger, Abrir, Inventario;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        rotacionActual = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 leido = playerInput.actions["Movimiento"].ReadValue<Vector2>();
        Vector3 Direction = new Vector3(leido.x, 0, leido.y);
        Direction = cam.transform.forward * leido.y + cam.transform.right * leido.x;
        Direction.y = 0f;
        rb.velocity = Direction * velocidad;
    }

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

    public void recoger(InputAction.CallbackContext context)
    {
        Debug.Log("Recoger");
    }

    public void abrir(InputAction.CallbackContext context)
    {
        Debug.Log("Abrir");
    }

    public void inventario(InputAction.CallbackContext context)
    {
        Debug.Log("Inventario");
    }
}
