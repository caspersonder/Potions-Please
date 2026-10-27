using UnityEngine;
using UnityEngine.SceneManagement;


public class HumanButton : MonoBehaviour
{
    public void ChangeScene(string Pizza)
    {
        SceneManager.LoadScene(Pizza);
    }
}


