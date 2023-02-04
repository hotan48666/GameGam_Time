using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Vector2 firstPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] bool Isclick;
    [SerializeField] bool IsNormal;
    public bool IsFire;
    [SerializeField] public int number;
    [SerializeField] private float damage;
    public AudioSource sound;
    public AudioSource soundR;
    PlayerAttack p;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        transform.position = endPosition;
        Isclick = false;
        IsNormal = false;
        if (IsFire)
            FireOn();
        else
            FireOff();
        sound = GetComponent<AudioSource>();
        soundR = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Isclick)
        {
            ReverseMove();
            if (Mathf.Abs(transform.position.x - firstPosition.x) <= 0.1f)
            {
                GameManager.instanceGM.countObj();
                Isclick = false;
            }
        }
        if (IsNormal)
        {
            
            Invoke("NormalMove", 0.5f);
            
            if (Mathf.Abs(transform.position.x - endPosition.x) <= 0.1f)
            {
                IsNormal = false;
                GameManager.instanceGM.LasAnimationFinished();
            }
        }
    }

    void SetAnim(bool check)
    {
        animator.SetBool("IsFire", check);
    }

    public void positionSet(Vector2 _firstPosition, Vector2 _endPosition)
    {
        firstPosition = _firstPosition;
        endPosition = _endPosition;
    }

    private void OnMouseDown()
    {
        Isclick = true;
        GameManager.instanceGM.MakeFuncArray(GameManager.Type.arrow, number);
    }

    void ReverseMove()
    {
        soundR.Play();
        transform.position = Vector2.Lerp(transform.position, firstPosition, Time.deltaTime * 2);
    }

    public void NormalMove()
    {
        sound.Play();
        p.AttackAnimationEnd();
        transform.position = Vector2.Lerp(transform.position, endPosition, Time.deltaTime * 2);
    }

    public void IsNormalChange()
    {
        IsNormal = true;
        p.AttackAnimation();
    }

    void FireOn()
    {
        IsFire = true;
        damage = 100;
        SetAnim(IsFire);
    }
    void FireOff()
    {
        IsFire = false;
        damage = 50;
        SetAnim(IsFire);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Fire")
        {
            if (IsFire)
            {
                FireOff();
            }
            else if (!IsFire)
            {
                FireOn();
            }

        }
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            if (Isclick)
                e.updateHP(damage);
            else if (IsNormal)
                e.updateHP_Reverse(damage);
        }
        if (collision.gameObject.tag == "Player")
        {
            p = collision.gameObject.GetComponent<PlayerAttack>();
            p.AttackAnimation();
            FireOff();
        }
    }


}
