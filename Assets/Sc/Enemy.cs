using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp;
    public Image hpbar;

    void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        hpbar.fillAmount = hp;

        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void updateHP(float damage)
    {
        hp += damage;
        Debug.Log(hp);
        hpbar.fillAmount += damage;
    }

    public void updateHP_Reverse(float damage)
    {
        hp -= damage;
        Debug.Log(hp);
        hpbar.fillAmount -= damage;
    }

    public bool Result()
    {
        if (hp == 100)
            return true;
        else
            return false;
    }

}
