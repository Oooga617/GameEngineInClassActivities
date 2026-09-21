using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public flagSlide flagSlide;
    public TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //not display anything
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayText()
    {
        //if player dies say game over
        if (player.isDead)
        {
            text.text = "GAME OVER!";
        }
        //if win say you win
        else if (flagSlide.isWin)
        {
            text.text = "YOU WIN!";
        }
    }
}
