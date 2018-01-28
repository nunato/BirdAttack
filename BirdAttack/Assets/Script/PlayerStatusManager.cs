using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * プレイヤーの状態を管理するクラス
 * ステージスタート
 * ↓
 * 待機
 * ↓
 * プレイヤーを発射
 * ↓
 * プレイヤーの停止
 * ↓
 * 待機に戻る
 */
public enum PLAYER_STATUS_T
{
	IDLE,	/* 待機 */
	SHOOT,	/* 発射 */
	MOVE,	/* 動作中 */
}

public class PlayerStatusManager : MonoBehaviour
{
	private static PLAYER_STATUS_T State;
	/* 初期化 */
	void Start()
	{
		State = PLAYER_STATUS_T.IDLE;
	}

	public PLAYER_STATUS_T PlayerStatus
	{
		set{ State = value; }
		get{ return State; }
	}
}
