using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem crashParticls;
    [SerializeField] ParticleSystem successParticls;

    AudioSource AudioSound;

    bool isTransitioning = false;

    void Start() 
    {
        AudioSound = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return; }
        switch (other.gameObject.tag)
        {
            case "Frendly":
                Debug.Log("Start");
                break;
            case "Finish":
                moveToNextlvl();
                break;
            default:
                StarCrashSequence();
                break;

        } 
    
    }
    void StarCrashSequence()
    {
        isTransitioning = true;
        AudioSound.Stop();
        AudioSound.PlayOneShot(crashSound);
        crashParticls.Play();
        GetComponent<Movement>().enabled = false; 
        Invoke("ReloadLevel", delayTime);
    }
    void moveToNextlvl()
    {
        isTransitioning = true;
        AudioSound.Stop();
        AudioSound.PlayOneShot(successSound);
        successParticls.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Nextlvl", delayTime);
    }
    
    void ReloadLevel()
    {
        isTransitioning = true;
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
