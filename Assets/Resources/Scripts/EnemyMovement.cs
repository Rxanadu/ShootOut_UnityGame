using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    Transform enemyTransform;

    public float speed = 3f;
    public float hitDistance = 3f;

    void Start()
    {
        enemyTransform = transform.parent;
    }

    void Update()
    {
        Vector3 fwd = Vector3.forward;
        Debug.DrawLine(transform.position, fwd, Color.red);

        float step = speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, fwd, hitDistance))
        {
            /*if(enemyTransform.transform.rotation.y>0){
                enemyTransform.transform.Rotate (Vector3.up*40*Time.deltaTime);
            }
            if(enemyTransform.transform.rotation.y>0){
                enemyTransform.transform.Rotate (Vector3.up*-40*Time.deltaTime);
            }*/
            enemyTransform.transform.Rotate(0, -enemyTransform.transform.rotation.y * Time.deltaTime, 0);
        }
        else
        {
            enemyTransform.Translate(Vector3.forward * step);
        }
    }
}