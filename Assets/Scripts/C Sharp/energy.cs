/*using UnityEngine;
using UnityEngine.UI;

public class energy : MonoBehaviour
{
	public GameObject btn1;
	public GameObject btn2;
	public GameObject btn3;
	public GameObject btn4;

	public Rigidbody2D Mybody;

    public Slider EnergyBar;

    int min = 0;


	void Start()
	{
		EnergyBar.maxValue = 100;
		//Mybody = Player.GetComponent<Rigidbody2D>();

	}

	void Update()
	{
		EnergyBar.value += 1;

		if (EnergyBar.value < 20 && Input.GetMouseButtonDown(0))
		{
			EnergyBar.value -= 0;
			btn1.GetComponent<Button>().enabled = false;
			btn2.GetComponent<Button>().enabled = false;
			btn3.GetComponent<Button>().enabled = false;
			btn4.GetComponent<Button>().enabled = false;


		}
		if (EnergyBar.value > 20 && Input.GetMouseButtonDown(0))
		{
			EnergyBar.value -= 20;
			btn1.GetComponent<Button>().enabled = true;
			btn2.GetComponent<Button>().enabled = true;
			btn3.GetComponent<Button>().enabled = true;
			btn4.GetComponent<Button>().enabled = true;
		}
	}
}*/