using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTimer;     //���� �÷��� Ÿ�� ����� 
    public float timer;         //�ð� ( ���� �ð� ) 
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
