using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BookButton : MonoBehaviour
{
    [SerializeField] CountData count;
    [SerializeField] Image LockImage;

    [SerializeField] Image Jessi;

    [SerializeField] Image CharaImage;
    [SerializeField] Text CharaText;
    [SerializeField] Text CharaName;
    Sprite StandImage;

    MyScriptableObject charaData;

    //âÊñ Ç™ìÆÇ≠èàóù
    public delegate void Slide();
    public Slide slide;

    public delegate void Reflection(MyScriptableObject da);
    public Reflection reflection;

    public void PushButton()
    {
        slide();
        reflection(charaData);
    }

    public void DisplayStand()
    {
        if (Jessi.sprite != StandImage)
        {   
            Jessi.sprite = StandImage;
        }
            Jessi.gameObject.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0f);
            Jessi.gameObject.transform.DOScale(new Vector3(0.55f, 0.55f, 0.55f), 0.2f);
    }

    public void DisplayBunner(MyScriptableObject Data)
    {

        charaData = Data;

        int CounterA = Data.CharaNumber;
        int CounterB = CounterA - 1;
        int CounterC = count.Counts[CounterB];

        if (CounterC < 1)
        {
            LockImage.gameObject.SetActive(true);
        }
        else
        {

            LockImage.gameObject.SetActive(false);
        }



        StandImage = Data.StandImage;

        CharaImage.sprite = Data.PixelImage;
        CharaText.text = "No." + Data.CharaNumber.ToString("D4");
        CharaName.text = Data.CharaName;
    }
}
