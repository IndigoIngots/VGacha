using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] CharaDatas Datas;
    [SerializeField] BookMainSlide bookMainSlide;
    [SerializeField] BookDescribe bookDescribe;

    [SerializeField] Button firstButton;
    [SerializeField] BookButton[] Buttons;
    int Count = 0;

    [SerializeField] Text Counter;
    int MainCount;
    [SerializeField] int AllCount;

    bool isDesc = false;

    // Start is called before the first frame update
    void Start()
    {
        //firstButton.Select();

        for (int i = 0; i < 10; i++)
        {
            Buttons[i].slide += SlidePanel;
            Buttons[i].reflection += Reflection;
        }

        Sort();
    }

    void OnEnable()
    {
        Sort();
    }

    //各キャラボタンから呼び出される
    public void Reflection(MyScriptableObject da)
    {
        bookDescribe.Reflection(da);
    }

    public void SlidePanel()
    {
        bookMainSlide.Slide();
        isDesc = true;
    }

    //戻る
    public void SlidePanelRe()
    {
        bookMainSlide.SlideRe();      
    }

    void Update()
    { 
    
    }

    public void Prus1()
    {
        if (MainCount != AllCount)
        {
            Count++;
            Sort();
        }
    }

    public void Minus1()
    {
        if (Count > 0)
        {
            Count--;
            Sort();
        }
    }

    public void Sort()
    {
        for (int i = 0; i < 10; i++)
        {
            int Num = Count * 10 + i;
            Buttons[i].DisplayBunner(Datas._charas[Num]);
        }
        MainCount = Count + 1;
        Counter.text = MainCount.ToString("D2") + "/" + AllCount.ToString("D2");
    }

    public void BackButton()
    {

        if (isDesc == false)
        {
            gameManager.PushGoPlay();
        }
        else
        {
            SlidePanelRe();
            isDesc = false;
        }
    }
}
