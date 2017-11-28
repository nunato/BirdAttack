using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
	public int deadArea = -2;
	public GameObject playerDeadParticle;

	private RespownManager respownManager;

	void Start()
	{
		GameObject reManager = GameObject.Find("RespownManager");
		respownManager = reManager.gameObject.GetComponent<RespownManager>();
	}

	void Update()
	{
		/* エリア外への移動 */
		if( transform.position.y < deadArea ){
			deadPlayer();
		}
	}

	void OnCollisionEnter( Collision other )
	{
		/* エネミーとの接触 */
		if( other.gameObject.tag == "Enemy" ){
			deadPlayer();
		}
	}

	private void deadPlayer()
	{
		Instantiate( playerDeadParticle, transform.position, Quaternion.identity );
		respownManager.isPlayerDead = true;
		respownManager.ShowDeadText();

		Destroy(gameObject);
	}
}
