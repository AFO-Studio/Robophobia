using UnityEngine;
using UnityEngine.UI;

public class DamageTester : MonoBehaviour
{
    public Slider HealthBar;

    //int healthAmountFull;


    void Start()
    {
        //healthAmountFull = 100;
    }

    void Update()
    {
        //Debug.Log("Health: " + HealthBar.value);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "EnemyHitSuccess")
        {
            HealthBar.value -= 10;
            Debug.Log("THPM");
        }
    }
}