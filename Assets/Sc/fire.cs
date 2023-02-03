using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    [SerializeField] Vector2 firstPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] bool Isclick;

    private float damage;

    void Start()
    {
        firstPosition = new Vector2(8, 0); // ???? ?????? ???????? ???? ???? ????
        endPosition = new Vector2(2, 0); // ???? ???? ???? ????
        transform.position = endPosition;
        Isclick = false;

    }


    void Update()
    {
        if (Isclick)
            Clicked();
    }

    private void OnMouseDown()
    {
        Isclick = true;
        hpBar.instance.fireTrig = true;
    }

    void Clicked()
    {

        transform.position = Vector2.Lerp(transform.position, firstPosition, Time.deltaTime);
    }

}
