using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CostumerScript : MonoBehaviour
{
    public static CostumerScript Instance { get; private set; }
    
    [SerializeField] private List<GameObject> Costumers = new List<GameObject>();

    private GameObject chosenCostumer;
    private GameObject insCostumer;

    private string humanOrVampire;
    private int corrects = 0;

    public GameObject imageToRemove;
    
    public TextMeshProUGUI correctsCounterText;

    private void Awake()
    {
        // Check if an instance already exists in the game
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy the duplicate
            return;
        }

        // Set this object as the permanent instance and preserve it
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        chooseRandonCostumer();
        correctsCounterText.text = "0/10";
    }

    private void chooseRandonCostumer()
    {
        chosenCostumer = Costumers[Random.Range(0, 2)];
        humanOrVampire = chosenCostumer.gameObject.name;
        if (insCostumer != null)
        {
            Destroy(insCostumer);
        }

        // Instantiate at root level (null parent) so it can have its own DontDestroyOnLoad applied
        insCostumer = Instantiate(chosenCostumer, Vector3.zero, Quaternion.identity);
        
        // Force the newly spawned visual character to persist across scenes too
        DontDestroyOnLoad(insCostumer);
    }

    public void makePotion()
    {
        if (humanOrVampire == "Vampire")
        {
            corrects++;
        }
        imageToRemove.SetActive(true);
        updateCounter();
    }
    public void makePizza()
    {
        if (humanOrVampire == "Human")
        {
            corrects++;
        }
        imageToRemove.SetActive(true);
        updateCounter();
    }

    public void removeImage()
    {
        imageToRemove.SetActive(false);
    }

    private void updateCounter()
    {
        correctsCounterText.text = corrects+"/10";
    }
}
