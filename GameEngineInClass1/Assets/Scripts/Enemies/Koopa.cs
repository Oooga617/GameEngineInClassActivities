using System.Collections;
using UnityEngine;

public class Koopa : Enemy
{
    bool isKicked = false;
    bool canBeKicked = false;
    public GameObject shell;
    

    override public void getJumpedOn()
    {
        //if jumped on, turn into koopa shell
        if (!isHit)
        {
            isHit = true;
            StartCoroutine(allowingBeKicked());
        }
    }

    IEnumerator allowingBeKicked()
    {
        //have a delay to allow being kicked so collision with the player doesnt immediately kill them
        yield return new WaitForSeconds(0.5f);
        canBeKicked = true;
        yield return null;
    }

    //if touching the trigger, depending on where the player colliding with the shell (left or right) kick
    //to the opposite direction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBeKicked && !isKicked && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.x < this.transform.position.x)
            {
                isLeft = false;
            }
            else
            {
                isLeft = true;
            }
            StartCoroutine(gettingKicked());
        }
    }

    IEnumerator gettingKicked()
    {
        Debug.Log("supposed to disable rb simulation");
        //meant to disable rigidbody2D and colliders attached
        rb.simulated = false;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
        //spawn in the shell that moves around
        Instantiate(shell, this.transform.position, Quaternion.identity);
        //pass on the data for the move direction to the koopa shell
        
        shell.GetComponent<KoopaShell>().setDir(!isLeft);
        //later quickly delete the koopa enemy object
        Destroy(this.gameObject);
        yield return null;
    }
}
