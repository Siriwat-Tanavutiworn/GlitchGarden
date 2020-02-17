using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject LoseLabel;
    [SerializeField] float timeBeforeLoad = 5f;

    int numberOfAttacker = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        LoseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttacker--;
        if (numberOfAttacker <= 0 && levelTimerFinished && FindObjectOfType<HealthDisplay>().GetHealth() > 0)
        {
            StartCoroutine(HandlerWinCondition());
        }
    }

    IEnumerator HandlerWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeBeforeLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandlerLoseCondition()
    {
        LoseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawner();
    }

    private void StopSpawner()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
