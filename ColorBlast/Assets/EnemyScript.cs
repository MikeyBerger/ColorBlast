using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int RandPlayer;
    private PlayerControllerV2 PCV2;
    private Transform P1;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = P1.position;
    }
}
