using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDatas : MonoBehaviour
{
    public List<MyScriptableObject> _charas;

    public void MakeCharaData()
    {
        int i = 0;
        while (true)
        {
            Debug.Log(i);
            MyScriptableObject Obj = (MyScriptableObject)Resources.Load("CharaDatas/" + (i + 1).ToString());

            if (Obj == null)
            {
                break;
            }

            _charas.Add(Obj);

            Obj = null;

            i++;
        }
    }
}
