using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class door_event : MonoBehaviour
{
    //���� ��
    public void ThreatScene()
    {
        SceneManager.LoadScene("ThreatScene");
    }
    //���� ��
    public void MonsterScene()
    {
        SceneManager.LoadScene("MonsterScene");
    }
    //�̺�Ʈ��
    public void EventScene()
    {
        SceneManager.LoadScene("EventScene");
    }
    //���� ��
    public void ChallengeScene()
    {
        SceneManager.LoadScene("ChallengeScene");
    }
    //�߰����� ��
    public void MiddleBossScene()
    {
        SceneManager.LoadScene("MiddleBossScene");
    }
    //���� ��
    public void BossScene()
    {
        SceneManager.LoadScene("BossScene");
    }

}
