using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public float player1Health;
	public float player2Health;

	public Texture healthLeft;
	public Texture totalHealth;
	public Texture overlay;

	private float spacing = Screen.width / 100;

	private float buttonWidth;
	private float buttonHeight = Screen.height / 20;

	public bool paused;

	// Use this for initialization
	void Start () {
		buttonWidth = Screen.width * .4f - spacing * 2;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.C))
		{
			float amount = Random.Range(0,20);
			TakeDamagePlayer1(amount);
			TakeDamagePlayer2(amount);
		}
		if (Input.GetKeyDown (KeyCode.P))
		{
			Pause();
		}
	}

	public void Pause()
	{
		paused = true;
	}

	public void TakeDamagePlayer1(float amount)
	{
		player1Health -= amount;
		if(player1Health < 0) player1Health = 0;
	}

	public void TakeDamagePlayer2(float amount)
	{
		player2Health -= amount;
		if(player2Health < 0) player2Health = 0;
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (spacing/2, spacing/2, (Screen.width - 4 * spacing) / 2 + spacing, spacing * 2 + spacing), overlay);
		GUI.DrawTexture (new Rect (Screen.width - spacing/2 - (Screen.width - 4*spacing) / 2 - spacing, spacing/2, (Screen.width - 4*spacing) / 2 + spacing, spacing*2 + spacing ), overlay);

		GUI.DrawTexture(new Rect(spacing, spacing, (Screen.width - 4*spacing) / 2, spacing*2 ), totalHealth);
		GUI.DrawTexture(new Rect(spacing, spacing, (Screen.width - 4*spacing) / 2 * (player1Health / 100), spacing*2 ), healthLeft);
	
		GUI.DrawTexture(new Rect(Screen.width - spacing - (Screen.width - 4*spacing) / 2, spacing, (Screen.width - 4*spacing) / 2, spacing*2 ), totalHealth);
		GUI.DrawTexture(new Rect(Screen.width - spacing - (Screen.width - 4*spacing) / 2 + ((Screen.width - 4*spacing) / 2 - (Screen.width - 4*spacing) / 2 * (player2Health / 100)), spacing, (Screen.width - 4*spacing) / 2 * (player2Health / 100), spacing*2 ), healthLeft);

		if (paused)
		{
			GUI.BeginGroup(new Rect(Screen.width * .3f, Screen.height * .3f, Screen.width * .4f, Screen.height * .4f));
			GUI.Box (new Rect(0,0,Screen.width * .4f, Screen.height * .2f), "Pause Menu");
			if(GUI.Button (new Rect(spacing, spacing * 3, buttonWidth, buttonHeight), "Resume"))
			{
				paused = false;
			}
			if(GUI.Button (new Rect(spacing, spacing * 4 + buttonHeight, buttonWidth, buttonHeight), "Quit"))
			{
				Application.LoadLevel("MainMenu");
			}
			GUI.EndGroup();
		}
	}
}
