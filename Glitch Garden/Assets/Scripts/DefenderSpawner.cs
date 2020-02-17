using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defender";

    void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClick());
    }

    public void SetSelectDefender(Defender defenderToSelected)
    {
        defender = defenderToSelected;
    }

    private Vector2 GetSquareClick()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefenser(Vector2 roundPos)
    {
        Defender newDefender = Instantiate(defender, roundPos, transform.rotation) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        // if we have enough stars
            // spawn defender
            // spend stars
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefenser(gridPos);
            starDisplay.SpendingStars(defenderCost);
        }
    }

}
