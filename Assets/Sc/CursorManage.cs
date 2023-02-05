using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    // 변경할 커서
    public Texture2D chageCursor;
    //현재 커서
    public Texture2D originalCursor;

    public void OnMouseOver() // 마우스가 오버될때 호출 
    {
        //마우스의 커서를 변경
        Cursor.SetCursor(chageCursor, new Vector2(chageCursor.width / 3, 0), CursorMode.ForceSoftware);
    }

    public void OnMouseExit() //오버랩이 해체될때 
    {
        //원 커서로 변경
        Cursor.SetCursor(originalCursor, new Vector2(0, 0), CursorMode.ForceSoftware);
    }
}
