using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro textMesh;
    void Start()
    {
        textMesh = (TextMeshPro)GameObject.Find ("DebugText").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.SetText(MicInput.MicLoudness.ToString("n"));
    }
}
