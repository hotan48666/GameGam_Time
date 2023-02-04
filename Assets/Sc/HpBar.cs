using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Transform enemy;

    void Update()
    {
        transform.position = enemy.position + new Vector3(0, 1.5f*enemy.transform.localScale.y, 0);
    }
}
