using UnityEngine;
using System.Threading;

public class PlayerCon : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public GameObject EnemyChar;
    //	Array EnemyList;

    DamageResistance playResist;

	public int currentTurn;
	public int nextTurn;

    //	int health = 100;
    int atkVal;

    float playerX;
    float playerY;


	void Start()
	{
		//		EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        // ^ Might be better to build a list somewhere using the scripts on the enemies, to keep the system from wasting resources finding things

		playerX = transform.position.x;
		playerY = transform.position.y;
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
		{
            transform.position = new Vector2(playerX, playerY);
		}
	}

	public void returnChar(int val)
	{
		atkVal = val;

		if (EnemyChar.tag == "Enemy")
		{
			EnemyChar.GetComponent<enemyDetails>();
			//EnemyChar.GetComponent<moveList>();
			Debug.Log("enemy here");
		}
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