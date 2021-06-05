using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int carried;
    public int stored;
    public TextMeshProUGUI textECTS;
    public int pointsECTS;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        pointsECTS = 30;
        textECTS.text = "ECTS: " + pointsECTS.ToString();

    }

    public void ChangeScore(int param)
    {
        if (param == 1)
        {
            carried += 1;
        }
        else
        {
            stored += carried;
            carried = 0;
        }

        text.text = "Carried at the moment: " + carried.ToString() + "   Stored in the chest: " + stored.ToString();
    }

    public void ChangeECTSPoints()
    {
        pointsECTS--;

        if (pointsECTS == 0)
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }

        textECTS.text = "ECTS: " + pointsECTS.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        // TODO: add checking position of the player and else section - winning the game
        if (!Timer.instance.timerIsRunning && stored < 4)
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
        if (stored == 4)
        {
            SceneManager.LoadScene("Scenes/YouWin");
        }
    }
}
