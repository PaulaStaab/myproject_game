using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] float movementSpeed;


    /// <summary>
    /// Movement is called by an input system when the player uses the joystick on the controller 
    /// </summary>
    /// <param name="ctx">Context provided by Unity Input</param>
  public void Movement(CallbackContext ctx)
  {
        //movementInput is set by unity events 
        movementInput = ctx.ReadValue<Vector2>(); //comment
  }
  
  // This is a update 
    private void Update()
    {
        transform.position += new Vector3(movementInput.x /*X axis of Input*/, movementInput.y, 0) * Time.deltaTime * movementSpeed;
    }
}
