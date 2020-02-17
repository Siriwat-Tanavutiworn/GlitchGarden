using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{

    [SerializeField] int baseStars = 50;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDifficulty();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateDisplay()
    {
        starText.text = baseStars.ToString();
    }

    public void AddStars(int amount)
    {
        baseStars += amount;
        UpdateDisplay();
    }

    public void SpendingStars(int amount)
    {
        if(baseStars >= amount)
        {
            baseStars -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return baseStars >= amount;
    }

    private void UpdateDifficulty()
    {
        if (PlayerPrefController.GetDifficulty() >= 0.3f)
        {
            baseStars += baseStars;
        }
        if (PlayerPrefController.GetDifficulty() >= 0.6f)
        {
            baseStars += baseStars;
        }
    }
}
