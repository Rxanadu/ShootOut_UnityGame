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
        transform.rotation = Camera.main.transform.rotation;
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