using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //calculate the distance between the colliding object and this game object
        float distance = Vector3.Distance(collision.transform.position, this.transform.position);
        Debug.Log(distance);
        //if the player hits the object from under, do something
        if (distance < 2.0f && collision.transform.position.y < this.transform.position.y && collision.gameObject.CompareTag("Player"))
        {
            reactHit();
        }
    }

    //do something
    public virtual void reactHit()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
