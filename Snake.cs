using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

    public GameObject block,temp;
    public GameObject[] Line;
    public Text sc,tmr,tmr2;
    private GameObject[] snake = new GameObject[600];
    private Vector2 dir;
    private int movespeed, score, timer;
    private bool move = false;
    int tmp;

	void Start()
    {            
        Invoke("start_move",3);
        movespeed = speed.speed_value + 2;
        tmp = 3 + (int)Time.time;
            score = 0;
            for (int i = 0; i < 10; i++)
                snake[i] = Instantiate(block, new Vector2(i * 0.25f, 0f), Quaternion.identity);
            dir = Vector2.left;
            temp = Instantiate(temp, Random_data(), Quaternion.identity);
    }

	// Update is called once per frame
    void Update()
    {
        
        if(!move)
        {
            timer = (int)Time.time;
            timer = tmp - timer;
            tmr.text = timer.ToString();
            tmr2.text = tmr.text;
        }
        direction();
        coll_w_food();
        if (move)
        {
            tmr.text = null;
            tmr2.text = null;
            render();
        }
        Colligion();        
    }

    void start_move()
    {
        move = true;
        tmp = 7 + (int)Time.time;
    }

    Vector2 Random_data()
    {
        Vector2 rand;
        float x, y;
        bool stop = true;
        do
        {
            x = Random.Range(-6f, 6f);
            y = Random.Range(-4.5f, 4.5f);
            for (int i = 0; i < Line.Length; i++)
                if (x <= Line[i].transform.position.x + Line[i].transform.localScale.x + 0.5f && x >= Line[i].transform.position.x - Line[i].transform.localScale.x - 0.5f &&
                    y <= Line[i].transform.position.y + Line[i].transform.localScale.y + 0.5f && y >= Line[i].transform.position.y - Line[i].transform.localScale.y - 0.5f)
                    stop = false;
                else
                    stop = true;
        } while (!stop);
        rand = new Vector2(x, y);
        return rand;
    }

    void direction()
    {
        if (Input.GetKey(KeyCode.UpArrow) && dir != Vector2.down)
            dir = Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
            dir = Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
            dir = Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow) && dir != Vector2.left)
            dir = Vector2.right;
    }

    void coll_w_food()
    {
        if (snake[0].transform.position.x <= temp.transform.position.x + temp.transform.localScale.x / 2 && snake[0].transform.position.x >= temp.transform.position.x - temp.transform.localScale.x / 2 &&
            snake[0].transform.position.y <= temp.transform.position.y + temp.transform.localScale.y / 2 && snake[0].transform.position.y >= temp.transform.position.y - temp.transform.localScale.y)
            for (int i = 0; i < snake.Length; i++)
            {
                if (!snake[i])
                {
                    for (int j = 0; j < 4;j++ )
                        snake[i +j] = Instantiate(block);
                    score++;
                    temp.SetActive(false);
                    break;
                }
            }
        if (temp.active == false)
        {
            temp.transform.position = Random_data();
            temp.SetActive(true);
        }
    }

    void render()
    {
        sc.text = score.ToString();
        for (int i = snake.Length - 1; i > 0; i--)
        {
            if (snake[i])
                snake[i].transform.position = snake[i - 1].transform.position;
        }
        snake[0].transform.Translate(dir * movespeed * Time.deltaTime);
    }
    void Colligion()
    {
        for(int i =0;i<Line.Length;i++)
        {
            if (snake[0].transform.position.x <= Line[i].transform.position.x + Line[i].transform.localScale.x / 2 && snake[0].transform.position.x >= Line[i].transform.position.x - Line[i].transform.localScale.x / 2 &&
                snake[0].transform.position.y <= Line[i].transform.position.y + Line[i].transform.localScale.y / 2 && snake[0].transform.position.y >= Line[i].transform.position.y - Line[i].transform.localScale.y / 2)
            Application.LoadLevel(2);
        }
        for (int i = 3; i < snake.Length; i++)
        {
            if(snake[i])
                if (snake[0].transform.position.x  <= snake[i].transform.position.x + snake[i].transform.localScale.x / 5 && snake[0].transform.position.x  >= snake[i].transform.position.x - snake[i].transform.localScale.x / 5 &&
                    snake[0].transform.position.y  <= snake[i].transform.position.y + snake[i].transform.localScale.y / 5 && snake[0].transform.position.y  >= snake[i].transform.position.y - snake[i].transform.localScale.y / 5)
                Application.LoadLevel(2);
        }
    }
}
