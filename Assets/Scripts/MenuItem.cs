using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    bool selected = false;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.LogError(name + " has no cost!"); }
        else
        {
            costText.text = defenderPrefab.GetCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        ClickItem();
    }

    private void ClickItem()
    {
        var items = FindObjectsOfType<MenuItem>();
        if (!selected)
        {

            selected = true;
            foreach (var item in items)
            {
                item.GetComponent<SpriteRenderer>().color = Color.grey;
            }
            GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetDefender(defenderPrefab);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
            selected = false;
            FindObjectOfType<DefenderSpawner>().SetDefender(null);
        }
    }
}
