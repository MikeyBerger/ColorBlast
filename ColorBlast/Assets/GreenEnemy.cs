using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    private UIScript UIS;

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GreenBullet")
        {
            transform.gameObject.SetActive(false);
            UIS.Points = UIS.Points + 1;
            StartCoroutine(SelfDestruct());
            Destroy(collision.gameObject);
        }
    }
}
