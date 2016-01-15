using UnityEngine;
using System.Collections;

public class tankCamera : MonoBehaviour {

	public Transform target;
	public Transform deadView;
	public float moveSpeed;
	public float rotateSpeed;

	// Update is called once per frame
	void LateUpdate () {
		if (target) {
			transform.position = target.position;
		}//if
		else {
			//分别是从起点移动到终点和从起点旋转到终点
			transform.position = Vector3.MoveTowards(transform.position, deadView.position, moveSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, deadView.transform.rotation, rotateSpeed * Time.deltaTime);
//			transform.position = deadView.position;
//			transform.rotation = deadView.rotation;
		}
	}
}
