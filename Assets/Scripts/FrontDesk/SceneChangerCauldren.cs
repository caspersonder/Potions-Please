using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerCauldren : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Cauldren");
        GameObject.Find("CostumerHandler").GetComponent<CostumerScript>().removeImage();
    }
}
