using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{

    [SerializeField] float speed = 9;
    [SerializeField] float deacceleration = 70;

    private bool grounded;

    private BoxCollider2D boxCollider;
    private SpriteRenderer man;

    private Vector2 position;

    public delegate void TouchItem(string Cname, int Cnum, Sprite Csprite);
    public TouchItem touchItem;

    public delegate void AddItem(MyScriptableObject Idata);
    public AddItem addItem;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip GetSE;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        man = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //-1‚©‚ç1‚Ü‚Å
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            position.x = speed * moveInput;
            _animator.SetBool("Walking", true);
        }
        else
        {
            position.x = Mathf.MoveTowards(position.x, 0, deacceleration * Time.deltaTime);
            _animator.SetBool("Walking", false);
        }

        transform.Translate(position * Time.deltaTime);


        if (Input.GetKeyDown("left"))
        {
            if (man.flipX == true)
            {
                transform.DOComplete();
                man.flipX = false;
                transform.DORotate(Vector3.up * -90f, 0f);
                transform.DORotate(Vector3.up * 0f, 0.5f);
            }

        }
        else if (Input.GetKeyDown("right"))
        {
            if (man.flipX == false)
            {
                transform.DOComplete();
                man.flipX = true;
                transform.DORotate(Vector3.up * 90f, 0f);
                transform.DORotate(Vector3.up * 0f, 0.5f);
            }
        }

        Vector3 pos = transform.position;
        pos.z = 0.0f;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
            Item _itemScript = col.GetComponent<Item>();

            if (_itemScript.touchBool == false)
            {
                audioSource.PlayOneShot(GetSE);

               _itemScript.getONOFF();

                addItem(_itemScript._itemInfo);
                touchItem(_itemScript._itemInfo.CharaName, _itemScript._itemInfo.CharaNumber, _itemScript._itemInfo.PixelImage);
            }

            Destroy(col.gameObject);
        }
    }
}
