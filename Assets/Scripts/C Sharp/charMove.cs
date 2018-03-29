using UnityEngine;
using UnityEngine.SceneManagement;


public class charMove : MonoBehaviour
{


	//Handle Animations
	private Animator animator;
	public bool facingRight;
	private bool upBool = false;
	private bool rightBool = false;
	private bool leftBool = false;
	private bool downBool = false;

	//Handle Movement
	public float movementSpeed = 5.0f;
	public float Jump = 2.0f;
	public float Boost = 2.0f;
	public Rigidbody2D player;

	//Handle Attack and Damage
	public int damage = -5;
	//private float z = 0;

	void Start()
	{
		//Animation
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{

		if (Input.GetKey("left") && upBool != true && downBool != true && rightBool != true || Input.GetKey("a") && upBool != true && downBool != true && rightBool != true)
		{
			animator.SetBool("isWalkingLeft", true);
			leftBool = true;
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		}
		else if (Input.GetKeyUp("left") || Input.GetKeyUp("a"))
		{
			animator.SetBool("isWalkingLeft", false);
			leftBool = false;
		}
		if (Input.GetKey("right") && upBool != true && downBool != true && leftBool != true || Input.GetKey("d") && upBool != true && downBool != true && leftBool != true)
		{
			animator.SetBool("isWalkingRight", true);
			rightBool = true;
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		}
		else if (Input.GetKeyUp("right") || Input.GetKeyUp("d"))
		{
			animator.SetBool("isWalkingRight", false);
			rightBool = false;
		}
		if (Input.GetKey("up") && downBool != true && rightBool != true && leftBool != true || Input.GetKey("w") && downBool != true && rightBool != true && leftBool != true)
		{
			animator.SetBool("isWalkingUp", true);
			upBool = true;
			transform.position += Vector3.up * movementSpeed * Time.deltaTime;
		}
		else if (Input.GetKeyUp("up") || Input.GetKeyUp("w"))
		{
			animator.SetBool("isWalkingUp", false);
			upBool = false;
		}
		if (Input.GetKey("down") && upBool != true && rightBool != true && leftBool != true || Input.GetKey("s") && upBool != true && rightBool != true && leftBool != true)
		{
			animator.SetBool("isWalkingDown", true);
			downBool = true;
			transform.position += Vector3.down * movementSpeed * Time.deltaTime;
		}
		else if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
		{
			animator.SetBool("isWalkingDown", false);
			downBool = false;
		}


	}



}

//Cory Brown
