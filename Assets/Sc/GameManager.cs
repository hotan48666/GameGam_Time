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
    Arrow[] a;
    FireRotation[] f;

    public enum Type {arrow, fire};
    List<KeyValuePair<Type,int>> ObjFunctionNum;

    bool IsLastAnimationFinished;

    public static GameManager instanceGM;
    

    void Awake()
    {
        if (instanceGM != this) { 
            instanceGM = this;
            DontDestroyOnLoad(gameObject);
        }

        IsLastAnimationFinished = false;
        ObjFunctionNum = new List<KeyValuePair<Type, int>>();

        a = new Arrow[arrowStartPos.Length];
        f = new FireRotation[fireStartPos.Length];
        for (int i = 0; i < arrowStartPos.Length; i++)
        {
            GameObject imsiArrow = Instantiate(arrowObj, arrowStartPos[i], Quaternion.Euler(0, 0, 0));
            a[i] = imsiArrow.GetComponent<Arrow>();
            a[i].positionSet(arrowStartPos[i],arrowEndPos[i]);
            a[i].number = i;
        }
        for (int i = 0; i < fireStartPos.Length; i++)
        {
            GameObject imsiFire = Instantiate(fireObj, fireStartPos[i], Quaternion.Euler(0, 0, 0));
            f[i] = imsiFire.GetComponent<FireRotation>();
            //f[i].positionSet(arrowStartPos[i], arrowEndPos[i]);
            f[i].number = i;
        }

    }


    void Update()
    {
        
    }


    public void MakeFuncArray(Type type, int num)
    {
        ObjFunctionNum.Insert(0,new KeyValuePair<Type, int>(type, num));
        foreach (KeyValuePair<Type,int> k in ObjFunctionNum)
        {
            Debug.Log(k.Key+";;"+k.Value);
        }
    }

    IEnumerator NormalPlay()
    {
        int i = 0;
        while(i<ObjFunctionNum.Count)
        {
            switch (ObjFunctionNum[i].Key)
            {
                case Type.arrow:
                    a[ObjFunctionNum[i].Value].IsNormalChange();
                    break;
                case Type.fire:
                    a[ObjFunctionNum[i].Value].IsNormalChange();
                    break;
            }

            yield return new WaitForFixedUpdate();
            if (IsLastAnimationFinished)
            {
                IsLastAnimationFinished = false;
                i++;
            }
        }
    }

    public void LasAnimationFinished()
    {
        IsLastAnimationFinished = true;
    }

    // Test Function
    public void startCor()
    {
        StartCoroutine(NormalPlay());
    }
}
