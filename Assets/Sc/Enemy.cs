using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public GameObject hpbar;

    void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateHP(float damage)
    {
        hp += damage;
        Debug.Log(hp);
    }

    public bool Result()
    {
        if (hp == 100)
            return true;
        else
            return false;
    }

}
