using UnityEngine;
using System.Collections.Generic;

public class Utility : MonoBehaviour {

	public static List<Color> colors = new List<Color>();

	public static Transform player1Body;
	public static Transform player1LeftWeapon;
	public static Transform player1RightWeapon;
	public static Transform player1Special;
	public static int player1Primary;
	public static int player1Secondary;

	public static Transform player2Body;
	public static Transform player2LeftWeapon;
	public static Transform player2RightWeapon;
	public static Transform player2Special;
	public static int player2Primary;
	public static int player2Secondary;


	public static void SetColors()
	{
		colors.Add(Color.white);
		colors.Add(Color.red);
		colors.Add(new Color(1.0f, 130.0f/255.0f, 0)); // orange
		colors.Add(Color.yellow);
		colors.Add(new Color(0.0f, 0.7f, 0.0f)); // green
		colors.Add(Color.cyan);
		colors.Add(new Color(0.0f, 56f/255f, 128.0f/255f)); // blue
		colors.Add(Color.magenta);
		colors.Add(Color.black);
		colors.Add(Color.gray);
	}

	public static void SetPrimary(GameObject obj, Color color)
	{
		List<Transform>childsOfGameobject = new List<Transform>();
		childsOfGameobject.Add(obj.transform);

		while(childsOfGameobject.Count > 0)
		{	
			Transform front = childsOfGameobject[0];
			childsOfGameobject.RemoveAt(0);
			if(front.gameObject.name == "primary")
			{
				MeshRenderer renderer = front.gameObject.GetComponent<MeshRenderer>();
				if(renderer != null)
				{
					renderer.material.color = color;
				}
			}
			foreach (Transform trans in front)
			{
				childsOfGameobject.Add (trans);
			}
		}
	}

	public static void SetSecondary(GameObject obj, Color color)
	{
		List<Transform>childsOfGameobject = new List<Transform>();
		childsOfGameobject.Add(obj.transform);
		
		while(childsOfGameobject.Count > 0)
		{	
			Transform front = childsOfGameobject[0];
			childsOfGameobject.RemoveAt(0);
			if(front.gameObject.name == "secondary")
			{
				MeshRenderer renderer = front.gameObject.GetComponent<MeshRenderer>();
				if(renderer != null)
				{
					renderer.material.color = color;
				}
			}
			foreach (Transform trans in front)
			{
				childsOfGameobject.Add (trans);
			}
		}
	}
}
