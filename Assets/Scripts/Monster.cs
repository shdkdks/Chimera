using UnityEngine;

public class Monster : MonoBehaviour
{
    // 몬스터의 현재 상태
    public enum MonsterState { Idle, Attack, Hit, Die }
    public MonsterState currentState;

    // 몬스터 정보
    public int maxHP;
    public int currentHP;
    public int atk;

    // 애니메이터 컴포넌트
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHP = maxHP;
        currentState = MonsterState.Idle; // 시작 시 대기 상태로 설정
    }

    private void Update()
    {
        // 몬스터의 상태에 따라 다른 행동을 수행
        switch (currentState)
        {
            case MonsterState.Idle:
                // 대기 로직 (턴 종료 시 다음 몬스터 턴으로 전환)
                break;
            case MonsterState.Attack:
                // 공격 로직
                break;
            case MonsterState.Hit:
                // 피격 로직
                break;
            case MonsterState.Die:
                // 사망 로직
                break;
        }
    }

    // 외부에서 호출되는 함수들
    public void OnPlayerTurnEnd()
    {
        // 플레이어 턴이 끝나면 몬스터가 공격 상태로 전환
        currentState = MonsterState.Attack;
        animator.SetTrigger("Attack"); // 공격 애니메이션 재생
    }

    public void TakeDamage(int damage)
    {
        // 공격을 받았을 때 실행
        currentState = MonsterState.Hit;
        currentHP -= damage;
        animator.SetTrigger("Hit"); // 피격 애니메이션 재생

        if (currentHP <= 0)
        {
            currentState = MonsterState.Die;
            animator.SetTrigger("Die"); // 사망 애니메이션 재생
        }
    }
}