using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject arrowObj;
    public GameObject fireObj;
    public Vector2[] arrowStartPos;
    public Vector2[] arrowEndPos;
    public bool[] arrowFire;
    public Vector2[] firePos;

    Arrow[] a;
    FireRotation[] f;

    public Enemy e;
    int count;
    public GameObject nextUI;
    public GameObject failUI;

    public enum Type {arrow, fire};
    List<KeyValuePair<Type,int>> ObjFunctionNum;

    bool IsLastAnimationFinished;

    public static GameManager instanceGM;
     

    void Awake()
    {
        if (instanceGM != this) { 
            instanceGM = this;
            //DontDestroyOnLoad(gameObject);
        }

        nextUI.SetActive(false);
        failUI.SetActive(false);
        IsLastAnimationFinished = false;
        ObjFunctionNum = new List<KeyValuePair<Type, int>>();

        a = new Arrow[arrowStartPos.Length];
        f = new FireRotation[firePos.Length];
        for (int i = 0; i < arrowStartPos.Length; i++)
        {
            GameObject imsiArrow = Instantiate(arrowObj, arrowStartPos[i], Quaternion.Euler(0, 0, 0));
            a[i] = imsiArrow.GetComponent<Arrow>();
            a[i].positionSet(arrowStartPos[i],arrowEndPos[i]);
            a[i].number = i;
            a[i].IsFire = arrowFire[i];
        }
        for (int i = 0; i < firePos.Length; i++)
        {
            GameObject imsiFire = Instantiate(fireObj, firePos[i], Quaternion.Euler(0, 0, 0));
            f[i] = imsiFire.GetComponent<FireRotation>();
            f[i].number = i;
        }

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
                    f[ObjFunctionNum[i].Value].IsNormalChange();
                    break;
            }

            yield return new WaitForFixedUpdate();
            if (IsLastAnimationFinished)
            {
                IsLastAnimationFinished = false;
                i++; 
            }
        }

        if (e.Result())
        {
            Debug.Log("성공!");
            nextUI.SetActive(true);
        }
        else
        {
            Debug.Log("실패!");
            failUI.SetActive(true);
            Invoke("Retry", 2.0f);
        }
    }



    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LasAnimationFinished()
    {
        IsLastAnimationFinished = true;
    }


    public void countObj()
    {
        count++;
        if (count >= firePos.Length + arrowStartPos.Length)
            Invoke("startCor", 1.0f);
    }
    // Test Function
    public void startCor()
    {
        StartCoroutine(NormalPlay());
    }

    public void SecondStage()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void FinalStage()
    {
        SceneManager.LoadScene("FinalScene");
    }
    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }
}
