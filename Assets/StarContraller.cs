﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContraller : MonoBehaviour {
    //回転速度
    private float rotSpeed = 1.0f;




	// Use this for initialization
	void Start () {
        //初期角度
        this.transform.Rotate(0, Random.Range(0,360), 0);
	}
	
	// Update is called once per frame
	void Update () {

        //回転
        this.transform.Rotate(0, this.rotSpeed, 0);
		
	}
}
