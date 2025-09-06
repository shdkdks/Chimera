using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [Header("������ UI")]
    public GameObject[] uiPrefabs;

    [Header("UI ���� ��ġ")]
    public Transform[] uiSpawnPoints;

    [Header("ĵ����")]
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
        // ���� ���� �� �÷��̾��� ������ ����
        currentTurn = Turn.Player;
        Debug.Log("�÷��̾��� ���Դϴ�.");
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
        // ���� �ѱ�� �Լ�
        if (currentTurn == Turn.Player)
        {
            currentTurn = Turn.Monster;
            Debug.Log("������ ���Դϴ�.");

            // ���Ϳ��� ���� �Ѿ���� �˸�
            monster.OnPlayerTurnEnd();
        }
        else if (currentTurn == Turn.Monster)
        {
            currentTurn = Turn.Player;
            Debug.Log("�÷��̾��� ���Դϴ�.");
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

