using System.Collections;
using System.Collections.Generic;

public enum TileType
{
	Brick,
	Forest,
	Desert,
	Sheep,
	Stone,
	Wheat,
}

public static class CatanStandard
{
	public static readonly int BrickCount = 3;
	public static readonly int StoneCount = 3;
	public static readonly int ForestCount = 4;
	public static readonly int SheepCount = 4;
	public static readonly int WheatCount = 4;
	public static readonly int DesertCount = 1;

	public static int Count(this TileType tile)
	{
		switch(tile)
		{
			case TileType.Brick: return BrickCount;
			case TileType.Stone: return StoneCount;
			case TileType.Forest: return ForestCount;
			case TileType.Sheep: return SheepCount;
			case TileType.Wheat: return WheatCount;
			case TileType.Desert: return DesertCount;
			default: return 0;
		}
	}
}
