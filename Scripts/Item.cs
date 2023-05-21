using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public MyScriptableObject _itemInfo;
    SpriteRenderer spriteRenderer;

    public bool touchBool = false;

    void Awake()
    {
        var x = Random.Range(-4.0f, 4.0f);
        var y = Random.Range(3.0f, 6.0f);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>(); 
        Vector3 force = new Vector3(x, y, 0.0f); 
        rb.AddForce(force, ForceMode2D.Impulse);

        float z = Random.Range(-45, 45);
        transform.Rotate(0, 0, z);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void getInfo(MyScriptableObject _item)
    {
        _itemInfo = _item;
        spriteRenderer.sprite = _itemInfo.PixelImage;
    }

    public void getONOFF()
    {
        touchBool = true;
    }
}
