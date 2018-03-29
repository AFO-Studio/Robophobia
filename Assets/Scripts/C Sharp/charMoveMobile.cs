using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class charMoveMobile : MonoBehaviour
{
	//Handle Animations
	private Animator animator;
	public bool facingRight;
	//private bool upBool = false;
	//private bool rightBool = false;
	//private bool leftBool = false;
	//private bool downBool = false;

	//Handle Movement
	public float movementSpeed = 5.0f;
	public float Jump = 2.0f;
	public float Boost = 2.0f;
	public Rigidbody2D player;

	//Handle Attack and Damage
	public int damage = -5;

	//Mobile buttons
	public Button UpBtn;
	public Button LeftBtn;
	public Button DownBtn;
	public Button RightBtn;



	void Start()
	{
		//Animation
		animator = GetComponent<Animator>();
		UpBtn = UpBtn.GetComponent<Button>();
		DownBtn = DownBtn.GetComponent<Button>();
		RightBtn = RightBtn.GetComponent<Button>();
		LeftBtn = LeftBtn.GetComponent<Button>();

	}

	void FixedUpdate()
	{
		UpBtn.enabled = true;
		DownBtn.enabled = true;
		RightBtn.enabled = true;
		LeftBtn.enabled = true;
		animator.SetBool("isWalkingLeft", false);
		animator.SetBool("isWalkingUp", false);
		animator.SetBool("isWalkingDown", false);
		animator.SetBool("isWalkingRight", false);

	}
	public void UpBtnPress()
	{
		//upBool = true;
		transform.position += Vector3.up * movementSpeed * Time.deltaTime;
		animator.SetBool("isWalkingUp", true);
		Debug.Log("Trump");

	}
	public void DownBtnPress()
	{

		//downBool = true;
		transform.position += Vector3.down * movementSpeed * Time.deltaTime;
		animator.SetBool("isWalkingDown", true);
		Debug.Log("Trump");

	}
	public void LeftBtnPress()
	{

		//leftBool = true;
		transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		animator.SetBool("isWalkingLeft", true);
		Debug.Log("Trump");

	}
	public void RightBtnPress()
	{

		//rightBool = true;
		transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		animator.SetBool("isWalkingRight", true);
		//animator.SetBool("isWalkingRight", false);
		Debug.Log("Trump");




	}
}


//Cory Brown
