using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelChangeDelay = 1f;
    [SerializeField] AudioClip Explode;
    [SerializeField] AudioClip Success;
    AudioSource audioSource;
    void OnCollisionEnter(Collision other) 
    {
       switch (other.gameObject.tag)
       {
            case "Friendly":
                Debug.Log("This Thing is Friendly");
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                CrashSequence();
                break;
       } 
    }

    void SuccessSequence()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Move>().enabled = false;
        audioSource.PlayOneShot(Success);
        Invoke("LoadNextLevel",LevelChangeDelay);
    }

    void CrashSequence()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Move>().enabled = false;
        audioSource.PlayOneShot(Explode);
        Invoke("ReloadLevel",1);
    }

    void ReloadLevel() 
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);

    }

    void LoadNextLevel()
    {
        int NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }
        SceneManager.LoadScene(NextSceneIndex);

    }
}
