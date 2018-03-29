using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public int Time;

	public void Start()
	{
		StartCoroutine("Wait");

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(Time);

		SceneManager.LoadScene("Level_1");
	}
}


//Cory Brown
//March,13,2017
