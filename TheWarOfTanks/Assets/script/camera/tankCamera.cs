using UnityEngine;
using System.Collections;

public class tankCamera : MonoBehaviour {

	public Transform target;

	// Update is called once per frame
	void LateUpdate () {
		if (!target)
			return;

		transform.position = target.position;
	}
}
