using UnityEngine;
using System.Collections;

public class cloudMove : MonoBehaviour {

	public GameObject Cloud;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right * Time.deltaTime, Space.World);


	
	}
}


//Cory Brown
