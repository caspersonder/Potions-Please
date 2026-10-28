using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AddIngredients : MonoBehaviour
{
    [SerializeField] private new List<Button> ingreButtons = new List<Button>();
    
    public enum ingredients
    {
        Carrot,
        Egg,
        Skull
    }
    
    [HideInInspector] public new List<ingredients> ingreTypeList = new List<ingredients>();
    
    private TextMeshProUGUI currentIngreList;

    private void Start()
    {
        currentIngreList = GameObject.Find("IngredientsList").GetComponent<TextMeshProUGUI>();
        currentIngreList.text= " ";
        
        ingreButtons.Add(GameObject.Find("CarrotButton").GetOrAddComponent<Button>());
        ingreButtons.Add(GameObject.Find("EggButton").GetOrAddComponent<Button>());
        ingreButtons.Add(GameObject.Find("SkullButton").GetOrAddComponent<Button>());
    }

    public void addIngre1()
    {
        ingreTypeList.Add(ingredients.Carrot);
        updateIngreList();
    }
    public void addIngre2()
    {
        ingreTypeList.Add(ingredients.Egg);
        updateIngreList();
    }
    public void addIngre3()
    {
        ingreTypeList.Add(ingredients.Skull);
        updateIngreList();
    }

    void updateIngreList()
    {
        var ingresToDisplay = ingreTypeList.Take(3).Select(x => x.ToString());
        currentIngreList.text = string.Join(", ", ingresToDisplay);

        if (ingreTypeList.Count >= 3)
        {
            foreach (var button in ingreButtons)
            {
                button.interactable = false;
            }
        }
    }
}
