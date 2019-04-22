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
		
		foreach(var vec in vecList)
		{
			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			cube.transform.position = vec;
		}
	}
}
