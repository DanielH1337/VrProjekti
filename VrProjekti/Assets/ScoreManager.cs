using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject ammuttuTeksti;
    public TMP_Text scoreText;
    int score = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    public void AddPoint()
    {
        if(score >= 5)
        {
            scoreText.text = "Peli läpi";
            ammuttuTeksti.SetActive(false);
        }
        else
        {
            score += 1;
            scoreText.text = score.ToString();
        }
      

    }
}
