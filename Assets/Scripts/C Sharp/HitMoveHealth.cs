using UnityEngine;
using UnityEngine.UI;

public class HitMoveHealth : MonoBehaviour
{
	public Slider healthbar;
	public Slider xpbar;

	public string Enemy;
	public string PowerUp;


	public void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag != Enemy)
		{
			return;
		}

		else if (other.gameObject.tag == Enemy)
		{
			healthbar.value -= 6;
		}
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag != PowerUp)
		{
			return;
		}

		else if (other.gameObject.tag == PowerUp)
		{
			xpbar.value += 9;
		}
	}
}