using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestCubeSetter : MonoBehaviour
{
	[SerializeField]
	Tilemap map;

	private void Awake()
	{
		var vecs = map.GetVertices(new Vector3Int(0, 0, 0));

		foreach(var vec in vecs)
		{
			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			cube.transform.position = vec;
		}
	}
}
