using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RB;
    private Vector2 Movement;
    private Vector2 CamAngle;
    public float Speed;
    public float RotationSpeed;
    private PlayerInput PI;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        PI = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector3(Movement.x, 0, Movement.y) * Speed * Time.deltaTime;
        Rotate();


    }


    void Rotate()
    {
        Vector3 RotationDirection = CamAngle;
        Vector3 NoRotation = new Vector3(0, 0, 0);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            //transform.forward = RotationDirection * Time.deltaTime ;
            Quaternion LookDirection = Quaternion.LookRotation(RotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }

    }

    #region InputActions
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        CamAngle = ctx.ReadValue<Vector2>();
    }
    #endregion
}

