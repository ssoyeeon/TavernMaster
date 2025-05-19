using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameTimer;     //게임 플레이 타임 저장용 
    public float timer;         //시간 ( 게임 시간 ) 

    void Start()
    {
        
    }
    
    void Update()
    {
        gameTimer += Time.deltaTime;
        if (SceneManager.GetActiveScene().buildIndex == 2)       //인덱스 2라면 
        {
            GameTime();
        }
    }

    public void GameTime()  //게임 시간 정해주기 현실 20초 = 게임 10분
    {
        timer += Time.deltaTime;        //게임 시간 더해주기
        switch(timer)       //for문으로 바꾸면 더 쉽지 않을까~.. 하지만 스위치 쓰고 싶어요.
        {
              case 20:
                   Debug.Log("6시 10분");
                   break;
              case 40:
                   Debug.Log("6시 20분");
                   break;
                   //계속 추가해놓기 
        }
    }

    public enum PlayStates
    {
        Sleep,      //수면
        House,      //집
        Farm,       //농장
        Play        //일반 플레이 중
    }
}
