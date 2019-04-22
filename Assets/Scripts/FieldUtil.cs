using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FieldUtil
{
	public static IEnumerable<Vector3Int> GetPositions()
	{
		const int size = 5;
		for (var x = 0; x < size; x++)
		{
			for (var y = 0; y < size; y++)
			{
				var pos = new Vector3Int(x - size / 2, y - size / 2, 0);

				if (pos.x == 2 && pos.y != 0
					|| Mathf.Abs(pos.x) == 2 && Mathf.Abs(pos.y) == 2)
				{
					continue;
				}

				yield return pos;
			}
		}
	}
}
