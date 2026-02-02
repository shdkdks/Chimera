using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Win,
    Lose
}
public class BattleManager : MonoBehaviour
{
    public BattleState state;

    void Start()
    {
        state = BattleState.Start;
        StartBattle();
    }

    void StartBattle() //전투 시작
    {
        Debug.Log("Battle Start");
        state = BattleState.PlayerTurn;
        Debug.Log("Player Turn");
    }

    //플레이어
    public void PlayerAttack()// 공격
    {
        if (state != BattleState.PlayerTurn) return;

        Debug.Log("Player Attacks!");
        EndPlayerTurn();
    }

    public void PlayerDefend() // 방어
    {
        if (state != BattleState.PlayerTurn) return;

        Debug.Log("Player Defends!");
        EndPlayerTurn();
    }

    public void PlayerUseItem() //아이템
    {
        if (state != BattleState.PlayerTurn) return;

        Debug.Log("Player Uses Item!");
        EndPlayerTurn();
    }

    public void PlayerUseSkill() //스킬사용
    {
        if (state != BattleState.PlayerTurn) return;

        Debug.Log("Player Uses Skill!");
        EndPlayerTurn();
    }

    public void EndPlayerTurn() //턴종료
    {
        state = BattleState.EnemyTurn;
        Debug.Log("Enemy Turn");
        EnemyAction();
    }

    //적
    void EnemyAction() //적행동
    {
        Debug.Log("Enemy Attacks!");
        EndEnemyTurn();
    }

    void EndEnemyTurn() //적 턴종료
    {
        state = BattleState.PlayerTurn;
        Debug.Log("Player Turn");
    }
}
