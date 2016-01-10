using UnityEngine;
using System.Collections;

public class AItank : unit {

	public Transform player;
	public float moveSpeed = 7;
	public float attackRange = 10;
	public float shootCoolDown = 1;
	public float rotateSpeed;

	private tankWeapon tw;
	private NavMeshAgent nam;	//自动寻路，导航
	private float timer;

	void Start()
	{
		nam = GetComponent<NavMeshAgent> ();
		tw = GetComponent<tankWeapon> ();
		tw.Init (team);
	}

	void Update()
	{
		if (!player) return;

		timer += Time.deltaTime;

		float dist = Vector3.Distance (player.position, transform.position);

		//瞄准
		Vector3 dir = player.position - transform.position;		//对准的方向的三维坐标
		Quaternion wantRotation = Quaternion.LookRotation (dir);	//把一个三维坐标转换为一个四元素
		//从自己的角度渐渐旋转到目标的角度
		transform.rotation = Quaternion.Slerp(transform.rotation, wantRotation, rotateSpeed * Time.deltaTime); 	//从一个方向到另一个方向进行渐进旋转，即有一个过度的效果
		if (dist > attackRange)
			nam.SetDestination (player.position);	//以某一坐标自动寻路
		else {
			nam.ResetPath();
			transform.LookAt (player.position);
			if (timer > shootCoolDown) {
				tw.shoot();
				timer = 0;
			}
		}
	}
}
