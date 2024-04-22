using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 leido = playerInput.actions["Movimiento"].ReadValue<Vector2>();
        rb.velocity = new Vector3(leido.x, 0, leido.y);
    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        Vector2 accion = context.action.ReadValue<Vector2>();
        rb.velocity = accion;
    }
}
