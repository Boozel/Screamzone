using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_player : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    private float velR = 0.01f;
    private float velD = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0.1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(velR, 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Win/loss
        if(collision.gameObject.transform.name == "killplane")
        {
            audioSource.PlayOneShot(audioClipArray[0]);
        }
        else if(collision.gameObject.transform.name == "rail2")
        {
            audioSource.PlayOneShot(audioClipArray[1]);
        }
    }
}
