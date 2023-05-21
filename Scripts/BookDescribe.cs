using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookDescribe : MonoBehaviour
{
    [SerializeField] GameObject URLButton;
    [SerializeField] GameObject URLPanel;

    [SerializeField] GameObject isChangePic;
    bool isChange = false;

    [Header("名前と番号")]
    [SerializeField] Text charaNumber;
    [SerializeField] Text charaName;

    [Header("画像")]
    [SerializeField] Image iconImage;
    [SerializeField] Image pixelImage;

    [Header("ハッシュタグ")]
    [SerializeField] Text tags;

    [Header("プロフ")]
    [SerializeField] Text gender;
    [SerializeField] Text age;
    [SerializeField] Text hometown;
    [SerializeField] Text hobby;
    [SerializeField] Text like;
    [SerializeField] Text dislike;
    [SerializeField] Text birthday;
    [SerializeField] Text height;
    [SerializeField] Text weight;
    [SerializeField] Text race;

    [Header("説明欄")]
    [SerializeField] Text charaDesc;

    public void Reflection(MyScriptableObject D)
    {
        charaName.text = D.CharaName;
        iconImage.sprite = D.IconImage;
        pixelImage.sprite = D.PixelImage;

        gender.text = D.Gender;
        age.text = D.Age;
        hometown.text = D.Hometown;
        hobby.text = D.Hobby;
        like.text = D.Like;
        dislike.text = D.Dislike;
        birthday.text = D.Birthday;
        height.text = D.Height;
        weight.text = D.Weight;
        race.text = D.Race;

        tags.text = D.Tags;

        string DescText = D.CharaDesc;
        DescText = DescText.Replace("\\n", "\n");

        charaDesc.text = DescText;

        foreach (Transform n in URLPanel.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

        if (D.Url1N != "なし")
        {
            GameObject Obj = (GameObject)Instantiate(URLButton, Vector3.zero, Quaternion.identity);
            Obj.transform.parent = URLPanel.transform;

            URLButton URLScript = Obj.GetComponent<URLButton>();
            URLScript.URL = D.Url1;

            Text text = Obj.transform.GetChild(0).GetComponent<Text>();
            text.text = D.Url1N;
        }

        if(D.Url2N != "なし")
        {
            GameObject Obj = (GameObject)Instantiate(URLButton, Vector3.zero, Quaternion.identity);
            Obj.transform.parent = URLPanel.transform;

            URLButton URLScript = Obj.GetComponent<URLButton>();
            URLScript.URL = D.Url2;

            Text text = Obj.transform.GetChild(0).GetComponent<Text>();
            text.text = D.Url2N;
        }

        if (D.Url3N != "なし")
        {
            GameObject Obj = (GameObject)Instantiate(URLButton, Vector3.zero, Quaternion.identity);
            Obj.transform.parent = URLPanel.transform;

            URLButton URLScript = Obj.GetComponent<URLButton>();
            URLScript.URL = D.Url3;

            Text text = Obj.transform.GetChild(0).GetComponent<Text>();
            text.text = D.Url3N;
        }

        if (D.Url4N != "なし")
        {
            GameObject Obj = (GameObject)Instantiate(URLButton, Vector3.zero, Quaternion.identity);
            Obj.transform.parent = URLPanel.transform;

            URLButton URLScript = Obj.GetComponent<URLButton>();
            URLScript.URL = D.Url4;

            Text text = Obj.transform.GetChild(0).GetComponent<Text>();
            text.text = D.Url4N;
        }
    }

    public void PushChange()
    {
        if (isChange == false)
        {
            isChangePic.SetActive(true);
            isChange = true;
        }
        else
        {
            isChangePic.SetActive(false);
            isChange = false;
        }
    }
}
