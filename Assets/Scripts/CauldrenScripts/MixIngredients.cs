using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MixIngredients : MonoBehaviour
{
    private AddIngredients addIngreScpt;
    private Button mixButton;
    [SerializeField] private string mixNewSceneName;
    [SerializeField] private float timeBeforeSceneSwap;

    [SerializeField] private GameObject PizzaOrPotionToSpawn;
    [SerializeField] private Transform placeToSpawn;

    private GameObject Potion;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addIngreScpt = GameObject.Find("Ingredient Manager").GetComponent<AddIngredients>();
        mixButton = GetComponent<Button>();
    }

    private void Update()
    {
        if (addIngreScpt.ingreTypeList.Count >= 3 && !mixButton.IsInteractable())
        {
            mixButton.interactable = true;
        }

        if (Potion != null)
        {
            Potion.transform.Translate(Vector2.up*0.008f);
        }
    }

    public void onMixPress()
    {
        GameObject insPotion = Instantiate(PizzaOrPotionToSpawn, placeToSpawn);
        Potion = insPotion;
        StartCoroutine(loadNewScene());
    }

    IEnumerator loadNewScene()
    {
        yield return new WaitForSeconds(timeBeforeSceneSwap);
        CostumerScript.Instance.makePotion();
        SceneManager.LoadScene(mixNewSceneName);
    }
}
