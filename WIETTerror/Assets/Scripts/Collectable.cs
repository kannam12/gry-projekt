using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Chest")
        {
            Debug.Log("wrzuca do skrzynki...");
            ScoreManager.instance.ChangeScore(0);          
        }

        if (other.gameObject.tag == "minusECTS")
        {
            ScoreManager.instance.ChangeECTSPoints();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
    }
}