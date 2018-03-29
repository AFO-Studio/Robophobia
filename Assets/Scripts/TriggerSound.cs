using UnityEngine;

public class TriggerSound : MonoBehaviour
{
	public bool SoundPlayed = false;

	// Use this for initialization
	void Start()
	{


	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			GetComponent<ParticleSystem>().Play(GetComponent<ParticleSystem>());
			GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
			Destroy(GetComponent<Collider2D>());
			SoundPlayed = true;
		}

	}

	public void SoundPlayThing()
	{
		if (SoundPlayed == true)
		{
			//			WaitForSeconds (GetComponent <AudioSource> ().clip.length);
			Debug.Log("Sound Played");
		}
	}
}
//cory brown
