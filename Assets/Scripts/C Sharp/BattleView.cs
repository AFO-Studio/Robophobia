using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleView : MonoBehaviour
{
	//Camera for BattleView
	public Camera MainCamera;

	//Enemy Slots
	public GameObject EnemyFront;
	public GameObject EnemyLeft;
	public GameObject EnemyRight;

	//Party Slots
	public GameObject PlayerFront;
	public GameObject PlayerLeft;
	public GameObject PlayerRight;

    //Changable elements
    public GameObject Background;
    public GameObject MenuBackGround;

    //UI Elements
    public Canvas HUD;
	public Text textSlot1;
	public Text textSlot2;
	public Text textSlot3;
	public Text textSlot4;

	//Enemy Text Fields
	public Text EnemyMoveDisplay1;
	public Text EnemyMoveDisplay2;
	public Text EnemyMoveDisplay3;

	//Buttons
	public Button FightButton;
	public Button MagicButton;
	public Button ItemsButton;
	public Button RunButton;

	public Slider HealthBar;

	//int healthAmountFull;


	void Start()
	{
		textSlot1.text = "This is the BattleScene";
		textSlot2.text = "Click Fight and punch this little bot";
		EnemyMoveDisplay1.text = " Enemy used" /* + movefromList + ""*/;
		//healthAmountFull = 100;
		//Scene BattleScene = SceneManager.GetSceneByName("BattleView");
	}

	void Update()
	{

	}


	public void EnemyAttack()
	{
		//EnemyMoveDisplay1.text = " Enemy used" + FindObjectOfType<listOfMoves>() + "";
	}

	public void FightItNow()
	{
		textSlot1.text = "Punch";
		textSlot2.text = "Slap";
		textSlot3.text = "Flap";
		textSlot4.text = "Tap";
	}

	public void MagicMove()
	{
		textSlot1.text = "Sprinkle";
		textSlot2.text = "Tinkle";
		textSlot3.text = "Dankness";
		textSlot4.text = "Tap Water";
	}

	public void ItemUse()
	{
		textSlot1.text = "HP Potion";
		textSlot2.text = "PP Potion";
		textSlot3.text = "Grape";
		textSlot4.text = "Pen";
	}
	//Scene Level_1 = SceneManager.GetSceneByName("Level_1"); <-- Where is this supposed to go?

	public void RunAway()
	{
		textSlot1.text = "Punch";
		textSlot2.text = "Slap";
		textSlot3.text = "Flap";
		textSlot4.text = "Tap";
		SceneManager.LoadSceneAsync("Level_1");
	}
}
