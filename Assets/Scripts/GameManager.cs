using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject card;
    public Text timeTxt;
    public GameObject endTxt;
    float time;
    public static GameManager I;
    public AudioClip match;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        I = this;
    }
    void Start()
    {
        Time.timeScale = 1.0f;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if(time >= 30)
        {
            GameEnd();
        }
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);
            firstCard.GetComponent<Card>().destroyCard();
            secondCard.GetComponent<Card>().destroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            if(cardsLeft == 2)
            {
                Invoke("GameEnd", 1.0f);
            }
        }
        else
        {
            firstCard.GetComponent<Card>().closeCard();
            secondCard.GetComponent<Card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    public void GameEnd()
    {
        //게임 종료
        Time.timeScale = 0f;
        endTxt.SetActive(true);
    }
    
    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
