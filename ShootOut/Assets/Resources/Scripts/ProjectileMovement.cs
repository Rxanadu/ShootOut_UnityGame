using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{

    public float force = 10f;

    void FixedUpdate()
    {
        rigidbody.AddForce(transform.forward * force, ForceMode.Acceleration);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}