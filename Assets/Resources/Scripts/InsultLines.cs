using UnityEngine;
using System.Collections;
using System.IO;

public class InsultLines : MonoBehaviour
{
    public string[] insults;
    TextMesh insultText;

    void Awake()
    {
        insultText = GetComponent<TextMesh>();
        insultText.text = insults[Random.Range(0, insults.Length)];
    }

    void Update()
    {        
        transform.rotation = Camera.main.transform.rotation;
    }
}