using UnityEngine;
using System.Collections;

public class MouseWeapon : MonoBehaviour
{

    public Texture mouseCrosshair;
    public float crosshairWidth = 16;
    public float crosshairHeight = 16;

    public float depth = 5.0f;

    public GameObject projectilePrefab;
    Rect mouseArea;

    // Use this for initialization
    void Start()
    {
        Screen.showCursor = false;
    }

    void Update()
    {
        MoveCursorEmitter();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            transform.rotation = Quaternion.LookRotation(-hit.point);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        audio.Play();
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    void MoveCursorEmitter()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        transform.position = wantedPos;
    }

    void OnGUI()
    {
        mouseArea = new Rect(Event.current.mousePosition.x - crosshairWidth / 2,
                             Event.current.mousePosition.y - crosshairHeight / 2,
                             crosshairWidth, crosshairHeight);
        GUI.DrawTexture(mouseArea, mouseCrosshair);
    }
}