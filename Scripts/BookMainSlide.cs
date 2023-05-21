using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BookMainSlide : MonoBehaviour
{
    [SerializeField] GameObject NamesPanel;
    [SerializeField] GameObject BlindPanel;

    [SerializeField] GameObject ProfilePanel;

    public void Slide()
    {
        BlindPanel.SetActive(true);

        NamesPanel.transform.DOLocalMove(new Vector3(900, 0, 0),0.3f);
        //MainPanel.transform.DOLocalMove(new Vector3(-2000, 0, 0), 0.3f);

        ProfilePanel.transform.DOLocalMove(new Vector3(316, -152, 0), 0.3f);
    }

    public void SlideRe()
    {
        BlindPanel.SetActive(false);

        NamesPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f);

        ProfilePanel.transform.DOLocalMove(new Vector3(1500, -152, 0), 0.3f);
    }
}
