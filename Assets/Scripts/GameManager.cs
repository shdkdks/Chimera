using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
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
        GameObject[] shuffled = ShuffleArray(uiPrefabs);

        for (int i = 0; i < 3; i++)
        {
            GameObject ui = Instantiate(shuffled[i], uiSpawnPoints[i].position, Quaternion.identity, canvas);
            
            ui.GetComponent<RectTransform>().anchoredPosition = uiSpawnPoints[i].GetComponent<RectTransform>().anchoredPosition;
        }
    }

    GameObject[] ShuffleArray(GameObject[] array)
    {
        GameObject[] newArray = (GameObject[])array.Clone();
        for (int i = newArray.Length - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
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

