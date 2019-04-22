using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetter : MonoBehaviour
{
	List<TileBase> tiles = new List<TileBase>();
	TilePicker picker;

	void setTiles()
	{
		var map = GetComponent<Tilemap>();
		picker.Reset();

		var swapPos = new Vector3Int(0, 0, 0);
		const int size = 5;
		for(var x = 0; x < size;x++)
		{
			for (var y = 0; y < size; y++)
			{
				var pos = new Vector3Int(x - size / 2, y - size / 2, 0);

				if (pos.x == 2 && pos.y != 0
					|| Math.Abs(pos.x) == 2 && Math.Abs(pos.y) == 2)
				{
					continue;
				}
				Debug.Log(pos);

				var tile = picker.Pick();

				map.SetTile(pos, tiles[(int)tile]);

				if(tile == TileType.Desert)
				{
					swapPos = pos;
				}
			}
		}

		// 原点のタイルと砂漠タイルを交換する
		map.SetTile(swapPos, map.GetTile(Vector3Int.zero));
		map.SetTile(Vector3Int.zero, tiles[(int)TileType.Desert]);

	}

	private void Start()
	{
		setTiles();
	}

	private void Awake()
	{
		picker = gameObject.AddComponent<TilePicker>();

		for(int i = 0;i < Enum.GetNames(typeof(TileType)).Length; i++)
		{
			tiles.Add(Resources.Load<TileBase>($"tiles_{i}"));
		}
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			setTiles();
		}
	}
}
