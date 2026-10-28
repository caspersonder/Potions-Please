using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MixPizza : MonoBehaviour
{
    private AddPizzaParts addIngreScpt;
    private Button mixButton;
    [SerializeField] private string mixNewSceneName = "FrontDesk";
    [SerializeField] private float timeBeforeSceneSwap = 1;

    [SerializeField] private GameObject PizzaOrPotionToSpawn;
    [SerializeField] private Transform placeToSpawn;

    private GameObject Pizza;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addIngreScpt = GameObject.Find("Ingredient Manager").GetComponent<AddPizzaParts>();
        mixButton = GetComponent<Button>();
    }

    private void Update()
    {
        if (addIngreScpt.ingreTypeList.Count >= 3 && !mixButton.IsInteractable())
        {
            mixButton.interactable = true;
        }

        if (Pizza != null)
        {
            Pizza.transform.Translate(Vector2.up*0.008f);
        }
    }

    public void onMixPress()
    {
        GameObject insPotion = Instantiate(PizzaOrPotionToSpawn, placeToSpawn);
        Pizza = insPotion;
        StartCoroutine(loadNewScene());
    }

    IEnumerator loadNewScene()
    {
        yield return new WaitForSeconds(timeBeforeSceneSwap);
        SceneManager.LoadScene(mixNewSceneName);
    }
}