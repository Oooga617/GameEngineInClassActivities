using Chapter.Singleton;
using Unity.VisualScripting;
using UnityEngine;

public class flagSlide : MonoBehaviour
{
    public GameObject flag;
    //start and end positions
    Vector3 oldPos, newPos;
    public float yDisplacement = 5.0f;
    bool isFlagReached = false;
    public float flagSlideMax = 50.0f;
    float flagSlideElapsed = 0.0f;
    float flagSlideRatio;
    public float flagSpeed = 15.0f;


    //win condition
    public bool isWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set up the different positions;
        oldPos = flag.transform.position;
        newPos = new Vector3(oldPos.x, oldPos.y - yDisplacement, oldPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        //lerp progression between the 2 different flag positions
        if (isFlagReached)
        {
            //get the ratio for interpolation
            if (flagSlideElapsed < flagSlideMax)
            {
                flagSlideRatio = flagSlideElapsed / flagSlideMax;
                flagSlideElapsed += Time.deltaTime*flagSpeed;
            }
            else
            {
                flagSlideRatio = 1.0f;
                isWin = true;
                GManager.Instance.winGame();
            }

            flag.transform.position = Vector3.Lerp(oldPos, newPos, flagSlideRatio);
        }
        
    }

    //when player touches the pole, make the flag slide down.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFlagReached = true;
           
        }
            
    }
}
