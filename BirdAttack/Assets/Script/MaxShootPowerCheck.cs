using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 最大パワーに丸める
 */
public static class MaxShootPowerCheck
{
	public static float MaxPower = 200f;

	public static Vector3 LimitShootVector( Vector3 ShootVector )
	{
		Vector3 LimitVector = Vector3.zero;

		if( ShootVector.x > MaxPower ){
			float crop = MaxPower / ShootVector.x;

			LimitVector.x = ShootVector.x * crop;
			LimitVector.y = ShootVector.y * crop;
		}

		if( ShootVector.y > MaxPower ){
			float crop = MaxPower / ShootVector.y;

			LimitVector.x = ShootVector.x * crop;
			LimitVector.y = ShootVector.y * crop;
		}

		return LimitVector;
	}
}
