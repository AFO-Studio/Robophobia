using UnityEngine;
using System.Collections;

public class FlashlightControls : MonoBehaviour
{

	private Light flash;
	// Use this for initialization
	void Start()
	{
		flash = GetComponent<Light>();
		flash.enabled = !flash.enabled;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			flash.enabled = !flash.enabled;
		}

	}
}



