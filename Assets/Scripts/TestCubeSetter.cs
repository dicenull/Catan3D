using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestCubeSetter : MonoBehaviour
{
	[SerializeField]
	Tilemap map;

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
			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.SetParent(transform);
			cube.transform.localScale = 0.2f * Vector3.one;
			cube.transform.position = new Vector3(vec.x, vec.z, vec.y);
			cube.name = $"{index}";

			index++;
		}
		
	}
}
