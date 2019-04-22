using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePicker : MonoBehaviour
{
	List<int> counts;
	private static System.Random rnd = new System.Random();

	private void Awake()
	{
		Reset();
	}
	
	public void Reset()
	{
		// タイルごとの設置可能個数
		counts = ((TileType[])Enum.GetValues(typeof(TileType)))
			.Select(tile => tile.Count()).ToList();
	}

	public TileType Pick()
	{
		List<TileType> tiles = new List<TileType>();

		for(var i = 0;i < counts.Count;i++)
		{
			if(counts[i] > 0)
			{
				tiles.Add((TileType)i);
			}
		}

		if(tiles.Count == 0)
		{
			return TileType.Desert;
		}

		var pickTile = tiles[rnd.Next(tiles.Count)];
		counts[(int)pickTile]--;

		return pickTile;
	}
}
