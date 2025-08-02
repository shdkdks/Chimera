using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class door_event : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ThreatScene()
    {
        SceneManager.LoadScene("ThreatScene");
    }
    public void MonsterScene()
    {
        SceneManager.LoadScene("MonsterScene");
    }
    public void EventScene()
    {
        SceneManager.LoadScene("EventScene");
    }

}
