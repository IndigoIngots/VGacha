using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

//ビルドの時には一部コメント化する

public class CharacterData
{
    int id;
    string name;
    string ruby;
    [TextArea]
    string tags;
    string gender;
    string age;
    string hometown;
    string hobby;
    string like;
    string dislike;
    string birthday;
    string height;
    string weight;
    string race;

    [TextArea]
    string charaDesc;

    string url1;
    string url1N;
    string url2;
    string url2N;
    string url3;
    string url3N;
    string url4;
    string url4N;

    Sprite pixelImage;
    Sprite standImage;
    Sprite iconImage;

    public CharacterData(string[] _dataList)
    {
        id = int.Parse(_dataList[0]);
        name = _dataList[1];
        ruby = _dataList[2];
        tags = _dataList[3];
        gender = _dataList[4];
        age = _dataList[5];
        hometown = _dataList[6];
        hobby = _dataList[7];
        like = _dataList[8];
        dislike = _dataList[9];
        birthday = _dataList[10];
        height = _dataList[11];
        weight = _dataList[12];
        race = _dataList[13];

        charaDesc = _dataList[14];

        url1 = _dataList[15];
        url1N = _dataList[16];
        url2 = _dataList[17];
        url2N = _dataList[18];
        url3 = _dataList[19];
        url3N = _dataList[20];
        url4 = _dataList[21];
        url4N = _dataList[22];

        pixelImage = Resources.Load<Sprite>("charaPixelImage/" + "Pixel (" + id.ToString() + ")");
        //standImage = Resources.Load<Sprite>("charaStandImage/" + id.ToString() + "Stand");
        //iconImage = Resources.Load<Sprite>("charaIconImage/" + id.ToString() + "Icon");

        standImage = Resources.Load<Sprite>("charaStandImage/1Stand");
        iconImage = Resources.Load<Sprite>("charaIconImage/1Icon");
    }

    public void DebugParametaView()
    {
        //Debug.Log(String.Format("id:{0} name{1} tags:{2} gender:{3}", id, name, tags, gender));
        CreateScriptableObject();
    }

    void CreateScriptableObject()
    {
        var obj = ScriptableObject.CreateInstance<MyScriptableObject>();
        
        obj.CharaNumber = id;
        obj.CharaName = name;
        obj.CharaRuby = ruby;
        obj.Tags = tags;
        obj.Gender = gender;
        obj.Age = age;
        obj.Hometown = hometown;
        obj.Hobby = hobby;
        obj.Like = like;
        obj.Dislike = dislike;
        obj.Birthday = birthday;
        obj.Height = height;
        obj.Weight = weight;
        obj.Race = race;
        obj.CharaDesc = charaDesc;

        obj.PixelImage = pixelImage;
        obj.StandImage = standImage;
        obj.IconImage = iconImage;

        obj.Url1 = url1;
        obj.Url1N = url1N;
        obj.Url2 = url2;
        obj.Url2N = url2N;
        obj.Url3 = url3;
        obj.Url3N = url3N;
        obj.Url4 = url4;
        obj.Url4N = url4N;



        var fileName = $"{id.ToString()}.asset";
        var path = "Assets/Resources/CharaDatas";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        AssetDatabase.CreateAsset(obj, Path.Combine(path, fileName));
    }

    private static string TypeNameToString(string type)
    {
        var typeParts = type.Split(new char[] { '.' });
        if (!typeParts.Any())
            return string.Empty;

        var words = Regex.Matches(typeParts.Last(), "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
            .OfType<Match>()
            .Select(match => match.Value)
            .ToArray();
        return string.Join(" ", words);
    }
}