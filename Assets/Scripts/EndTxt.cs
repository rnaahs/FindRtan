using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReGame()
    {
        //AdsManager.I.ShowRewardAd();
        SceneManager.LoadScene("MainScene");
    }
}
