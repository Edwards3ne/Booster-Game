using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    
    void OnCollisionEnter(UnityEngine.Collision other)
    {
         switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("friendly");
                break;
            case "Finish":
                Debug.Log("You win");
                break;
            case "Fuel":
                Debug.Log("you get fuel");
                break;
            default:
                ReloadLevel();                
                break;
        }
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
