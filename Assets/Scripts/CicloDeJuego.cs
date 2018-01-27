using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CicloDeJuego : MonoBehaviour {
        bool GameOver;
        bool Pausa;
        public GameObject Jugador1;
        public GameObject Jugador2;
        public Vector3 InicialJugador1;
        public Vector3 InicialJugador2;
        
	// Use this for initialization
	void Start () {
            RestablecerJuego();
	}
	
	// Update is called once per frame
	void Update () {
            if (Pausa){
            //Evitar que los jugadores se muevan
                
                if (GameOver){
                    if (Input.GetButtonDown("Fire1")){
                        RestablecerJuego();
                        Debug.Log("JUEGO NUEVO");
                    }
                    //Mostrar quien gano
                }
                else{
                    if (Input.GetButtonDown("Fire1")){
                        ActivarIniciarJuego();
                        Debug.Log("PAUSA");
                    }
                    //Mostrar que se esta en pausa
                }
            }   
            else{
                if (GameOver){
                    //Error no deberias estar corriendo si estas en game over
                }
                else{
                    if (Input.GetButtonDown("Fire1")){
                        ActivarGameOver();
                        Debug.Log("Game OVER");
                    }
                    //Jugar de manera normal
                }
            }
	}
        void Pausar () {
            Pausa = true;
        }
        void RestablecerJuego(){
            Vector3 PosicionJugador1 = InicialJugador1;
            Vector3 PosicionJugador2 = InicialJugador2;
            Jugador1.GetComponent<Transform>().position = PosicionJugador1;
            Jugador2.GetComponent<Transform>().position = PosicionJugador2;
            GameOver = false;
            Pausa = true;
        }
        void ActivarIniciarJuego(){
            GameOver = false;
            Pausa = false;
        }
        void ActivarGameOver(){
            GameOver = true;
            Pausa = true;
        }

}
