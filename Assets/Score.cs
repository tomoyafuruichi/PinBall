using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    //点数を表示するテキスト
    private GameObject scoreText;
    //点数
    private int score = 0;


	// Use this for initialization
	void Start () {
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
		
	}
	
	// Update is called once per frame
	void Update () {
        //点数の型を変換
        string score=(this.score).ToString();

        //点数を表示
        this.scoreText.GetComponent<Text>().text = score;

		
	}

    //衝突時にオブジェクトごとに点数加算
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.score += 50;
        }else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.score += 20;
        }else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.score += 10;
        }else if (collision.gameObject.tag == "SmallStarTag")
        {
            this.score += 5;
        }
    }
}
