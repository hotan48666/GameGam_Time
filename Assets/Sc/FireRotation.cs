using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireRotation : MonoBehaviour
{

    public Animator animator;
    private float rotateSpeed = 90.0f;
    private const float DOWNSTATE = 270.0f;
    private const float STANDSTATE = 0;
    [SerializeField] private bool Isclick;
    [SerializeField] private bool IsNormal;
    public int number;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, DOWNSTATE);
        RotationIdle(true);
        Isclick = false;
        IsNormal = false;
    }

    void RotationMove()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
    }

    void StandMove()
    {
        transform.Rotate(0, 0, Time.deltaTime * -rotateSpeed, Space.Self);
    }

    void RotationIdle(bool swich)
    {
        animator.SetBool("IsRotation90", swich);
    }

    // Update is called once per frame
    void Update()
    {
        if (Isclick)
        {
            RotationMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - STANDSTATE) % 360 <= 1f)
            {
                RotationIdle(false);
                Isclick = false;
                
            }
            
        }

        if (IsNormal)
        {
            
            StandMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - DOWNSTATE) % 360 <= 1f)
            {
                RotationIdle(true);
                IsNormal = false;
                GameManager.instanceGM.LasAnimationFinished();
            }

        }


        if (Isclick)
        {
            RotationMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - 270) <= 1f)
                Isclick = false;
        }

       

        if (Mathf.Abs(transform.rotation.eulerAngles.z - 270) <= 1.0f
            && Mathf.Abs(transform.rotation.eulerAngles.z - 270) >= 0.1f)
        {
            RotationIdle(true);
        }
        else
        {
            RotationIdle(false);
        }

    }

    private void OnMouseDown()
    {

        Isclick = true;


        GameManager.instanceGM.MakeFuncArray(GameManager.Type.fire, number);
    }

    public void IsNormalChange()
    {
        IsNormal = true;
    }


}


