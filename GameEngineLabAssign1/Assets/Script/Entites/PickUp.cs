using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //finds the game manager
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if player touches it, interact with the game manager (add key collected)
    //and delete itself as its collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.collectKey();
            Destroy(this.gameObject);
        }
    }
}
