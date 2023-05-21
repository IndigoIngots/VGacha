using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScriptableObject : ScriptableObject
{
    [Header("名前と番号")]
    [SerializeField] int charaNumber;
    [SerializeField] string charaName;
    [SerializeField] string charaRuby;

    [Header("ハッシュタグ")]
    [SerializeField]
    [TextArea] string tags;

    [Header("プロフ")]
    [SerializeField] string gender;
    [SerializeField] string age;
    [SerializeField] string hometown;
    [SerializeField] string hobby;
    [SerializeField] string like;
    [SerializeField] string dislike;
    [SerializeField] string birthday;
    [SerializeField] string height;
    [SerializeField] string weight;
    [SerializeField] string race;

    [Header("説明欄")]
    [SerializeField]
    [TextArea] string charaDesc;

    [Header("URL")]
    [SerializeField] string url1;
    [SerializeField] string url1N;
    [SerializeField] string url2;
    [SerializeField] string url2N;
    [SerializeField] string url3;
    [SerializeField] string url3N;
    [SerializeField] string url4;
    [SerializeField] string url4N;

    [Header("画像")]
    [SerializeField] Sprite pixelImage;
    [SerializeField] Sprite standImage;
    [SerializeField] Sprite iconImage;


    public int CharaNumber  { get => charaNumber; set => charaNumber = value;}
    public string CharaName { get => charaName; set => charaName = value; }
    public string CharaRuby { get => charaRuby; set => charaRuby = value; }
    public string Tags { get => tags; set => tags = value; }
    public string Gender { get => gender; set => gender = value; }
    public string Age { get => age; set => age = value; }
    public string Hometown { get => hometown; set => hometown = value; }
    public string Hobby { get => hobby; set => hobby = value; }
    public string Like { get => like; set => like = value; }
    public string Dislike { get => dislike; set => dislike = value; }
    public string Birthday { get => birthday; set => birthday = value; }
    public string Height { get => height; set => height = value; }
    public string Weight { get => weight; set => weight = value; }
    public string Race { get => race; set => race = value; }
    public string CharaDesc { get => charaDesc; set => charaDesc = value; }

    public string Url1 { get => url1; set => url1 = value; }
    public string Url1N { get => url1N; set => url1N = value; }
    public string Url2 { get => url2; set => url2 = value; }
    public string Url2N { get => url2N; set => url2N = value; }
    public string Url3 { get => url3; set => url3 = value; }
    public string Url3N { get => url3N; set => url3N = value; }
    public string Url4 { get => url4; set => url4 = value; }
    public string Url4N { get => url4N; set => url4N = value; }

    public Sprite PixelImage { get => pixelImage; set => pixelImage = value; }
    public Sprite StandImage { get => standImage; set => standImage = value; }
    public Sprite IconImage { get => iconImage; set => iconImage = value; }
}
