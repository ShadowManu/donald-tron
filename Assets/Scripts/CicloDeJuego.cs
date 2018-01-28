using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CicloDeJuego : MonoBehaviour
{
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
    public Overheat overheatJugador1;
    public Overheat overheatJugador2;

    void Start()
    {
        RestablecerJuego();
    }

    void OnEnable()
    {
        EventManager.OnCollisionAction += onCollision;
    }

    void OnDisable()
    {
        EventManager.OnCollisionAction -= onCollision;
    }

    void onCollision(GameObject collision, GameObject target)
    {
        GameOver = true;
        Pausa = false;

        ActivarGameOver(target.name, collision);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Pausar()
    {
        Pausa = true;
    }
    void RestablecerJuego()
    {
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
    void IniciarJuego()
    {
        movimientoJugador1.enabled = true;
        movimientoJugador2.enabled = true;
        GameOver = false;
        Pausa = false;
    }
    public void ActivarGameOver(string winner, GameObject loser)
    {
        movimientoJugador1.enabled = false;
        movimientoJugador2.enabled = false;

        overheatJugador1.enabled = false;
        overheatJugador2.enabled = false;

		var v = Vector3.Lerp (Camera.main.GetComponent<Transform>().position, loser.transform.GetChild(0).transform.position, 0.9f);
		v += new Vector3(0, 0, 2);
		Camera.main.GetComponent<Transform>().DOMove (v, 0.5f).SetEase(Ease.OutQuad);
        loser.transform.GetChild(0).transform.GetComponent<Animator> ().SetTrigger ("Dead");

        var loserRender = loser.GetComponent<MeshRenderer>();
        loserRender.enabled = false;

        var loserCollider = loser.GetComponent<BoxCollider>();
        loserCollider.enabled = false;

        EventManager.CallOnWinnerAction(winner);

        Debug.Log(winner);

        GameOver = true;
        Pausa = true;
    }

}
