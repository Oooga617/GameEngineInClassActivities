using UnityEngine;

public class Goomba : Enemy
{

    override public void getJumpedOn()
    {
        if (health >0)
        {
            Debug.Log("supposed to get hurt");
            health--;
           
        }
        else {
            Debug.Log("supposed to die");
            Destroy(this.gameObject);
        }
        
    }

}
