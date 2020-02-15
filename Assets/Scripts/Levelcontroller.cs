using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelcontroller : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    int attackersAmount = 0;
    bool leveltimefinished = false;
    float waitToLoad = 4;

    private void Start()
    {
        winLabel.SetActive(false);
    }
    public void AttackersSpawned()
    {
        attackersAmount++;

    }

    public void AttackerDestroyed()
    {
        attackersAmount--;
        if (attackersAmount <= 0 && leveltimefinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        leveltimefinished = true;
        StopSpawners();
    }

    public void StopSpawners()
    {
        AttackerSpawner[] array = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner item in array)
        {
            item.StopSpawning();
        }
    }
}
