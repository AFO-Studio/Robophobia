using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillyMovement2 : MonoBehaviour {

    public GameObject thing;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 40 * -1);
        transform.RotateAround(new Vector3(thing.transform.position.x, thing.transform.position.y), Vector3.forward, 40 * Time.deltaTime * -1);
    }
}
