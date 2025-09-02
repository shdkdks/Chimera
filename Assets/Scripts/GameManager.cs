using System.Collections;
using System.Collections.Generic;
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

    void Awake()
    {
        Onload();
    }
    void Start()
    {
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

