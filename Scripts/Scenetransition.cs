using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Scenetransition : MonoBehaviour
{

    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Panel3;

    public void GoBook()
    {
        Panel1.transform.DOLocalMoveX(-1500f, 0f);
        Panel2.transform.DOLocalMoveX(-1500f, 0f);
        Panel3.transform.DOLocalMoveX(-1500f, 0f);

        Invoke("Move1", 0.0f);
        Invoke("Move2", 0.1f);
        Invoke("Move3", 0.2f);

        Invoke("Move1END", 0.8f);
        Invoke("Move2END", 0.9f);
        Invoke("Move3END", 1.0f);
    }

    void Move1()
    {
        Panel1.transform.DOLocalMoveX(0f, 0.5f);
    }

    void Move2()
    {
        Panel2.transform.DOLocalMoveX(0f, 0.5f);
    }

    void Move3()
    {
        Panel3.transform.DOLocalMoveX(0f, 0.5f);
    }

    void Move1END()
    {
        Panel1.transform.DOLocalMoveX(1500f, 0.5f);
    }

    void Move2END()
    {
        Panel2.transform.DOLocalMoveX(1500f, 0.5f);
    }

    void Move3END()
    {
        Panel3.transform.DOLocalMoveX(1500f, 0.5f);
    }

    public void GoHome()
    {
        Panel1.transform.DOLocalMoveX(1500f, 0f);
        Panel2.transform.DOLocalMoveX(1500f, 0f);
        Panel3.transform.DOLocalMoveX(1500f, 0f);

        Invoke("Move1", 0.0f);
        Invoke("Move2", 0.1f);
        Invoke("Move3", 0.2f);

        Invoke("Move1BEND", 0.8f);
        Invoke("Move2BEND", 0.9f);
        Invoke("Move3BEND", 1.0f);
    }

    void Move1BEND()
    {
        Panel1.transform.DOLocalMoveX(-1500f, 0.5f);
    }

    void Move2BEND()
    {
        Panel2.transform.DOLocalMoveX(-1500f, 0.5f);
    }

    void Move3BEND()
    {
        Panel3.transform.DOLocalMoveX(-1500f, 0.5f);
    }

}
