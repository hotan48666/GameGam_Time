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
        Debug.Log("��������! ���ϵ帳�ϴ�");

        Time.timeScale = 0.0f;
        //Application.Quit();
    }
}
