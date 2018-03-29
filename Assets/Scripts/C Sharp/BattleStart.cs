using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    //public GameObject fadeOut;

    //Renderer rend;

    public int scene;

	//float opacity = 1;


	void Start()
	{
		//rend = fadeOut.GetComponent<Renderer>();
	}

	void Update()
	{

	}
	//Scene BattleScene = SceneManager.GetSceneByName("BattleScene");  < -- Where is this supposed to go??

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			//while(rend.material.color.a != 0)
			//{
			//    fadeOut.GetComponent<Renderer>().material.color.a = opacity;
			//}
			SceneManager.LoadSceneAsync(scene);
		}
	}
}