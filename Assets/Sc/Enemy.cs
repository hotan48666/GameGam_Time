using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp;
    public Image hpbar;

    void Start()
    {
        hpbar.fillAmount = hp;
    }

    public void updateHP(float damage)
    {
        hp += damage;
        hpbar.fillAmount += damage;
    }

    public void updateHP_Reverse(float damage)
    {
        hp -= damage;
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
