using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI timer;
    public float timeLeft = 10.0f;
    float timeProgress = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeProgress < timeLeft)
        {
            timeProgress += Time.deltaTime;
        }

        timer.text = (timeLeft - timeProgress).ToString();
        if (timer == null)
        {
            GameObject timeObj = GameObject.Find("timeText");
            timer = timeObj.GetComponent<TextMeshProUGUI>();
        }

        if (timeProgress >= timeLeft)
        {
            timeProgress = 0.0f;
            retryScene();
        }
    }

    public void LoadScene()
    {
        Debug.Log("load scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + (1));
    }

    public void retryScene()
    {
        Debug.Log("supposed to retry scene");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
