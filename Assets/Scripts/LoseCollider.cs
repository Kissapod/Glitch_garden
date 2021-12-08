using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour
{
    private Text healthText;
    private float difficulty;
    private int health;
    private void Start()
    {
        difficulty = PlayerPrefsManager.GetDifficulty();
        healthText = GameObject.Find("HealthDisplay").GetComponent<Text>();
        if (difficulty == 1f)
        {
            health = 10;
        } else if (difficulty == 2f)
        {
            health = 5;
        } else if (difficulty == 3f)
        {
            health = 1;
        }
        healthText.text = health.ToString();
    }
    void Lose()
    {
        LevelManager man = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        man.LoadLevel("03b Lose");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            health -= 1;
            UpdateDisplay();
            if (health <= 0 || collision.gameObject.GetComponent<JabbaWomen>())
            {
                Lose();
            }
        }
        Destroy(collision.gameObject);
    }
    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
}
