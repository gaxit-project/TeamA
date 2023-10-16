using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class moveturn : MonoBehaviour
{

	public float speed = 2; // スピード：Inspectorで指定

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	void Update()
	{ // ずっと行う
		if (Input.GetKey("d"))
		{ // もし、右キーが押されたら
			transform.position += speed * transform.right * Time.deltaTime;
		}
		if (Input.GetKey("a"))
		{ // もし、左キーが押されたら
			transform.position -= speed * transform.right * Time.deltaTime;
		}
		if (Input.GetKey("w"))
		{ // もし、上キーが押されたら
			transform.position += speed * transform.forward * Time.deltaTime;
		}
		if (Input.GetKey("s"))
		{ // もし、下キーが押されたら
			transform.position -= speed * transform.forward * Time.deltaTime;
		}
		if (Input.GetKey("escape"))
		{ // もし、下キーが押されたら
			Debug.Log("DON!");
			PauseGame();
		}
		if (Input.GetKey("backspace"))
		{ // もし、下キーが押されたら
			Debug.Log("Oh");
			ResumeGame();
		}
	}
	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）
	  // 移動する
	  // this.GetComponent<SpriteRenderer>().flipX = leftFlag;
	}
}
