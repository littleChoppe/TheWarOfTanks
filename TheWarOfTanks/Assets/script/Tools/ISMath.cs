using UnityEngine;
using System.Collections;

public class ISMath : MonoBehaviour
{
	public static float Random(ISRange range)
	{
		return UnityEngine.Random.Range (range.min, range.max);
	}
}

[System.Serializable]
public struct ISRange
{
	public float min, max;

	public ISRange (float min, float max)
	{
		this.min = min;
		this.max = max;
	}
}
