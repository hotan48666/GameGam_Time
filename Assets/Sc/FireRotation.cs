using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireRotation : MonoBehaviour
{

    public Animator animator;
    private float rotateSpeed = -90;
    private const float DOWNSTATE = 270.0f;
    private const float STANDSTATE = 0;
    [SerializeField] private bool Isclick;
    [SerializeField] private bool IsNormal;
    [SerializeField] public int number;

    private bool FireObjClearYn = false;
    public AudioSource sound;
    public AudioSource soundR;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, DOWNSTATE);
        RotationIdle(true);
        Isclick = false;
        IsNormal = false;
        sound = GetComponent<AudioSource>();
        soundR = GetComponent<AudioSource>();
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
            StandMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - STANDSTATE) % 360 <= 1f)
            {
                Isclick = false;
                RotationIdle(false);
                GameManager.instanceGM.countObj();
            }
        }

        if (IsNormal)
        {
            RotationMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - DOWNSTATE) <= 1f)
            {
                IsNormal = false;
                RotationIdle(true);
                GameManager.instanceGM.LasAnimationFinished();
            }
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


