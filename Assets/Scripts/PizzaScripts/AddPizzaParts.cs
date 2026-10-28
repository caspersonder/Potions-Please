using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AddPizzaParts : MonoBehaviour
{
    [SerializeField] private new List<Button> ingreButtons = new List<Button>();
    
    public enum ingredients
    {
        Sauce,
        Peperoni,
        Cheese
    }
    
    [HideInInspector] public new List<ingredients> ingreTypeList = new List<ingredients>();
    
    private TextMeshProUGUI currentIngreList;

    private void Start()
    {
        currentIngreList = GameObject.Find("IngredientsList").GetComponent<TextMeshProUGUI>();
        currentIngreList.text= " ";
        
        ingreButtons.Add(GameObject.Find("SauceButton").GetOrAddComponent<Button>());
        ingreButtons.Add(GameObject.Find("PeperoniButton").GetOrAddComponent<Button>());
        ingreButtons.Add(GameObject.Find("CheeseButton").GetOrAddComponent<Button>());
    }

    public void addIngre1()
    {
        ingreTypeList.Add(ingredients.Sauce);
        updateIngreList();
    }
    public void addIngre2()
    {
        ingreTypeList.Add(ingredients.Peperoni);
        updateIngreList();
    }
    public void addIngre3()
    {
        ingreTypeList.Add(ingredients.Cheese);
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