using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void Update()
    {
        
    }

    public void updateHP(float damage)
    {
        StartCoroutine(hpUp((hp +  damage)));
    }

    public void updateHP_Reverse(float damage)
    {
       StartCoroutine( hpDown((hp - damage)));
    }

    IEnumerator hpUp(float target)
    {
        float nowhp = hp;
            for(int i=0;i<10;i++)
            {
                hp += (target - nowhp) / 10;
                hpbar.fillAmount = hp / 100;
                yield return new WaitForFixedUpdate();
            }
        
    }
    IEnumerator hpDown(float target)
    {
        float nowhp = hp;
        for (int i = 0; i < 10; i++)
        {
            hp-= (nowhp- target) / 10; 
            hpbar.fillAmount = hp / 100;
            yield return new WaitForFixedUpdate();
        }
        
    }


    public bool Result()
    {
        if (hp == 0)
            return true;
        else
            return false;
    }

}
