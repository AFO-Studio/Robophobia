using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQC : MonoBehaviour
{



	// Use this for initialization
	void Start ()
	{
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			GetComponent<BoxCollider2D> ().enabled = true;
			GetComponent<SpriteRenderer> ().enabled = true;
		} else {
			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
		}
		
	}

	//public void OnTriggerStay2D (col collision2D){
		
}

//}
