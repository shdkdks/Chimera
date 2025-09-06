using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class door_event : MonoBehaviour
{
    //강적 방
    public void ThreatScene()
    {
        SceneManager.LoadScene("ThreatScene");
    }
    //몬스터 방
    public void MonsterScene()
    {
        SceneManager.LoadScene("MonsterScene");
    }
    //이벤트방
    public void EventScene()
    {
        SceneManager.LoadScene("EventScene");
    }
    //도전 방
    public void ChallengeScene()
    {
        SceneManager.LoadScene("ChallengeScene");
    }
    //중간보스 방
    public void MiddleBossScene()
    {
        SceneManager.LoadScene("MiddleBossScene");
    }
    //보스 방
    public void BossScene()
    {
        SceneManager.LoadScene("BossScene");
    }

}
