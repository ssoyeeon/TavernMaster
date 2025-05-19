using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameTimer;     //���� �÷��� Ÿ�� ����� 
    public float timer;         //�ð� ( ���� �ð� ) 

    void Start()
    {
        
    }
    
    void Update()
    {
        gameTimer += Time.deltaTime;
        if (SceneManager.GetActiveScene().buildIndex == 2)       //�ε��� 2��� 
        {
            GameTime();
        }
    }

    public void GameTime()  //���� �ð� �����ֱ� ���� 20�� = ���� 10��
    {
        timer += Time.deltaTime;        //���� �ð� �����ֱ�
        switch(timer)       //for������ �ٲٸ� �� ���� ������~.. ������ ����ġ ���� �;��.
        {
              case 20:
                   Debug.Log("6�� 10��");
                   break;
              case 40:
                   Debug.Log("6�� 20��");
                   break;
                   //��� �߰��س��� 
        }
    }

    public enum PlayStates
    {
        Sleep,      //����
        House,      //��
        Farm,       //����
        Play        //�Ϲ� �÷��� ��
    }
}
