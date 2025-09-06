using UnityEngine;

public class Monster : MonoBehaviour
{
    // ������ ���� ����
    public enum MonsterState { Idle, Attack, Hit, Die }
    public MonsterState currentState;

    // ���� ����
    public int maxHP;
    public int currentHP;
    public int atk;

    // �ִϸ����� ������Ʈ
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHP = maxHP;
        currentState = MonsterState.Idle; // ���� �� ��� ���·� ����
    }

    private void Update()
    {
        // ������ ���¿� ���� �ٸ� �ൿ�� ����
        switch (currentState)
        {
            case MonsterState.Idle:
                // ��� ���� (�� ���� �� ���� ���� ������ ��ȯ)
                break;
            case MonsterState.Attack:
                // ���� ����
                break;
            case MonsterState.Hit:
                // �ǰ� ����
                break;
            case MonsterState.Die:
                // ��� ����
                break;
        }
    }

    // �ܺο��� ȣ��Ǵ� �Լ���
    public void OnPlayerTurnEnd()
    {
        // �÷��̾� ���� ������ ���Ͱ� ���� ���·� ��ȯ
        currentState = MonsterState.Attack;
        animator.SetTrigger("Attack"); // ���� �ִϸ��̼� ���
    }

    public void TakeDamage(int damage)
    {
        // ������ �޾��� �� ����
        currentState = MonsterState.Hit;
        currentHP -= damage;
        animator.SetTrigger("Hit"); // �ǰ� �ִϸ��̼� ���

        if (currentHP <= 0)
        {
            currentState = MonsterState.Die;
            animator.SetTrigger("Die"); // ��� �ִϸ��̼� ���
        }
    }
}