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


        //ù ī�尡 ����ٸ� 
        if (GameManager.instance.firstCard == null)
        {
            //ù ī�忡  ������ �Ѱ��ش�
            GameManager.instance.firstCard = this;
        }
        //ù ī�尡 ������� �ʴٸ�
        else
        {


            //�ι�° ī�忡 ������ �ѱ��
            GameManager.instance.secondCard = this;
            //Mached �Լ��� ȣ���� �ش�.
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
