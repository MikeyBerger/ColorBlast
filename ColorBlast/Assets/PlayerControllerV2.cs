using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerV2 : MonoBehaviour
{
    private Rigidbody RB;
    public PlayerInput PI;
    private Vector2 Movement;
    private Vector2 CamAngle;
    private UIScript UIS;
    public Camera Cam;
    public float Speed;
    public float RotationSpeed;
    public float BulletForce;
    public bool ShootingRed;
    public bool ShootingBlue;
    public bool ShootingGreen;
    private bool IsPaused;
    private bool Return;
    public Transform RedBullet;
    public Transform BlueBullet;
    public Transform GreenBullet;
    public Transform ShootPoint;
    public float Timer;

    //private Vector3 CamSpeed;


    IEnumerator StopShoot()
    {
        yield return new WaitForSeconds(Timer);
        ShootingRed = false;
        ShootingBlue = false;
        ShootingGreen = false;
    }

    IEnumerator ShootRed()
    {
        yield return new WaitForSeconds(0);
        //Instantiate(MuzzleFlash, MuzzleFlashPoint.position, MuzzleFlashPoint.rotation);
        Transform BulletPrefab = Instantiate(RedBullet, ShootPoint.position, ShootPoint.rotation);
        //Instantiate(AudioClip, ShootPoint.position, ShootPoint.rotation);

        Rigidbody BulletRB = RedBullet.GetComponent<Rigidbody>();
        BulletRB.AddForce(ShootPoint.forward * BulletForce, ForceMode.Impulse);
    }

    IEnumerator ShootBlue()
    {
        yield return new WaitForSeconds(0);
        //Instantiate(MuzzleFlash, MuzzleFlashPoint.position, MuzzleFlashPoint.rotation);
        Transform BulletPrefab = Instantiate(BlueBullet, ShootPoint.position, ShootPoint.rotation);
        //Instantiate(AudioClip, ShootPoint.position, ShootPoint.rotation);

        Rigidbody BulletRB = BlueBullet.GetComponent<Rigidbody>();
        BulletRB.AddForce(ShootPoint.forward * BulletForce, ForceMode.Impulse);
    }

    IEnumerator ShootGreen()
    {
        yield return new WaitForSeconds(0);
        //Instantiate(MuzzleFlash, MuzzleFlashPoint.position, MuzzleFlashPoint.rotation);
        Transform BulletPrefab = Instantiate(GreenBullet, ShootPoint.position, ShootPoint.rotation);
        //Instantiate(AudioClip, ShootPoint.position, ShootPoint.rotation);

        Rigidbody BulletRB = GreenBullet.GetComponent<Rigidbody>();
        BulletRB.AddForce(ShootPoint.forward * BulletForce, ForceMode.Impulse);
    }



    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        PI = this.GetComponent<PlayerInput>();
        UIS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector3(Movement.x, 0, Movement.y) * Speed * Time.deltaTime;
        Shoot();
        //ShootV2();
        //Rotate();
        //RotateCam();
        Cam.transform.Rotate(0, CamAngle.x, 0);

        if (IsPaused)
        {
            Time.timeScale = 0;
        }
        else if (!IsPaused)
        {
            Time.timeScale = 1;
        }

        if (UIS.GameOver2 && Return)
        {
            SceneManager.LoadScene(0);
        }
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

    void Shoot()
    {
        if (ShootingRed)
        {
            Instantiate(RedBullet, ShootPoint.position, ShootPoint.rotation);
            StartCoroutine(StopShoot());
        }
        else if (ShootingBlue)
        {
            Instantiate(BlueBullet, ShootPoint.position, ShootPoint.rotation);
            StartCoroutine(StopShoot());
        }
        else if (ShootingGreen)
        {
            Instantiate(GreenBullet, ShootPoint.position, ShootPoint.rotation);
            StartCoroutine(StopShoot());
        }

    }

    
    void ShootV2()
    {
        if (ShootingRed)
        {
            StartCoroutine(ShootRed());
            ShootingRed = false;
        }
        else if (!ShootingRed)
        {
            StopAllCoroutines();
        }

        if (ShootingBlue)
        {
            StartCoroutine(ShootBlue());
            ShootingBlue = false;
        }
        else if (!ShootingBlue)
        {
            StopAllCoroutines();
        }

        if (ShootingGreen)
        {
            StartCoroutine(ShootGreen());
            ShootingGreen = false;
        }
        else if (!ShootingBlue)
        {
            StopAllCoroutines();
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

    public void OnShootRed(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            ShootingRed = true;
            ShootingBlue = false;
            ShootingGreen = false;
        }
    }

    public void OnShootBlue(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            ShootingRed = false;
            ShootingBlue = true;
            ShootingGreen = false;
        }
    }

    public void OnShootGreen(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            ShootingRed = false;
            ShootingBlue = false;
            ShootingGreen = true;
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && !IsPaused)
        {
            IsPaused = true;
        }
        else if (ctx.phase == InputActionPhase.Performed && IsPaused)
        {
            IsPaused = false;
        }
    }

    public void OnReturn(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && UIS.GameOver2)
        {
            SceneManager.LoadScene(0);
        }
        else if (ctx.phase == InputActionPhase.Performed && IsPaused)
        {
            SceneManager.LoadScene(0);
        }
    }
    #endregion
}
