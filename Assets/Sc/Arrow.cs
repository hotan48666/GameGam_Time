using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] Vector2 firstPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] bool Isclick;
    
    private float damage;

    void Start()
    {
        firstPosition = new Vector2(-8,0); // ???? ?????? ???????? ???? ???? ????
        endPosition = new Vector2(9,0); // ???? ???? ???? ????
        transform.position = endPosition;
        Isclick = false;

        damage = 30;
    }

    
    void Update()
    {
        if (Isclick)
            Clicked();
    }

    private void OnMouseDown()
    {
        Isclick = true;
        hpBar.instance.updateHP(damage);
    }

    void Clicked()
    {
        
        transform.position = Vector2.Lerp(transform.position, firstPosition, Time.deltaTime);
    }



}
