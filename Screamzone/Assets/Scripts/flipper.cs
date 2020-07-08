using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipper : MonoBehaviour
{
    // Start is called before the first frame update
    float modifiedRotateVal = 0;
    float baseRotation = 0;
    private Rigidbody rb;
    Vector3 m_EulerAngleVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        baseRotation = gameObject.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = MicInput.PeakMicLoudness;

        modifiedRotateVal = (rotate * 100);

        else
        {
            float currentRotation = (gameObject.transform.eulerAngles.z < 0 ? -gameObject.transform.eulerAngles.z : gameObject.transform.eulerAngles.z);
            
            if ( currentRotation >= 30 && currentRotation <= 300)
            {
                Debug.Log( currentRotation );
                modifiedRotateVal = 0;
            }
            Vector3 m_EulerAngleVelocity = new Vector3(0, 0, -(modifiedRotateVal));
            //rb.AddTorque(0, 0, (modifiedRotateVal));
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
