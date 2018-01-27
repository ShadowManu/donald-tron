using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CicloDeJuego : MonoBehaviour {
        bool GameOver;
        bool Pausa;
        public GameObject Jugador1;
        public GameObject Jugador2;
        public Vector3 PosiInicialJugador1;
        public Vector3 PosiInicialJugador2;
        public Quaternion RotaInicialJugador1;
        public Quaternion RotaInicialJugador2;
        public MovementComponent movimientoJugador1;
        public MovementComponent movimientoJugador2;
	// Use this for initialization
	void Start () {
            RestablecerJuego();
	}
	
    void OnEnable()
    {
        EventManager.OnCollisionAction += ejemplo;
    }

    void OnDisable()
    {
        EventManager.OnCollisionAction -= ejemplo;
    }

    void ejemplo(Collision collision, GameObject target)
    {
        Debug.Log(collision);
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
                        IniciarJuego();
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
            Vector3 PosicionJugador1 = PosiInicialJugador1;
            Vector3 PosicionJugador2 = PosiInicialJugador2;
            Quaternion RotacionJugador1 = RotaInicialJugador1;
            Quaternion RotacionJugador2 = RotaInicialJugador2;
            Jugador1.GetComponent<Transform>().position = PosicionJugador1;
            Jugador2.GetComponent<Transform>().position = PosicionJugador2;
            Jugador1.GetComponent<Transform>().rotation = RotacionJugador1;
            Jugador2.GetComponent<Transform>().rotation = RotacionJugador2;

            GameOver = false;
            Pausa = true;
        }
        void IniciarJuego(){
            movimientoJugador1.enabled = true;
            movimientoJugador2.enabled = true;
            GameOver = false;
            Pausa = false;
        }
        void ActivarGameOver(){
            movimientoJugador1.enabled = false;
            movimientoJugador2.enabled = false;
            GameOver = true;
            Pausa = true;
        }

}
