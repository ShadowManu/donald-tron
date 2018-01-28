using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Overheat : MonoBehaviour {

    int timer = 0;  //Tiempo que lleva en la misma zona
    Vector3 lastAnchor; //Ancla contra la que se compara la distancia de enfriado
    Vector3 secondLastAnchor; //Segunda ancla para evitar exploits
    public int maxDistance;
    public int overheatVal;
    Color initialColor;
	public Renderer rend;

    public CicloDeJuego gameCycle;

	// Use this for initialization
	void Start () {
        //Inicializa las anclas
        lastAnchor = transform.position;
        secondLastAnchor = transform.position;
        initialColor = rend.material.color;

	}
	
	// Update is called once per frame
	void Update () {
        //Si se sale de la distancia definida, enfria
        double dist = Vector3.Distance(transform.position, lastAnchor);
        if (dist >= maxDistance)
        {
            double dist2 = Vector3.Distance(transform.position, secondLastAnchor);
            if (dist2 >= maxDistance)
            {
                secondLastAnchor = lastAnchor;
                lastAnchor = this.transform.position;
                timer = 0;
            }
        }
        else timer++;

        //rend.material.color = Color.Lerp(rend.material.color, Color.red, Mathf.PingPong(timer, overheatVal));
        rend.material.color = Color.Lerp(initialColor, Color.red, ((float)timer)/overheatVal);



		if (timer > overheatVal){
			var v = Vector3.Lerp (Camera.main.GetComponent<Transform>().position, transform.GetChild(0).transform.position, 0.9f);
			v += new Vector3	 (0, 0, 2);
			Camera.main.GetComponent<Transform>().DOMove (v, 0.5f).SetEase(Ease.OutQuad);
			transform.GetChild (0).transform.GetComponent<Animator> ().SetTrigger ("Dead");

            gameCycle.ActivarGameOver(gameObject.name.Equals("Player1")? "Player2" : "Player1", gameObject);
		}
        //Colocar un indicador visual para el recalentamiento del personaje
    }
}
