using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditEnd : MonoBehaviour
{

	public int time = 60;
	public int scrollSpeed = 3;
	// Use this for initialization
	void Start()
	{
		StartCoroutine("wait");
	}
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Time.timeScale = scrollSpeed;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(time);

		SceneManager.LoadScene("Title");
	}
}
