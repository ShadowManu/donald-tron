using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overheat : MonoBehaviour {

    int timer = 0;  //Tiempo que lleva en la misma zona
    Vector3 lastAnchor; //Ancla contra la que se compara la distancia de enfriado
    Vector3 secondLastAnchor; //Segunda ancla para evitar exploits
    public int maxDistance;
    public int overheatVal;
    Color initialColor;

	// Use this for initialization
	void Start () {
        //Inicializa las anclas
        lastAnchor = transform.position;
        secondLastAnchor = transform.position;
        initialColor = GetComponent<Renderer>().material.color;
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

        Renderer rend = GetComponent<Renderer>();
        //rend.material.color = Color.Lerp(rend.material.color, Color.red, Mathf.PingPong(timer, overheatVal));
        rend.material.color = Color.Lerp(initialColor, Color.red, ((float)timer)/overheatVal);

        if (timer > overheatVal) Debug.Log("Game Over"); //GAME OVER
        //Colocar un indicador visual para el recalentamiento del personaje
    }
}
