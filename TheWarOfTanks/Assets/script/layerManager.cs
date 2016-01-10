using UnityEngine;
using System.Collections;

public class layerManager : MonoBehaviour {

	static public int greenLayer = 15;
	static public int blueLayer = 16;

	static public LayerMask getEnemyLayer(Team team)
	{
		LayerMask mask = 0;
		switch (team) {
		case Team.Green:
			mask = 1 << blueLayer;
			break;

		case Team.Blue:
			mask = 1 << greenLayer;
			break;
		}
		return mask;
	}
}
