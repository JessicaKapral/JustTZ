using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerColllision : MonoBehaviour
{
    public int score = 0;
    public Text coinScore;

    public GameObject player;
    public GameObject winPanel;
    public GameObject losePanel;

    private void Update()
    {
        PlayerWin();
    }

    private void OnTriggerEnter(Collider other) // ��� ����������, ����� ����� ������������ � ��������, ���������� ������������ �����
    {
        if (other.gameObject.tag == "Coin")
        {
            score++;
            other.gameObject.SetActive(false);
            coinScore.text = score.ToString();
        }
        else if (other.gameObject.tag == "Spike")
        {
            Destroy(player);
            losePanel.SetActive(true);
        }

      
    }

    private void PlayerWin() // ���� ����� ������ ��� �������, � �� ���� � �������� �� �������� �������� ����� - ����� �������
    {
        GameObject[] coins;
        coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins.Length == 0)
        {
            winPanel.SetActive(true);
        }
    }


}
