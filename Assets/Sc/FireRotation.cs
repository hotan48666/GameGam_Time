using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireRotation : MonoBehaviour
{

    public Animator animator;
    private float rotateSpeed = -90;
    private const float DOWNSTATE = -90.0f;
    private const float STANDSTATE = 0;
    [SerializeField] private bool Isclick;
    [SerializeField] private bool IsNormal;
    [SerializeField] public int number;

    public AudioSource sound;
    public AudioSource soundR;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, DOWNSTATE);
        Isclick = false;
        IsNormal = false;

        sound = GetComponent<AudioSource>();
        soundR = GetComponent<AudioSource>();
    }

    void RotationMove()
    {
        sound.Play();
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
    }

    void StandMove()
    {
        soundR.Play();
        transform.Rotate(0, 0, Time.deltaTime * -rotateSpeed, Space.Self);
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
        if (IsNormal)
        {
            StandMove();
            if (Mathf.Abs(transform.rotation.eulerAngles.z - 270) <= 90f)
            {
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
        IsNormal = true;

        GameManager.instanceGM.MakeFuncArray(GameManager.Type.fire, number);
    }

    public void IsNormalChange()
    {
        IsNormal = true;
    }


}


