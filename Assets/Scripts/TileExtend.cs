using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileExtend 
{
    public static IEnumerable<Vector3> GetVertices(this Tilemap map, Vector3Int position)
	{
		var center = map.GetCellCenterWorld(position);
		
		// xz => xy形式に直す
		if(map.orientation == Tilemap.Orientation.XZ)
		{
			center.y = center.z;
			center.z = 0;
		}

		var size = map.cellSize / 2;

		// 上半分の頂点を追加
		var deltas = new[]
		{
			new Vector3(size.x, size.y * Mathf.Sin(Mathf.PI / 6f)),
			new Vector3(0, size.y),
			new Vector3(-size.x, size.y * Mathf.Sin(Mathf.PI / 6f))
		}.ToList();

		
		// 下半分を追加
		for(int i = 0;i < 3;i++)
		{
			deltas.Add(new Vector3(deltas[i].x, -deltas[i].y));
		}
		
		// 原点を移動
		return deltas.Select(delta => center + delta);
	}
}
