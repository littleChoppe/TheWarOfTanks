using UnityEngine;
using System.Collections;

public class AItank : unit {
	
	public float moveSpeed = 7;
	public float rotateSpeed;
	public float searchRange;
	public float changeRangeTime;
	public ISRange attackRange;
	public ISRange stopRange;

	private GameObject enemy;
	private tankWeapon tw;
	private NavMeshAgent nam;	//自动寻路，导航
	private LayerMask enemyLayer;
	private float curAttackDistance;
	private float curStopDistance;

	void Start()
	{
		base.Start ();
		nam = GetComponent<NavMeshAgent> ();
		enemyLayer = layerManager.getEnemyLayer (team);
		tw = GetComponent<tankWeapon> ();
		tw.Init (team);
		StartCoroutine (Timer());
	}

	void Update(){
		if (!enemy) {
			searchEnemy();	//如果这帧没有敌人，搜索敌人，下一帧执行
			return;
		}
		float dist = Vector3.Distance (enemy.transform.position, transform.position);

		if (dist > curStopDistance)
			nam.SetDestination (enemy.transform.position);	//以某一坐标自动寻路
		else {
			nam.ResetPath();	//如果距离小于半径停下来
			//瞄准
			Vector3 dir = enemy.transform.position - transform.position;		//对准的方向的三维坐标
			Quaternion wantRotation = Quaternion.LookRotation (dir);	//把一个三维坐标转换为一个四元素
			
			//从自己的角度渐渐旋转到目标的角度
			//从一个方向到另一个方向进行渐进旋转，即有一个过度的效果
			transform.rotation = Quaternion.Slerp(transform.rotation, wantRotation, rotateSpeed * Time.deltaTime); 	
		}

		if (dist < curAttackDistance)
			tw.shoot();
	}

	IEnumerator Timer()
	{
		while (enabled) {
			curAttackDistance = ISMath.Random(attackRange);
			curStopDistance = ISMath.Random(stopRange);
			curStopDistance = Mathf.Min(curStopDistance, curAttackDistance);  //避免停下来以后不开炮
			searchEnemy();
			yield return new WaitForSeconds(changeRangeTime);
		}
	}

	void searchEnemy()
	{
		Collider[] colls = Physics.OverlapSphere (transform.position, searchRange, enemyLayer);

		//找到距离最小的敌人
		if (colls.Length > 0) 
		{
			int minIndex = 0;
			float minDist = Vector3.Distance (colls[0].transform.position, transform.position);
			for (int i=1; i<colls.Length; i++)
			{
				float curDist = Vector3.Distance (colls[i].transform.position, transform.position);
				if (curDist < minDist)
				{
					minIndex = i;
					minDist = curDist;
				}
			} // for
			enemy = colls[minIndex].gameObject;
		}//if
		else {
			nam.ResetPath();
		}
	}//searchEnemy
}//class AItank
