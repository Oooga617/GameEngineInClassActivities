using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Chapter.Singleton
{
    //inheriting from singleton, and using this GManager script as the Singleton
    public class GManager : Singleton<GManager>
    {
        public TextMeshProUGUI gameText;
        private GameObject playerObj;
        public GameObject fireFlower;

        //contains list of enemy spawns
        public List<EnemySpawner> enemySpawns;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //it says nothing at first
            gameText.text = "";
            spawnThreats();
        }

        private void OnGUI()
        {
            //two buttons, one that kills the player for the game over,
            //and another that makes the player win
            if (GUILayout.Button("Kill player"))
            {
                gameOver();
            }
            if (GUILayout.Button("Win Game"))
            {
                winGame();
            }

            //add a button to give the player character the fireflower ability
            if (GUILayout.Button("Give Fire Flower"))
            {
                giveFireFlower();
            }

            //if all enemies are dead respawn all enemies
            if (GUILayout.Button ("Spawn Enemies"))
            {
                spawnThreats();
            }
        }

        public void gameOver()
        {
            gameText.text = "Game Over!";
            playerObj = GameObject.FindGameObjectWithTag("Player");
            playerObj.GetComponent<PlayerController>().isDead = true;
            playerObj.SetActive(false);
        }

        public void winGame()
        {
            gameText.text = "You Win!";
        }

        private void giveFireFlower()
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            Instantiate(fireFlower, playerObj.transform);
        }

        void spawnThreats()
        {
            foreach (EnemySpawner spawner in enemySpawns)
            {
                spawner.SpawnEnemy();
            }
        }
    }
}



