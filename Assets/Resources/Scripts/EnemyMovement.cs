using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public enum EnemyType
    {
        Wandering,
        Stationary
    }

    public EnemyType enemyType;

    public float speed = 3f;
    public float angle = 40f;
    public float hitDistance = 3f;
    public float fireDistance = 5f;
    public GameObject projectile;
    public float fireRate = 12f;

    float nextFire;
    Transform enemyTransform;

    void Start()
    {
        enemyTransform = transform.parent;
    }

    void Update()
    {
        CastRayForward();

    }

    void CastRayForward()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();

        if (enemyType == EnemyType.Wandering)
            WanderAroundEnvironment(ray, hit);

        FireAtPlayer(ray, hit);
    }

    /// <summary>
    /// move enemy forward if raycast has not hit an object
    /// <remarks>only use for wandering enemies</remarks>
    /// </summary>
    void WanderAroundEnvironment(Ray ray, RaycastHit hit)
    {
        float step = speed * Time.deltaTime;

        if (Physics.Raycast(ray, out hit, hitDistance))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            float turnStep = angle * Time.deltaTime;
            enemyTransform.transform.Rotate(0, turnStep, 0);
        }
        else
        {
            enemyTransform.Translate(Vector3.forward * step);
        }
    }

    /// <summary>
    /// fires projectiles at player object
    /// <remarks>used with all enemy types</remarks>
    /// </summary>
    void FireAtPlayer(Ray ray, RaycastHit hit)
    {
        print("hi");


        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("I'm hitting the player");
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(projectile, transform.position, transform.rotation);
                }

            }
        }
    }
}