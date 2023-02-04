using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireRotation : MonoBehaviour
{
    private float rotateSpeed = -150f;

    void RotationMove()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed,Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.z-270) >= 1f)
        {
            RotationMove();
        }
    }
}
