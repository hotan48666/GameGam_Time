using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireRotation : MonoBehaviour
{

    
    private float rotateSpeed = -150f;
    [SerializeField] private bool Isclick;
    [SerializeField] private bool IsNormal;
    [SerializeField] public int number;

    void RotationMove()
    {
        Isclick = false;
        IsNormal = false;
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed,Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (Isclick && Mathf.Abs(transform.rotation.eulerAngles.z-270) >= 1f)
        {
            RotationMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - 270) <= 1f)
                Isclick = false;
        }
    }

    public void IsNormalChange()
    {
        IsNormal = true;
    }

}


