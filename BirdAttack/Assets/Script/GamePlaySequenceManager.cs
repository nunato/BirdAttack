using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ゲームのシーケンスを管理するクラス
 * ステージスタート
 * ↓
 * タッチ
 * ↓
 * プレイヤーを発射
 * ↓
 * プレイヤーの停止
 * ↓
 * 初期位置に戻して次のタッチを待つ
 *
 */
public enum GameSequenceState
{
	IDLE,
	SHOOT,
	MOVE,
}

public class GamePlaySequenceManager : MonoBehaviour
{
	private static GameSequenceState GameState;
	/* 初期化 */
	void Start()
	{
		GameState = GameSequenceState.IDLE;
	}

	public GameSequenceState PlayerState
	{
		set{ GameState = value; }
		get{ return GameState; }
	}
}
