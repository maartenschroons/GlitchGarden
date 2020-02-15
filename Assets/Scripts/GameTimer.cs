using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float baseLevelTime = 50f;
    float levelTime;
    bool triggeredLevelFinish = false;

    private void Start()
    {
        levelTime = baseLevelTime + (PlayerPrefsController.GetDifficulty() * 25);
    }

    void Update()
    {
        if (triggeredLevelFinish) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<Levelcontroller>().LevelTimerFinished();
            triggeredLevelFinish = true;
        }
    }
}
