using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    int count = -1;
    int[,] matrix;
    public void Start()
    {
        matrix = new int[3,3];

        for (int i = 0; i < matrix.Length / 3; i++)
        {
            for (int j = 0; j < matrix.Length / 3; j++)
            {
                matrix[i, j] = -1;
            }
        }
    }

    public void onX(PlayerTurn obj)
    {
        matrix[obj.x, obj.y] = obj.var;

        checkWin1stDiag();
        checkWin2ndDiag();
        checkWinRow();
        checkWinCol();
        noWin();
    }

    public void checkWin1stDiag()
    {
        int[] vector = new int[10];
        int k = 0;
        int counterX = 0;
        int counterO = 0;
        for (int i = 0; i < matrix.Length / 3; i++)
        {
            if (matrix[i, i] != -1)
            {
                vector[k] = matrix[i, i];
                k++;
            }
        }

        for (int i = 0; i < k; i++)
        {
            for (int j = i + 1; j < k; j++)
            {
                if (vector[i] == vector[j] && vector[i] == 0)
                    counterX++;

                if (vector[i] == vector[j] && vector[i] == 1)
                {
                    counterO++;
                }

                if (counterO == 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
                else
                if (counterX == 3)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void checkWin2ndDiag()
    {
        int[] vector = new int[10];
        int k = 0;
        int counterX = 0;
        int counterO = 0;
        for (int i = 0; i < matrix.Length / 3; i++)
        {
            if (matrix[2 - i, i] != -1)
            {
                vector[k] = matrix[2 - i, i];
                k++;
            }
        }

        for (int i = 0; i < k; i++)
        {
            for (int j = i + 1; j < k; j++)
            {
                if (vector[i] == vector[j] && vector[i] == 0)
                    counterX++;

                if (vector[i] == vector[j] && vector[i] == 1)
                {
                    counterO++;
                }

                if (counterO == 3)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
                else
                if (counterX == 3)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void checkWinRow()
    {
        int[] vector = new int[10];
        int counterX = 0;
        int counterO = 0;
        int k = 0;
        int number = 0;

        for (int i = 0; i < matrix.Length / 3; i++)
        {
            while (number < matrix.Length / 3)
            {
                if (matrix[i, number] != -1)
                {
                    vector[k] = matrix[i, number];
                    k++;
                }
                number++;
            }

            if (number == matrix.Length / 3)
            {
                for (int l = 0; l < k; l++)
                {
                    for (int j = l + 1; j < k; j++)
                    {
                        if (vector[l] == vector[j] && vector[l] == 0)
                        {
                            counterX++;
                        }

                        if (vector[l] == vector[j] && vector[l] == 1)
                        {
                            counterO++;
                        }

                        if (counterO == 3)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                        }
                        else
                        if (counterX == 3)
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
            }
            number = 0;
            k = 0;
        }
    }

    public void checkWinCol()
    {
        int[] vector = new int[10];
        int counterX = 0;
        int counterO = 0;
        int k = 0;
        int number = 0;

        for (int i = 0; i < matrix.Length / 3; i++)
        {
            while (number < matrix.Length / 3)
            {
                if (matrix[number, i] != -1)
                {
                    vector[k] = matrix[number, i];
                    k++;
                }
                number++;
            }

            if (number == matrix.Length / 3)
            {
                for (int l = 0; l < k; l++)
                {
                    for (int j = l + 1; j < k; j++)
                    {
                        if (vector[l] == vector[j] && vector[l] == 0)
                        {
                            counterX++;
                        }

                        if (vector[l] == vector[j] && vector[l] == 1)
                        {
                            counterO++;
                        }

                        if (counterO == 3)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                        }
                        else
                        if (counterX == 3)
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
            }
            number = 0;
            k = 0;
        }
    }

    public void noWin()
    {
        int countX = 0;
        int countO = 0;

        for (int i = 0; i < matrix.Length / 3; i++)
        {
            for (int j = 0; j < matrix.Length / 3; j++)
            {
                if (matrix[i, j] != -1)
                {
                    if (matrix[i, j] == 0)
                        countX++;
                    if (matrix[i, j] == 1)
                        countO++;
                }
            }
        }

        if (countX == 5 & countO == 4)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public int nextTurn()
    {
        count++;
        return count % 2;
    }
}
