using UnityEngine;
using System.Collections;

/// <summary>
/// destroys an object after a specified time
/// @Usage: place on objects you wish to destroy after 
/// some time has passed
/// </summary>
public class DestroyByTime : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}