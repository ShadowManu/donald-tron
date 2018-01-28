using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Intro : MonoBehaviour {

	public Transform end;
	public Transform camera;

	// Use this for initialization
	void Start () {
		camera.DORotate(end.eulerAngles, 1).SetEase(Ease.OutQuad);
		camera.DOMove(end.position, 1).SetEase(Ease.OutQuad);
	}
}
