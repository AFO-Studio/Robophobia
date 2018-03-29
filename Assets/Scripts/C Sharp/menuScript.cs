using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{

	public Button startText;
	public Button exitText;
	public Button options;
	public Button credits;
	public GameObject OptionsMenu;
	public AudioClip hover;
	public AudioClip click;

	// Use this for initialization
	void Start()
	{
		startText = startText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		options = options.GetComponent<Button>();
		credits = options.GetComponent<Button>();
		OptionsMenu.SetActive(false);

	}

	public void Exit()
	{
		startText.enabled = false;
		exitText.enabled = false;
		options.enabled = false;
		credits.enabled = false;
	}

	public void No()
	{
		startText.enabled = true;
		exitText.enabled = true;
		options.enabled = true;
		credits.enabled = false;
	}

	public void StartPressed()
	{
		StartCoroutine("wait");
	}

	public void ExitPressed()
	{
		Application.Quit();
	}

	public void optionS()
	{
		OptionsMenu.SetActive(true);

	}

	public void creditPress()
	{
		StartCoroutine("wait2");
	}

	public void optionsQuit()
	{
		OptionsMenu.SetActive(false);
	}

	public void hoverBtn()
	{
		GetComponent<AudioSource>().clip = hover;
		GetComponent<AudioSource>().Play();


	}
	public void clickBtn()
	{
		GetComponent<AudioSource>().clip = click;
		GetComponent<AudioSource>().Play();


	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(1);

		SceneManager.LoadScene("Opening Cutscene");
	}
	IEnumerator wait2()
	{
		yield return new WaitForSeconds(1);

		SceneManager.LoadScene("Credits");
	}
}