using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerUI : MonoBehaviour
{
    [SerializeField] Cubelet playerCubelet;
    [SerializeField] int score = 0;
    [SerializeField] public int health = 3;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI healthText;
    [SerializeField] TMPro.TextMeshProUGUI gameOverText;

    void Start(){
        scoreText.text = "Score: " + score;
        healthText.text = "HP: " + health;
        gameOverText.gameObject.SetActive(false);
        gameOverText.text = "Game Over";
    }


    public void increaseScore(){
        score++;
        scoreText.text = "Score: " + score;
    }

    public void decreaseHealth(){
        health--;
        healthText.text = "HP: " + health;
        if(health <= 0){
            gameOverText.gameObject.SetActive(true);
            playerCubelet.Die();
        }
    }
    public void increaseHealth(){
        health++;
        healthText.text = "HP: " + health;
    }



}
