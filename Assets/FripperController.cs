using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の角度
    private float defaultAngle = 20;
    //弾いたあとの角度
    private float flickAngle = -20;

   

  

   

	// Use this for initialization
	void Start () {
        //HingeJointコンポーネントを取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //傾き設定
        SetAngle(this.defaultAngle);

        
      
		
	}
	
	// Update is called once per frame
	void Update () {
        //左矢印を押したとき左フリッパーを弾く
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印を押したとき右フリッパーを弾く
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //矢印を離したときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }



        

        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                
                case TouchPhase.Began:
                    //画面の左側をタップしたとき左フリッパーを弾く
                    if (tag == "LeftFripperTag"&&touch.position.x<Screen.width/2)
                    {
                        SetAngle(this.flickAngle);
                    }
                    //右側をタップしたとき右フリッパーを弾く
                    if (tag == "RightFripperTag" && touch.position.x >= Screen.width / 2)
                    {
                        SetAngle(this.flickAngle);
                    }
                    break;

                case TouchPhase.Ended:
                    //画面の左側から指を離したとき左フリッパーを戻す
                    if (tag == "LeftFripperTag" && touch.position.x < Screen.width / 2)
                    {
                        SetAngle(defaultAngle);
                    }
                    //画面の右側から指を離したとき右フリッパーを戻す
                    if (tag == "RightFripperTag" && touch.position.x >= Screen.width / 2)
                    {
                        SetAngle(defaultAngle);
                    }
                    break;

                
            }
        }



     
        
	}
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
        
    }
}
