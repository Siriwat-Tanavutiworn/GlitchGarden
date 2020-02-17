using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our LevelTimer in SECONDs")]
    [SerializeField] float LevelTime = 10f;
    bool triggeredLevelFinish = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinish)
        {
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= LevelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinish = true;
        }
    }
}
