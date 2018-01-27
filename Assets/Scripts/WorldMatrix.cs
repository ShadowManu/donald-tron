using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMatrix : MonoBehaviour {

    //Clase de ayuda que contiene el color de la matriz 
    class MatrixObject
    {
        public int color { get; set; }
        public int[] overHeat { get; set; }

        public MatrixObject(int players)
        {
            overHeat = new int[players];
        }

    }

    public int bikeWidth = 3;
    public int numeroArbitrario = 1;
    public GameObject[] players = new GameObject[4];
    MatrixObject[,] matrix;

    // Use this for initialization
    void Start() {

        Renderer renderer = GetComponent<Renderer>();

        float heightOriginal = renderer.bounds.size.z;
        float widthOriginal = renderer.bounds.size.x;

        //Se considera que el tamaño de la pantalla no se modifica durante la corrida
        int height = (int) heightOriginal * numeroArbitrario;
        int width = (int) widthOriginal * numeroArbitrario;
        matrix = new MatrixObject[height, width];
        //Inicializacion de objetos vacíos
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                matrix[i, j] = new MatrixObject(4);
            }
        }
	}
	
    void Update()
    {
        for(int i = 0; i < players.Length; i++)
        {
            var oldPosition = players[i].GetComponent<MovementComponent>().oldPosition;
            colorear( (int) players[i].transform.position.x, (int) players[i].transform.position.z, i+1, (int) oldPosition.x, (int) oldPosition.z);
        }
    }

    //TODO falta verificacion de bordes
    //Verifica colisión en un cuadrado basado en el punto actual y el último punto
    //True: chocó, False: no chocó
    public bool haceColision(int x, int y, int playerNumber, int oldX, int oldY)
    {
        //Verificar division entre 0
        if (x - oldX != 0)
        {
            //Se calcula la pendiente y el desplazamiento con la ecuación de la recta
            double m = (oldY - y) / (oldX - x);
            double b = oldY - oldX * m;
            //Se mueve en cada paso de x hasta cubrir el area
            for (int i = 0; i <= Math.Abs(x - oldX); i++)
            {
                //Verifica si esta avanzando o retrocediendo y se mueve en esa direccion
                int stepX = x < oldX ? oldX - i : oldX + i;
                int stepY = (int)(m * stepX + b);

                //Si hay un color distinto del de el jugador, choca
                if (matrix[stepX, stepY].color != 0 && matrix[stepX, stepY].color != playerNumber ) return true;
                for (int j = 0; j < bikeWidth; j++)
                {
                    if (matrix[stepX, stepY + j].color != 0 && matrix[stepX, stepY + j].color != playerNumber) return true;
                    if (matrix[stepX, stepY - j].color != 0 && matrix[stepX, stepY - j].color != playerNumber) return true;
                }
            }
        }
        else
        {
            //Se calcula la pendiente basado en 'y' en vez de 'x'
            double m = (oldX - x) / (oldY - y);
            double b = oldY - oldX * m;
            for (int i = 0; i <= Math.Abs(y - oldY); i++)
            {
                int stepY = y < oldY ? oldX - i : oldX + i;
                int stepX = (int)(m * stepY + b);

                if (matrix[stepX, stepY].color != 0 && matrix[stepX, stepY].color != playerNumber) return true;
                for (int j = 0; j < bikeWidth; j++)
                {
                    if (matrix[stepX + j, stepY].color != 0 && matrix[stepX + j, stepY].color != playerNumber) return true;
                    if (matrix[stepX - j, stepY].color != 0 && matrix[stepX - j, stepY].color != playerNumber) return true;
                }
            }
        }
        return false;
    }

    //TODO falta verificacion de bordes
    public void colorear(int x, int y, int playerNumber, int oldX, int oldY)
    {
        //Verificar division entre 0
        if (x - oldX != 0)
        {
            //Se calcula la pendiente y el desplazamiento con la ecuación de la recta
            double m = (oldY - y) / (oldX - x);
            double b = oldY - oldX * m;
            //Se mueve en cada paso de x hasta cubrir el area
            for (int i = 0; i <= Math.Abs(x - oldX); i++)
            {
                //Verifica si esta avanzando o retrocediendo y se mueve en esa direccion
                int stepX = x < oldX ? oldX - i : oldX + i;
                int stepY = (int)(m * stepX + b);

                //Colorea el punto
                matrix[stepX, stepY].color = playerNumber;
                //Colorea las posiciones arriba y abajo del punto para crear un rectangulo
                for (int j = 0; j < bikeWidth; j++)
                {
                    matrix[stepX, stepY + j].color = playerNumber;
                    matrix[stepX, stepY - j].color = playerNumber;
                }
            }
        }
        else
        {
            //Se calcula la pendiente basado en 'y' en vez de 'x'
            double m = (oldX - x) / (oldY - y);
            double b = oldY - oldX * m;
            for (int i = 0; i <= Math.Abs(y - oldY); i++)
            {
                int stepY = y < oldY ? oldX - i : oldX + i;
                int stepX = (int)(m * stepY + b);

                //Colorea el punto
                matrix[stepX, stepY].color = playerNumber;
                //Colorea las posiciones arriba y abajo del punto para crear un rectangulo
                for (int j = 0; j < bikeWidth; j++)
                {
                    matrix[stepX + j, stepY].color = playerNumber;
                    matrix[stepX - j, stepY].color = playerNumber;
                }
            }
        }
    }
}
