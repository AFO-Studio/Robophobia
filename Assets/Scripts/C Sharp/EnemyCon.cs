using System.Collections;
using UnityEngine;
using System.Threading;

public class EnemyCon : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;

    DamageResistance enemyResist;

	public int currentTurn;
	public int nextTurn;

    //    int health = 100;
    int atkVal;

    float enemyX;
    float enemyY;


    void Start()
	{
		enemyX = GetComponent<Transform>().position.x;
		enemyY = GetComponent<Transform>().position.y;
		//playResist.physResist = 1f;
		//playResist.magResist = 1f;
	}

	void Update()
	{
		if (atkVal == 1 && Turns.turns == currentTurn)
		{
			transform.position = new Vector2(.06f, -2.32f);

            Thread goingBack = new Thread(goBack);
            goingBack.Start();
		}
		else
			transform.position = new Vector2(enemyX, enemyY);
	}


	public void returnChar(int val)
	{
		atkVal = val;
	}

	void goBack()
	{
        Thread.Sleep(100);
		atkVal = 0;
		Turns.turns = nextTurn;
		nextPanel.SetActive(true);
		currentPanel.SetActive(false);
	}
}