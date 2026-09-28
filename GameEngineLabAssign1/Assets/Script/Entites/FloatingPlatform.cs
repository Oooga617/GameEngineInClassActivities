using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    //the different positions
    Vector3 pos1, pos2, targetPos;
    bool goUp = true;
    public float yDisplacement = 5.0f;
    public float lerpSpeed = 5.0f;
    float lerpProgress, lerpRatio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos1 = transform.position;
        pos2 = new Vector3(transform.position.x, yDisplacement, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (goUp)
        {
            transform.position = pos1;
            targetPos = pos2;

            if (lerpProgress < 1.0f)
            {
                lerpRatio = lerpProgress / 1.0f;
                lerpProgress += lerpSpeed * Time.deltaTime;
            }
            else
            {
                goUp = false;
                lerpProgress = 0.0f;
            }

            this.transform.position = Vector3.Lerp(pos1, targetPos, lerpRatio);
            
        }
        else
        {
            transform.position = pos2;
            targetPos = pos1;

            if (lerpProgress < 1.0f)
            {
                lerpRatio = lerpProgress / 1.0f;
                lerpProgress += lerpSpeed * Time.deltaTime;
            }
            else
            {
                goUp = true;
                lerpProgress = 0.0f;
            }

            this.transform.position = Vector3.Lerp(pos2, targetPos, lerpRatio);
        }
    }
}
