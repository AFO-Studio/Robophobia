using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CONVO : MonoBehaviour
{


	public GameObject UILeft;
	public GameObject InfoUI;
	//public Text UItext;

	// Use this for initialization
	void Start()
	{
		UILeft.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		InfoUI.SetActive(false);
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(UIpop());

		}

	}
	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Time.timeScale = 0;
			UILeft.SetActive(true);

		}

	}
	public void MoveOn()
	{
		Time.timeScale = 1;
		UILeft.SetActive(false);
		SceneManager.LoadScene("BattleScene");
	}

	public void PressUI()
	{
		UILeft.SetActive(false);
	}
	public IEnumerator UIpop()
	{

		UILeft.SetActive(true);
		//InfoUI.SetActive(true);
		yield return new WaitForSeconds(4);
		UILeft.SetActive(false);


	}
}
