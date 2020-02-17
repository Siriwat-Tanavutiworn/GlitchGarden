using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int baseLives = 6;
    [SerializeField] int damage = 1;
    Text lifeText;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();
        UpdateDifficulty();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifeText.text = baseLives.ToString();
    }

    public void DecreaseHealth()
    {
        baseLives -= damage;
        UpdateDisplay();

        if(baseLives <= 0)
        {
            FindObjectOfType<LevelController>().HandlerLoseCondition();
        }
    }

    public int GetHealth()
    {
        return baseLives;
    }

    private void UpdateDifficulty()
    {
        if (PlayerPrefController.GetDifficulty() >= 0.4f)
        {
            baseLives = baseLives / 2;
        }
        if (PlayerPrefController.GetDifficulty() >= 0.8f)
        {
            baseLives = baseLives / 2;
        }
        if (PlayerPrefController.GetDifficulty() >= 1f)
        {
            baseLives = baseLives / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
