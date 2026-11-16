using UnityEngine;

public class HealthBar : Subject
{
    int healthCurr, healthMax;
    [SerializeField] Enemy enemyScript;
    [SerializeField] GameObject bar;
    float initialX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemyScript = GetComponentInParent<Enemy>();
        healthMax = enemyScript.health;
        healthCurr = healthMax;
        initialX = 1.2508f;
    }
    private void Start()
    {

    }

    public override void Notify (Subject subject)
    {
        if (!enemyScript)
        {
            enemyScript = GetComponentInParent<Enemy>();
        }
        if (enemyScript)
        {
            updateHealth(enemyScript.health);
        }
    }

    public void updateHealth(int h)
    {
        healthCurr = h;
        healthCurr = Mathf.Clamp(healthCurr, 0, healthMax);
        float hpRatio = (float)healthCurr / healthMax;
        Vector3 newXScale = bar.transform.localScale;
        newXScale.x = initialX * (hpRatio+0.1f);
        bar.transform.localScale = newXScale;

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
