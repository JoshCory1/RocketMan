using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
    switch (other.gameObject.tag)
        {
            case "Frendly":
                Debug.Log("Start");
                break;
            case "Fuel":
                Debug.Log("Fule");
                break;
            case "Finish":
                Invoke("Nextlvl", 1);
                break;
            default:
                StarCrashSequence();
                break;

        } 
    
    }
    void StarCrashSequence()
    {
        GetComponent<Movement>().enabled = false; 
       Invoke("ReloadLevel", 1f);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void Nextlvl()
    {
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         int nextSceneIndex = currentSceneIndex + 1;
         if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
         {
            nextSceneIndex = 0;
         }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
