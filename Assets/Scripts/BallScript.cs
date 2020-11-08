using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float gravityForce = 5.0f;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.back * gravityForce * Time.deltaTime, ForceMode.Force);
    }
}
