using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

	public float speed = 10f;
	public Rigidbody2D bullet;
	public Transform firePoint;
	public GameObject Gun;
	public Slider xpbar;


	// Use this for initialization
	void Start()
	{

	}

	void Fire()
	{

	}

	void Update()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		if (angle > 90 && angle < 180)
		{
			//GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<SpriteRenderer>().flipY = true;
		}
		else {
			GetComponent<SpriteRenderer>().flipY = false;
		}

		if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
		{
			Instantiate(bullet, firePoint.position, firePoint.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		xpbar.value += 10;
		StartCoroutine("Wait");

	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);

		Destroy(gameObject);
	}

//corybrown
}
