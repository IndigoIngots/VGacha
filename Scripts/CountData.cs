using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountData : MonoBehaviour
{
    public int[] Counts;

    void Awake()
    {
        for (int i = 0; i < Counts.Length; i++)
        {
            //Debug.Log(i);
            int key = i + 1;
            Counts[i] = PlayerPrefs.GetInt(key.ToString(), 0);
        }
    }

    public void SaveNums()
    {
        for (int i = 0; i < Counts.Length; i++)
        {
            int key = i + 1;
            PlayerPrefs.SetInt(key.ToString(),Counts[i]);
        }
    }
}
