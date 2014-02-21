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
    public ParticleSystem boltExplosion;

    PartnerMovement partner;

    void Awake() {
        partner = GameObject.FindGameObjectWithTag("Player").GetComponent<PartnerMovement>();
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(transform.forward * force, ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other)
    {
        if (projectileType == ProjectileType.Enemy)
        {
            if (insultText != null)
                Instantiate(insultText, transform.position, Quaternion.identity);
            if (other.tag == "Player") {
                partner.ReducePlayerMovement();
            }
            return;
        }
        Destroy(gameObject);
        if (boltExplosion != null)
            Instantiate(boltExplosion, transform.position, transform.rotation);
    }
}