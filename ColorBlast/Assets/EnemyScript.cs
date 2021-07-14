using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int RandPlayer;
    public float RotationSpeed;
    private PlayerControllerV2 PCV2;
    private Transform Player;
    private Rigidbody RB;
    public float Thrust;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Player.position;
        Rotate();
        FindPlayerV2();
    }

    void Rotate()
    {
        /*
        Vector3 RotationDirection = new Vector3(P1.rotation.x, P1.rotation.y, P1.rotation.z);
        Vector3 NoRotation = new Vector3(0, 0, 0);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            //transform.forward = RotationDirection * Time.deltaTime ;
            Quaternion LookDirection = Quaternion.LookRotation(RotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }
        */

        //Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position), RotationSpeed * Time.deltaTime);

        transform.LookAt(Player);
    }

    void FindPlayer()
    {
        Vector3 PlayerPos = Player.position - transform.position;
        float Distance = PlayerPos.magnitude;
        RB.AddRelativeForce(Vector3.forward * Mathf.Clamp(Distance/50,0,1) * Thrust);
    }

    void FindPlayerV2()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, Thrust * Time.deltaTime);
    }
}
