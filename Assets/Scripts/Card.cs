using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;



    public SpriteRenderer frontlmage;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        frontlmage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);


        //첫 카드가 비었다면 
        if (GameManager.instance.firstCard == null)
        {
            //첫 카드에  정보를 넘겨준다
            GameManager.instance.firstCard = this;
        }
        //첫 카드가 비어있지 않다면
        else
        {


            //두번째 카드에 정보를 넘긴다
            GameManager.instance.secondCard = this;
            //Mached 함수를 호출해 준다.
            GameManager.instance.Matched();

        }
    }

    public void DestoryCard()
    {
        Invoke("DestroyCardlnvoke", 0.5f);
    }


    void DestroyCardlnvoke()
    {
        Destroy(gameObject);
    }


    public void CloseCard()
    {
        Invoke("CloseCardlnvoke", 0.5f);
    }


    void CloseCardlnvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

}
