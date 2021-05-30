using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    public void ChangeScore()
    {
        score += 1;
        text.text = "Collected objects: " + score.ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        // TODO: add checking position of the player and else section - winning the game
        if (!Timer.instance.timerIsRunning && score < 4)
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
    }
}
