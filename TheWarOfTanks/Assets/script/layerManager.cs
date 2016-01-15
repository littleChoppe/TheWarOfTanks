using UnityEngine;
using System.Collections;

//区分敌我
public class layerManager : MonoBehaviour {

	static public int greenLayer = 15;
	static public int blueLayer = 16;
	static public int purpleLayer = 17;
	static public int redLayer = 18;

	static public LayerMask getEnemyLayer(Team team)
	{
		//LayerMask的变量是一个长度为32的二进制数组，数组元素存 0 或 1 相当于标志位
		LayerMask mask = 0;
		switch (team) {
		case Team.Green:
			mask = (1 << blueLayer) | (1 << purpleLayer) | (1 << redLayer);
			break;

		case Team.Blue:
			mask = (1 << greenLayer) | (1 << purpleLayer) | (1 << redLayer);
			break;

		case Team.Purple:
			mask = (1 << blueLayer) | (1 << greenLayer) | (1 << redLayer);
			break;

		case Team.Red:
			mask = (1 << blueLayer) | (1 << purpleLayer) | (1 << greenLayer);
			break;
		}
		return mask;
	}
}
