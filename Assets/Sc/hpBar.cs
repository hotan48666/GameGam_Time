using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBar : MonoBehaviour
{
    public static hpBar instance;
    public float hp;

    public bool fireTrig = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
        }
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
        if (fireTrig)
        {
            damage = 100;
        }
        hp += damage;
        print(hp);
    }


}