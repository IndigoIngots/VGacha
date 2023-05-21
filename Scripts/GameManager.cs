using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Scenetransition Transitions;
    [SerializeField] CharaDatas Datas;
    [SerializeField] CountData countScript;

    [SerializeField] GameObject PlayPanel;

    //アイテムがUIの前に来ないようにする為のレイヤー
    //これの子要素にアイテムを生成する
    [SerializeField] GameObject DisplayLayar;
    [SerializeField] GameObject BookPanel;
    [SerializeField] BookController bookController;

    [SerializeField] Character character;

    [SerializeField] private GameObject Circle;
    
    float counter = 60;

    bool isPlay = false;

    [SerializeField] GameObject itemSpace;
    [SerializeField] Text itemName;
    [SerializeField] Image itemSprite;

    [SerializeField] Text getNumberText;
    int getNumber;

    [SerializeField] List<GameObject> gotItems;

    // Start is called before the first frame update
    AudioSource audioSource;
    [SerializeField] AudioClip page;

    void Start()
    {
        character.touchItem += GetItem;
        character.addItem += AddItem;

        audioSource = GetComponent<AudioSource>();

        getNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay == true)
        { 
            counter += Time.deltaTime;
        
            if (counter > 0.25f)
            { 
                counter = 0.0f;

                GameObject Obj = Instantiate(Circle, new Vector3(0f, 3.0f, 0.0f), Quaternion.identity);
                Obj.transform.parent = DisplayLayar.transform;
                Item itemDataScript = Obj.GetComponent<Item>();

                int pickNum = Random.Range(0, Datas._charas.Count);
                itemDataScript.getInfo(Datas._charas[pickNum]);

                gotItems.Add(Obj);
            }
        }
    }

    public void PushPower()
    {
        if (isPlay == true)
        {
            isPlay = false;
        }
        else
        {
            isPlay = true;
        }
    }

    public void GetItem(string CharacterName, int CharacterNum, Sprite CharacterSprite)
    {
        Debug.Log(CharacterName);
        itemName.text = CharacterNum.ToString("D4") + ":" + CharacterName;
        itemSprite.sprite = CharacterSprite;

        itemSpace.transform.DOScale(new Vector3(1.2f, 1.2f, 1.0f), 0f);
        itemSpace.transform.DOScale(new Vector3(0.8f, 0.8f, 1.0f), 0.2f);

        getNumber++;
        getNumberText.text = "獲得した数:" + getNumber.ToString("D6");
    }

    public void AddItem(MyScriptableObject _data)
    {
        countScript.Counts[_data.CharaNumber - 1]++;
        countScript.SaveNums();
    }

    public void PushGoBook()
    {
        audioSource.PlayOneShot(page);
        Transitions.GoBook();
        Invoke("GoBook", 0.7f);
        isPlay = false;
        for (int i = 0; i < gotItems.Count; i++)
        {
            Destroy(gotItems[i]);
        }
        gotItems.Clear();
    }

    public void GoBook()
    {
        PlayPanel.SetActive(false);
        BookPanel.SetActive(true);
    }


    public void PushGoPlay()
    {
        audioSource.PlayOneShot(page);
        Transitions.GoHome();
        Invoke("GoPlay", 0.7f);
    }

    public void GoPlay()
    {     
        PlayPanel.SetActive(true);
        BookPanel.SetActive(false);
    }
}
