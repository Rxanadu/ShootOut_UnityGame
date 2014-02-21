using UnityEngine;
using System.Collections;

public class PartnerMovement : MonoBehaviour
{
    public float speed = 60f;
    public float travelDistance = 10f;
    public GameObject movementMarker;
    public LayerMask pointLayer;
    public LineRenderer targetLine;

    Vector3 targetPosition;
    Quaternion targetRotation;
    Quaternion markerRotation;
    GameObject markerClone;
    bool settingTargetPosition;
    float initSpeed, initTravelDistance;

    void Awake()
    {
        initSpeed = speed;
        initTravelDistance = travelDistance;
    }

    void Start()
    {
        targetPosition = transform.position;
        markerRotation = Quaternion.Euler(90, 0, 0);

        if (movementMarker != null)
        {
            markerClone = Instantiate(movementMarker, targetPosition, Quaternion.identity) as GameObject;
            markerClone.transform.rotation = markerRotation;
            markerClone.renderer.enabled = false;
        }
        settingTargetPosition = false;
    }

    void Update()
    {
        speed = Mathf.Clamp(speed, 0, initSpeed);
        travelDistance = Mathf.Clamp(travelDistance, 0, initTravelDistance);

        SetPlayerMovementControls();        
    }

    /// <summary>
    /// sets movement controls for player object
    /// </summary>
    void SetPlayerMovementControls() {
        if (Input.GetMouseButtonDown(1))
        {
            settingTargetPosition = true;
        }
        if (Input.GetMouseButtonUp(1))
            settingTargetPosition = false;

        if (settingTargetPosition)
        {
            targetLine.enabled = true;
            SetTargetLocationWithLayer();
        }
        if (!settingTargetPosition)
        {
            targetLine.enabled = false;
            MovePartnerToTargetLocation();
        }
    }

    /// <summary>
    /// sets location for where player will move
    /// <remarks>should be used with Physics.Raycast</remarks>
    /// </summary>
    void SetTargetLocationWithLayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pointLayer))
        {
            if (Vector3.Distance(transform.position, hit.point) < Mathf.Abs(travelDistance))
            {
                Vector3 targetPoint = hit.point;
                Vector3 newTargetPoint = new Vector3(targetPoint.x, transform.position.y, targetPoint.z);
                targetPosition = newTargetPoint;

                Quaternion targetRotation = Quaternion.LookRotation(newTargetPoint - transform.position);
                transform.rotation = targetRotation;

                markerClone.transform.position = targetPosition;
                markerClone.transform.rotation = markerRotation;
                markerClone.renderer.enabled = true;

                //sets positions for line renderer
                targetLine.SetPosition(0, transform.position);
                targetLine.SetPosition(1, hit.point);
            }
        }
    }

    /// <summary>
    /// sets location for where player will move
    /// <remarks>for using with games requiring plane raycast</remarks>
    /// </summary>
    void SetTargetLocation()
    {
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

    /// <summary>
    /// move player to target location
    /// <remarks>moves player based on frames</remarks>
    /// </summary>
    void MovePartnerToTargetLocation()
    {
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

    /// <summary>
    /// decreases enemy movement distance, movement speed
    /// </summary>
    public void ReducePlayerMovement()
    {
        speed -= .1f * initSpeed;
        travelDistance -= .1f * initTravelDistance;
        print("Current speed: " + speed + "; Current travel distance: " + travelDistance);
    }

    void GameStart() { }
    void GameOver() { }
}