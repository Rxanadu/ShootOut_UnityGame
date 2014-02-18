using UnityEngine;
using System.Collections;

/// <summary>
/// zooms camera in and out depending on camera's field of view or orthographic size
/// <remarks>place this script on object with camera component</remarks> 
/// </summary>
public class CameraZoom : MonoBehaviour {
    public float speed;
    public float minZoom, maxZoom;

	void Update () {
        ZoomCamera();
	}

    void ZoomCamera()
    {
        float step = speed * Time.deltaTime;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (camera.orthographic)
                camera.orthographicSize = Mathf.Min(camera.orthographicSize - 1, 6);
            else
                camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, maxZoom, step);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (camera.orthographic)
                camera.orthographicSize = Mathf.Max(camera.orthographicSize - 1, 1);
            else
                camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, minZoom, step);
        }
    }
}
