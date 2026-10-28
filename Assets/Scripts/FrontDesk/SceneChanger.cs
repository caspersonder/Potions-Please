
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Pizza");
        GameObject.Find("CostumerHandler").GetComponent<CostumerScript>().removeImage();
    }
}
