using UnityEngine;
using System.Collections;

public class PartnerMovement : MonoBehaviour
{

    public int movementSmoothing;
    public float speed = 60f;
    Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            movementSmoothing = 1;
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitDist = 0.0f;

            if (playerPlane.Raycast(ray, out hitDist))
            {
                var targetPoint = ray.GetPoint(hitDist);
                targetPosition = targetPoint;
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = targetRotation;
            }
        }

        Vector3 dir = targetPosition - transform.position;
        float dist = dir.magnitude;
        
        float move = speed * Time.deltaTime;
        if (dist > move)
        {
            transform.position += dir.normalized * move;
        }
        else
        {
            transform.position = targetPosition;
        }
    }
}