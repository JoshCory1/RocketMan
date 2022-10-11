using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
    switch (other.gameObject.tag)
        {
            case "Frendly":
                Debug.Log("Start");
                break;
            case "Fule":
                Debug.Log("Fule");
                break;
            case "Finish":
                Debug.Log("Finish");
                break;
            default:
                Debug.Log("boom");
                break;

        } 
    }
}
