using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject arrowObj;
    public GameObject fireObj;
    public Vector2[] arrowStartPos;
    public Vector2[] arrowEndPos;
    public Vector2[] fireStartPos;
    public Vector2[] fireEndPos;
    Arrow a;
    


    void Start()
    {
        for (int i = 0; i < arrowStartPos.Length; i++)
        {
            GameObject imsiArrow = Instantiate(arrowObj, arrowStartPos[i], Quaternion.Euler(0, 0, 0));
            a = imsiArrow.GetComponent<Arrow>();
            a.positionSet(arrowStartPos[i],arrowEndPos[i]);
        }
        for (int i = 0; i < fireStartPos.Length; i++)
        {
            GameObject imsiFire = Instantiate(fireObj, fireStartPos[i], Quaternion.Euler(0, 0, 0));
        }

    }


    void Update()
    {
        
    }
}
