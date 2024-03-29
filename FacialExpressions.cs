﻿using UnityEngine;
using System.Collections;

public class FacialExpressions : MonoBehaviour {

	//Script containing levels of emotions
	ImageResultsParser userEmotions;

	//player Transform used to obtain reference to UserEmotions script
	Transform player;

	//Used to change the face from smiling to frowning
	public Renderer faceRenderer;

	private Material faceMaterial;
	private Vector2 uvOffset;
	private Rigidbody rb;

	// Initialization and Setting references
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Sailor").transform;
		userEmotions = player.GetComponent<ImageResultsParser> ();
		uvOffset = Vector2.zero;
		faceMaterial = faceRenderer.materials[1];
		rb = GetComponent<Rigidbody> ();
	}

	// Setting the user's dominant emotion every frame
	void Update () {
		if (userEmotions.joyLevel > 40) {
			setJoyful ();
		} else if (userEmotions.sadnessLevel > 40) {
			setSad ();
		} else if (userEmotions.surpriseLevel > 40) {
			setSurprise ();
		} else {
			setIdle ();
		}
	}

	//sets the Character's emotion to Idle (Emotionless)
	void setIdle(){
		uvOffset = new Vector2(0, 0);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
	}

	//sets the Character's emotion to Joyful (Smiling)
	void setJoyful() {
		uvOffset = new Vector2(0.25f, 0);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
		Vector3 movement = new Vector3 (1, 0, 0);
		rb.AddForce (movement);
	}

	//sets the Character's emotion to Sad (Frowning)
	void setSad() {
		uvOffset = new Vector2(0, -0.25f);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
		Vector3 movement = new Vector3 (-1, 0, 0);
		rb.AddForce (movement);
	}

	//sets the Character's emotion to Surprised
	void setSurprise() {
		uvOffset = new Vector2(0.25f, 0);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
		Vector3 movement = new Vector3 (10, 100, -50);
		rb.AddForce (movement);
	}
}


//
//using UnityEngine;
//using System.Collections;
//
//[RequireComponent (typeof(Animator))]
//public class FacialExpressions : MonoBehaviour {
//
//	public Renderer FaceRenderer;
//
//	private Material faceMaterial;
//	private Vector2 uvOffset;
//	private Animator animator;
//
//	// Use this for initialization
//	void Start () {
//		uvOffset = Vector2.zero;
//		faceMaterial = FaceRenderer.materials[1];
//		animator = gameObject.GetComponent<Animator>();
//	}
//
//	// Update is called once per frame
//	void Update () {
//		// This is hardcoded to set the correct face based on the Animator state
//		AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo (0);
//
//		if (animState.IsName ("Idle"))
//			uvOffset = new Vector2(0, 0);
//		else if (animState.IsName ("Happy"))
//			uvOffset = new Vector2(0.25f, 0);
//		else if (animState.IsName ("Sad"))
//			uvOffset = new Vector2(0, -0.25f);
//		else
//			uvOffset = new Vector2(0.25f, -0.25f);
//
//		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
//	}
//}
