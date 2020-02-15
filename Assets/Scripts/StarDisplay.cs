using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 10000;
    Text starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        updateDisplay();
    }
    private void updateDisplay()
    {
        starText.text = stars.ToString();
    }
    public void AddStars(int amount)
    {
        stars += amount;
        updateDisplay();
    }

    public void RemoveStars(int amount)
    {
        stars -= amount;
        updateDisplay();
    }

    public int GetStars()
    {
        return stars;
    }

}
