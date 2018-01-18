using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ゲームクリアフラグを管理するクラス
 * ゲーム開始時にターゲットとなるオブジェクトを見つけて、
 * オブジェクトが消滅したらゲームクリアとする
 */
public class ClearFlagManager : MonoBehaviour
{
	public GameObject ClearText;

	private bool IsStageClear;
	private GameObject TargetObj;

	void Start()
	{
		IsStageClear = false;
		TargetObj = GameObject.FindGameObjectWithTag("Target");
	}

	void Update()
	{
		if( TargetObj == null && IsStageClear != true ){
			IsStageClear = true;
			ClearText.SetActive( true );
		}
	}

	public bool isStageClear
	{
		get{ return IsStageClear; }
	}
}
