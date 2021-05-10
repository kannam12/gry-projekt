using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        
    }
}
