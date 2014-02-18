using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    Transform enemyTransform;

    public float speed = 3f;
    public float angle = 40f;
    public float hitDistance = 3f;

    void Start()
    {
        enemyTransform = transform.parent;
    }

    void Update()
    {
        WanderAroundEnvironment();
    }

    void WanderAroundEnvironment() {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
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
}