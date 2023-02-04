using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireRotation : MonoBehaviour
{

    public Animator animator;
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
    void RotationIdle(bool swich)
    {
        if (swich)
        {
            animator.SetBool("IsRotation90", swich);
        }
        else
        {
            animator.SetBool("IsRotation90", swich);
        }
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

        if (Mathf.Abs(transform.rotation.eulerAngles.z - 270) >= 0.7f)
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


