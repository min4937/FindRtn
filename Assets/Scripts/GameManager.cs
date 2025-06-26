using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;


    public Text timeTxt;
    public GameObject endTxt;

    public int cardCount = 0;

    public Text scoreTxt;

    float score = 0.0f;

    float time = 30.0f;

    AudioSource audioSource;
    public AudioClip clip;

    

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Time.timeScale = 1.0f;
        }
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        


        if (time < 0.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
           
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            //ÆÄ±«ÇØ¶ó
            audioSource.PlayOneShot(clip);
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;

            score += 1;
            scoreTxt.text = score.ToString(score+"Á¡");
            
             
             
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(false);
            }
        }
        else
        {
            //´Ý¾Æ¶ó
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        

        firstCard = null;
        secondCard = null;
    }
}
