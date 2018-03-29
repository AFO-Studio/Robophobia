using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spell: MonoBehaviour
{

	public int pointValue = 5;
	public float speed = 15f;
	public Rigidbody2D bullet;

	void Start()
	{
		fireShot();
	}

	void fireShot()
	{

		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		//Quaternion rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg);

		GetComponent<Rigidbody2D>().velocity = Quaternion.AngleAxis(angle, Vector3.forward) * new Vector3(1, 0, 0) * speed * Time.deltaTime;

	}

	/*void OnCollisionEnter2D(Collision2D col)
	{
		if ((col.gameObject.name == "Enemy") || (col.gameObject.name == "Enemy(Clone)"))
		{
			Destroy(col.gameObject);
			//Destroy(gameObject);
			Game gameScript = FindObjectOfType<Game>();
			gameScript.DecrementEnemy();
			gameScript.AddScore(pointValue);
		}
		if (col.gameObject)
		{
			Destroy(gameObject);
		}
	}*/
}
