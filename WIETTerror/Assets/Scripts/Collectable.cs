using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    
    [SerializeField] private AudioSource heal;
    [SerializeField] private AudioSource minus;
    [SerializeField] private AudioSource openCHest;
    [SerializeField] private AudioSource collect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(other.gameObject);
            collect.Play();
        }

        if (other.gameObject.tag == "Chest")
        {
            Debug.Log("wrzuca do skrzynki...");
            ScoreManager.instance.ChangeScore(0); 
            openCHest.Play();
        }

        if (other.gameObject.tag == "minusECTS")
        {
            ScoreManager.instance.ChangeECTSPoints();
            Destroy(other.gameObject);
            minus.Play();
        }
        if (other.gameObject.tag == "plusECTS")
        {
            ScoreManager.instance.AddECTSPoints();
            Destroy(other.gameObject);
            heal.Play();
        }

        /*
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
        */
    }
}