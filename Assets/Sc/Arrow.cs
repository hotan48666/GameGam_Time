using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] Vector2 firstPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] bool Isclick;
    [SerializeField] bool IsNormal;
    [SerializeField] bool IsFire;
    [SerializeField] public int number;
    [SerializeField] private float damage;


    void Start()
    {
        transform.position = endPosition;
        Isclick = false;
        IsNormal = false;
        IsFire = true;
        damage = 100;
    }

    
    void Update()
    {
        if (Isclick)
        {
            ReverseMove();
            if (Mathf.Abs(transform.position.x - firstPosition.x) <= 0.1f)
                Isclick = false;
        }
        if (IsNormal)
        {
            NormalMove();
            if (Mathf.Abs(transform.position.x - endPosition.x) <= 0.1f)
            {
                IsNormal = false;
                GameManager.instanceGM.LasAnimationFinished();
            }
        }
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
        transform.position = Vector2.Lerp(transform.position, firstPosition, Time.deltaTime*2);
    }

    public void NormalMove()
    {
        transform.position = Vector2.Lerp(transform.position, endPosition, Time.deltaTime*2);
    }

    public void IsNormalChange()
    {
        IsNormal = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Fire")
        {
            if (IsFire)
            {
                IsFire = false;
                damage =50;
            }
            if (!IsFire)
            {
                IsFire = true;
                damage = 100;
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
        if(collision.gameObject.tag=="player")
        {
            damage = 50;
        }
    }

}
