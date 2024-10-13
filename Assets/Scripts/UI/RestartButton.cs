using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private string sceneName = "SampleScene";
  public void RestartScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
