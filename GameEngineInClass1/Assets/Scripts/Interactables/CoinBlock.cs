using System.Collections;
using UnityEngine;

public class CoinBlock : Block
{
    public float pushValue = 1.0f;
    public float pushAnimSpeed = 0.5f;
    private bool hasBeenHit = false;

    //this determines if the block has an item, and if so what is in it.
    //it can be a coin or a powerup depending on what goes in the inspector window for the item
    private bool hasItem = false;
    public int itemQuantity = 1;
    public GameObject item;

    //y position displacement for spawning in the item above the block
    public float itemYSpawn = 1.25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //checks if item has nothing in it, and if there is something in it, then say the block isnt empty
        if (item != null)
        {
            itemQuantity = 1;
            hasItem = true;
        }
        else
        {
            hasItem = false;
        }
    }

    public override void reactHit()
    {
        if (itemQuantity > 0 && hasItem)
        {
            spawnItem();
            itemQuantity--;
        }
        else
        {
            hasItem = false;
        }
            

        //this little animation plays if you hit the block before;
        if (!hasBeenHit)
            StartCoroutine(jumpBlock());
    }


    //spawns in the item
    private void spawnItem()
    {
        GameObject blockItem = item;
        Vector3 newItemPos = new Vector3(this.transform.position.x, transform.position.y + itemYSpawn, transform.position.z);
        Instantiate(blockItem, newItemPos, Quaternion.identity);
    }

    //makes the block bounce and react to getting hit from under
    IEnumerator jumpBlock()
    {
        Debug.Log("supposed to plau");
        hasBeenHit = true;
        //this pushes the block up first
        for (int i = 0; i < 5; i++)
        {
            Vector3 oldPos = transform.position;
            Vector3 newPos = new Vector3(oldPos.x, oldPos.y + pushValue, oldPos.z);
            transform.position = newPos;
            yield return new WaitForSeconds(pushAnimSpeed);
        }
        //then pushes down
        for (int i = 0; i < 5; i++)
        {
            Vector3 oldPos = transform.position;
            Vector3 newPos = new Vector3(oldPos.x, oldPos.y - pushValue, oldPos.z);
            transform.position = newPos;
            yield return new WaitForSeconds(pushAnimSpeed);
        }
        hasBeenHit = false;
        yield return null;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
