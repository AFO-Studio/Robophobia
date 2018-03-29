using UnityEngine;
using UnityEngine.UI;

public class TimerScript2 : MonoBehaviour
{
	public Text timerLabel;

	public float time;


	void Update()
	{

		time += Time.deltaTime;
		var minutes = time / 120;
		var seconds = time % 60;
		timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
	}
}