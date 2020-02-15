using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 5f;
    float lives = 25f;
    [SerializeField] int damage = 1;
    Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        updateDisplay();
    }
    private void updateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void RemoveLives()
    {
        lives -= damage;
        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }
        updateDisplay();
    }
}
