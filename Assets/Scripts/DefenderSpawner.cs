using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarDisplay starDisplay;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    private void Start()
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
        SpawnDefender(GetSquareClicked());
    }

    public void SetDefender(Defender defender2)
    {
        defender = defender2;
    }

    private Vector2 GetSquareClicked()
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

    private void SpawnDefender(Vector2 worldPos)
    {

        var defenders = FindObjectsOfType<Defender>();
        starDisplay = FindObjectOfType<StarDisplay>();
        if (defender)
        {
            if (starDisplay.GetStars() >= defender.GetCost())
            {
                foreach (var item in defenders)
                {
                    Vector2 pos = new Vector2(item.transform.position.x, item.transform.position.y);
                    if (pos == worldPos)
                    {
                        return;
                    }
                }
                PlaceDefender(worldPos);
            }
        }
    }

    private void PlaceDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        starDisplay.RemoveStars(defender.GetCost());
        newDefender.transform.parent = defenderParent.transform;
    }
}
