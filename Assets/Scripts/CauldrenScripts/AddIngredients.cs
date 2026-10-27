using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AddIngredients : MonoBehaviour
{
    private Button mixButton;
    [SerializeField] private new List<Button> ingreButtons = new List<Button>();
    
    private enum ingredients
    {
        ingre1,
        ingre2,
        ingre3
    }
    
    private new List<ingredients> ingreTypeList = new List<ingredients>();
    
    private TextMeshProUGUI currentIngreList;

    private void Start()
    {
        currentIngreList = GameObject.Find("IngredientsList").GetComponent<TextMeshProUGUI>();
        currentIngreList.text= " ";
        
        ingreButtons.Add(GameObject.Find("Ingredient 1").GetOrAddComponent<Button>());
        ingreButtons.Add(GameObject.Find("Ingredient 2").GetOrAddComponent<Button>());
        ingreButtons.Add(GameObject.Find("Ingredient 3").GetOrAddComponent<Button>());

        //mixButton = GameObject.Find("MixButton")
    }

    public void addIngre1()
    {
        ingreTypeList.Add(ingredients.ingre1);
        updateIngreList();
    }
    public void addIngre2()
    {
        ingreTypeList.Add(ingredients.ingre2);
        updateIngreList();
    }
    public void addIngre3()
    {
        ingreTypeList.Add(ingredients.ingre3);
        updateIngreList();
    }

    void updateIngreList()
    {
        var ingresToDisplay = ingreTypeList.Take(3).Select(x => x.ToString());
        currentIngreList.text = string.Join(" ", ingresToDisplay);

        if (ingreTypeList.Count >= 3)
        {
            foreach (var button in ingreButtons)
            {
                button.interactable = false;
            }
        }
    }
}
