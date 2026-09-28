using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    int keysCollected = 0;
    public int keyCount = 1;
    public GameObject gate;

    public string SceneToLoad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collecting keys and unlocking gates
    public void collectKey()
    {
        keysCollected++;
        if (keysCollected >= keyCount)
        {
            gate.SetActive(false);
        }
       
    }

    //loads the scene
    public void nextLevel()
    {
        Debug.Log("supposed to go to next level");
        SceneManager.LoadScene(SceneToLoad);
        
    }

    public void retryLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void quitGame()
    {
        //quits the game.
        Debug.Log("supposed to quit");
        Application.Quit();
    }

}
