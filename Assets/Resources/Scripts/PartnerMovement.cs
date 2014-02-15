using UnityEngine;
using System.Collections;

public class PartnerMovement : MonoBehaviour
{
    public float speed = 60f;
    public GameObject movementMarker;
    Vector3 targetPosition;
    Quaternion targetRotation;
    Quaternion markerRotation;
    GameObject markerClone;

    void Start() {
        targetPosition = transform.position;
        markerRotation = Quaternion.Euler(90, 0, 0);

        if (movementMarker != null)
        {
            markerClone = Instantiate(movementMarker, targetPosition, Quaternion.identity) as GameObject;
            markerClone.transform.rotation = markerRotation;
            markerClone.renderer.enabled = false;
        }            
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetTargetLocation();
        }

        MovePartnerToTargetLocation();
    }

    void SetTargetLocation() {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Vector3 newTargetPoint = new Vector3(targetPoint.x, transform.position.y, targetPoint.z);
            targetPosition = newTargetPoint;

            Quaternion targetRotation = Quaternion.LookRotation(newTargetPoint - transform.position);
            transform.rotation = targetRotation;

            markerClone.transform.position = targetPosition;
            markerClone.transform.rotation = markerRotation;
            markerClone.renderer.enabled = true;
        }
    }

    void MovePartnerToTargetLocation() {
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;
        float step = speed * Time.deltaTime;

        if (distance > step)
        {
            transform.position += direction.normalized * step;
        }
        else
        {
            transform.position = targetPosition;
            markerClone.renderer.enabled = false;
        }
    }
}