using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 공격력과 게임 매니저 참조
    public int atk = 10;
    public int hp = 100;
    public GameManager gameManager;
    public Monster monster;

    // 공격 버튼을 클릭했을 때 호출될 함수
    public void Attack()
    {
        // 플레이어의 턴일 때만 공격 가능
        if (gameManager.currentTurn == GameManager.Turn.Player)
        {
            Debug.Log("플레이어가 공격합니다.");

            // 몬스터에게 데미지를 입히는 함수 호출
            monster.TakeDamage(atk);

            // 공격 후 턴 종료
            gameManager.EndTurn();
        }
    }
}