using UnityEngine;
using System.Collections.Generic;

public class Utility : MonoBehaviour {
	
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
