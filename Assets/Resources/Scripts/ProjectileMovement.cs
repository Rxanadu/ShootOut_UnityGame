using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{

    public enum ProjectileType
    {
        Player,
        Enemy
    }

    public ProjectileType projectileType;

    public GameObject insultText;
    public float force = 10f;

    void FixedUpdate()
    {
        rigidbody.AddForce(transform.forward * force, ForceMode.Acceleration);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }

    void OnDestroy() {
        if (projectileType == ProjectileType.Enemy)
        {
            if (insultText != null)
                Instantiate(insultText, transform.position, Quaternion.identity);
        }
    }
}