using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class Premove : MonoBehaviour {

	public float speed = 2; // スピード：Inspectorで指定

	float vx = 0;
	float vy = 0;
	bool leftFlag = false;

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	void Update () { // ずっと行う
		vx = 0;
		vy = 0;
		if(Input.GetKey("right")) { // もし、右キーが押されたら
			vx = speed; // 右に進む移動量を入れる
			leftFlag = false;
		}
		if(Input.GetKey("left")) { // もし、左キーが押されたら
			vx = -speed; // 左に進む移動量を入れる
			leftFlag = true;
		}
		if(Input.GetKey("up")) { // もし、上キーが押されたら
			vy = speed; // 上に進む移動量を入れる
		}
		if(Input.GetKey("down")) { // もし、下キーが押されたら
			vy = -speed; // 下に進む移動量を入れる
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
	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		// 移動する
		this.transform.Translate(vx/50, vy/50, 0);
		// 左右の向きを変える
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
	}
}
