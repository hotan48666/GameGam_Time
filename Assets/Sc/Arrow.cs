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
        transform.position = endPosition;
        Isclick = false;

        damage = 30;
    }

    
    void Update()
    {
        if (Isclick)
            Clicked();
    }
    public void positionSet(Vector2 _firstPosition, Vector2 _endPosition)
    {
        firstPosition = _firstPosition;
        endPosition = _endPosition;
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
