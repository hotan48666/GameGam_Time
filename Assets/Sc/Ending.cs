using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    Animator a;
    void Start()
    {
        a = GetComponent<Animator>();
        a.SetBool("Ending",true);
        Invoke("off", 4.5f);
    }

    void off()
    {
        Debug.Log("게임종료! 축하드립니다");

        
        Application.Quit();
    }
}
