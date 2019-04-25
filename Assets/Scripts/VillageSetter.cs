using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Photon.Pun;

public class VillageSetter : MonoBehaviourPunCallbacks
{
	[SerializeField]
	Tilemap map;

	List<GameObject> villageUnits = new List<GameObject>();

	List<GameObject> villages = new List<GameObject>();

	private void Awake()
	{
		HashSet<Vector3> vecList = new HashSet<Vector3>();

		foreach(var pos in FieldUtil.GetPositions())
		{
			foreach(var vec in map.GetVertices(pos))
			{
				vecList.Add(vec);
			}
		}

		var index = 0;
		foreach(var vec in vecList)
		{
			var village = Instantiate(Resources.Load<GameObject>("Prefabs/VillageUnit"), transform);
			village.transform.localScale = 0.2f * Vector3.one;
			village.transform.position = new Vector3(vec.x, vec.z, vec.y);
			village.name = $"{index}";

			villageUnits.Add(village);

			index++;
		}
		
	}

	public void Activate()
	{
		villageUnits.ForEach(vill => vill.SetActive(true));
	}

	public void Inactivate()
	{
		villageUnits.ForEach(vill => vill.SetActive(false));
	}

	[PunRPC]
	public void CreateVillage(GameObject unit, Color color)
	{
		Inactivate();
		villageUnits.Remove(unit);

		var village = 
			PhotonNetwork.Instantiate("Prefabs/Village", unit.transform.position, Quaternion.identity);

		village.GetComponent<Renderer>().material.color = color;
		villages.Add(village);
	}
}
