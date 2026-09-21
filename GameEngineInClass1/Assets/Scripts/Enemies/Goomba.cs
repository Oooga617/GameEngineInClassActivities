using UnityEngine;

public class Goomba : Enemy
{

    override public void getJumpedOn()
    {
        Destroy(this.gameObject);
    }

}
