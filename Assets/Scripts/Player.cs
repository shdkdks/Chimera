using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ���ݷ°� ���� �Ŵ��� ����
    public int atk = 10;
    public int hp = 100;
    public GameManager gameManager;
    public Monster monster;

    // ���� ��ư�� Ŭ������ �� ȣ��� �Լ�
    public void Attack()
    {
        // �÷��̾��� ���� ���� ���� ����
        if (gameManager.currentTurn == GameManager.Turn.Player)
        {
            Debug.Log("�÷��̾ �����մϴ�.");

            // ���Ϳ��� �������� ������ �Լ� ȣ��
            monster.TakeDamage(atk);

            // ���� �� �� ����
            gameManager.EndTurn();
        }
    }
}