using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("스폰할 UI")]
    public GameObject[] uiPrefabs;

    [Header("UI 스폰 위치")]
    public Transform[] uiSpawnPoints;

    [Header("캔버스")]
    public Transform canvas;

    public enum Turn { Player, Monster }
    public Turn currentTurn;
    public Player player;
    public Monster monster;

    void Awake()
    {
        Onload();
    }
    void Start()
    {
        // 게임 시작 시 플레이어의 턴으로 설정
        currentTurn = Turn.Player;
        Debug.Log("플레이어의 턴입니다.");
        SpawnUI();
    }

    void SpawnUI()
    {
        // 무작위 생성
        GameObject[] shuffled = ShuffleArray(uiPrefabs);

        for (int i = 0; i < 3; i++)
        {        
            // 섞인 프리팹 중 i번째 것을 지정된 위치에 생성
            GameObject ui = Instantiate(
                shuffled[i],                         // 생성할 UI 프리팹
                uiSpawnPoints[i].position,           // 생성할 위치
                Quaternion.identity,                 // 회전값 (없음)
                canvas                               // 부모를 Canvas로 설정
            );
            //UI는 RectTransform 기준으로 위치를 맞춰야 정확하므로 anchoredPosition으로 위치 조정
            ui.GetComponent<RectTransform>().anchoredPosition =
                uiSpawnPoints[i].GetComponent<RectTransform>().anchoredPosition;
        }
    }

    GameObject[] ShuffleArray(GameObject[] array)
    {
        // 원본 배열 복사
        GameObject[] newArray = (GameObject[])array.Clone();

        for (int i = newArray.Length - 1; i > 0; i--)
        {
            // 0~i까지 무작위 선정
            int rand = Random.Range(0, i + 1);
            // newArray[i]와 newArray[rand]를 정렬
            GameObject temp = newArray[i];
            newArray[i] = newArray[rand];
            newArray[rand] = temp;
        }
        return newArray;
    }
    public void EndTurn()
    {
        // 턴을 넘기는 함수
        if (currentTurn == Turn.Player)
        {
            currentTurn = Turn.Monster;
            Debug.Log("몬스터의 턴입니다.");

            // 몬스터에게 턴이 넘어갔음을 알림
            monster.OnPlayerTurnEnd();
        }
        else if (currentTurn == Turn.Monster)
        {
            currentTurn = Turn.Player;
            Debug.Log("플레이어의 턴입니다.");
        }
    }

    public void Onload()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

