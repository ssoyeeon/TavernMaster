using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTimer;     //게임 플레이 타임 저장용 
    public float timer;         //시간 ( 게임 시간 ) 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
    }

    public void GameTime()
    {
        
    }
}
