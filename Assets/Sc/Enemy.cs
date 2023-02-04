using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp;
    public Image hpbar;
    public Animator enemyAnimator;

    void Start()
    {
        hpbar.fillAmount = hp;
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("IsDeath", true);
    }

    private void Update()
    {
        
    }

    public void updateHP(float damage)
    {
        StartCoroutine(hpUp((hp +  damage)));
        enemyAnimator.SetBool("IsDeath", false);
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
        if(hp==0)
            enemyAnimator.SetBool("IsDeath", true);

    }


    public bool Result()
    {
        if (hp == 0)
        {
            StartCoroutine("FadeOut");
            return true;
        }
        else
            return false;
    }
    
    IEnumerator FadeOut()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.03f);
            s.color = new Color(s.color.r, s.color.g, s.color.b, fadeCount);
        }
        gameObject.SetActive(false);
        
    }
}
