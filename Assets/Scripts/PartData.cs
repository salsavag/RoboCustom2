using UnityEngine;
using System.Collections.Generic;

public class PartData : MonoBehaviour
{
	public Transform model = null;
	public string partName = "name";
	public string description = "description";

	void Start()
	{

	}

	override public string ToString()
	{
		return (partName + " (" + model + "): " + description);
	}

	public static List<List<PartData>> GetAllPartData()
	{
		List<List<PartData>> allParts = new List<List<PartData>>();


		// Body
		List<PartData> bodyData = new List<PartData>();

		GameObject[] bodies = Resources.LoadAll<GameObject>("Body");
		foreach(GameObject body in bodies)
		{
			bodyData.Add(body.GetComponent<PartData>());
		}
		allParts.Add(bodyData);

		List<PartData> weaponData = new List<PartData>();

		// weapon left
		GameObject[] weapons = Resources.LoadAll<GameObject>("Weapon");
		foreach(GameObject weapon in weapons)
		{
			weaponData.Add(weapon.GetComponent<PartData>());
		}
		allParts.Add(weaponData);

		// weapon right
		allParts.Add(weaponData);

		// special
		List<PartData> specialData = new List<PartData>();
		
		GameObject[] specials = Resources.LoadAll<GameObject>("Special");
		foreach(GameObject special in specials)
		{
			specialData.Add(special.GetComponent<PartData>());
		}
		allParts.Add(specialData);

		return allParts;
	}
}
