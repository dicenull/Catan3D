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
		foreach (var pos in FieldUtil.GetPositions())
		{
			var tile = picker.Pick();

			map.SetTile(pos, tiles[(int)tile]);

			if (tile == TileType.Desert)
			{
				swapPos = pos;
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
