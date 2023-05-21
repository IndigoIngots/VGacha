using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CSVReader : MonoBehaviour
{
    [SerializeField] bool isGenerate;
    [SerializeField] bool isStorage;

    const string SHEET_ID = "1vy-WDS0dETXD-m43MVcZVv68cEY61Fg6dc14alQiSHc";
    const string SHEET_NAME = "�V�[�g1";

    [SerializeField] CharaDatas Datas;

    void Awake()
    {
        if (isGenerate == true)
        {
            StartCoroutine(Method(SHEET_NAME));
        }
        else 
        { 
            if(isStorage == true) Datas.MakeCharaData();
        }
    }

    IEnumerator Method(string _SHEET_NAME)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();


        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            List<string[]> characterDataArrayList = ConvertToArrayListFrom(request.downloadHandler.text);
            foreach (string[] characterDataArray in characterDataArrayList)
            {
                CharacterData characterData = new CharacterData(characterDataArray);
                characterData.DebugParametaView();
            }
        }

        //yield return new WaitForSeconds(1);
        if (isStorage == true) Datas.MakeCharaData();
    }

    List<string[]> ConvertToArrayListFrom(string _text)
    {
        List<string[]> characterDataArrayList = new List<string[]>();
        StringReader reader = new StringReader(_text);
        reader.ReadLine();  // 1�s�ڂ̓��x���Ȃ̂ŊO��
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();        // ��s���ǂݍ���
            string[] elements = line.Split(',');    // �s�̃Z����,�ŋ�؂���
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == "\"\"")
                {
                    continue;                       // �󔒂͏���
                }
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            characterDataArrayList.Add(elements);
        }
        return characterDataArrayList;
    }
}