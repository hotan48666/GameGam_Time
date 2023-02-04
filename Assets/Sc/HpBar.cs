using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Transform enemy;
    public Slider hpBar;
    public float maxHp;
    public float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.position + new Vector3(0, 0, 0);
        hpBar.value = currentHp/ maxHp;
    }
}
