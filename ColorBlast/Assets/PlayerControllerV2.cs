using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV2 : MonoBehaviour
{
    private Rigidbody RB;
    public PlayerInput PI;
    private Vector2 Movement;
    private Vector2 CamAngle;
    public Camera Cam;
    public float Speed;
    public float RotationSpeed;
    //private Vector3 CamSpeed;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        PI = this.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector3(Movement.x, 0, Movement.y) * Speed * Time.deltaTime;

        //Rotate();
        //RotateCam();
        Cam.transform.Rotate(0, CamAngle.x, 0);

    }


    void Rotate()
    {
        Vector3 RotationDirection = new Vector3(Movement.x, 0, Movement.y);
        Vector3 NoRotation = new Vector3(0, 0, 0);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            //transform.forward = RotationDirection * Time.deltaTime ;
            Quaternion LookDirection = Quaternion.LookRotation(RotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }

    }

    void RotateCam()
    {
        Vector3 RotationDirection = new Vector3(CamAngle.x, 0, CamAngle.y);
        RotationDirection.Normalize();


        if (RotationDirection != Vector3.zero)
        {
            //transform.forward = RotationDirection * Time.deltaTime ;
            Quaternion LookDirection = Quaternion.LookRotation(RotationDirection);
            Cam.transform.rotation = Quaternion.RotateTowards(Cam.transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }

    }

    void Color()
    {

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
