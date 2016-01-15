using UnityEngine;
using System.Collections;

public class ISExplosion : MonoBehaviour
{
	public float explosionRadius;
	public float explosionForce;
	void Start ()
	{
		//子弹碰撞捉到的碰撞器，第一个参数是碰撞位置，第二个参数是捉碰撞器的半径,这个函数返回碰撞器数组
		//最后一个参数获得层级，即只获取敌人的碰撞器
		Collider[] colls = Physics.OverlapSphere (transform.position, explosionRadius);	
		if (colls.Length > 0) 
		{
			for (int i=0; i<colls.Length; i++) 
			{
				Rigidbody r = colls [i].GetComponent<Rigidbody> ();
				
				//如果获取到地板或者场景里没有刚体的物体其刚体的值为NULL 则不发生爆炸力场
				if (r)
					//AddExplosionForce(爆炸力， 爆炸位置， 爆炸半径);
					r.AddExplosionForce (explosionForce, transform.position, explosionRadius);
			}//for
		}//if
	}//Start
}//class ISExplosion