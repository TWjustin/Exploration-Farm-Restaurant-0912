using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildAnimal : Resource
{
    public int hp;
    public bool isHostile;
    public int atk;
    
    public float speed = 0.7f;
    private float moveSpeed;
    private Vector2 moveDirection;
    private float timer;
    public float changeDirectionTime = 2f;
    
    public GameObject hpBarPrefab;
    public float hpBarOffset = 1f;

    public ItemSet prey;

    private void Start()
    {
        
        GameObject hpBar = Instantiate(hpBarPrefab, transform.position + Vector3.up * hpBarOffset, Quaternion.identity);
        hpBar.transform.SetParent(transform);
        hpBar.SetActive(false);
        
        MoveRandomly();
    }

    // 狀態: idle, walk, run, attack, faint, die
    
    void Update()
    {
        timer -= Time.deltaTime;

        // 射線檢測障礙物
        if (Physics.Raycast(transform.position, moveDirection, 1.0f))
        {
            MoveRandomly();  // 如果前方有障礙物，改變方向
            timer = changeDirectionTime;
        }
        
        // 當計時器到期，改變方向
        if (timer <= 0)
        {
            if (Random.value < 0.5f) // 30% 機率停下
            {
                StartCoroutine(RestForAWhile());
            }
            else
            {
                MoveRandomly();
            }
            timer = changeDirectionTime;
        }

        // 移動動物
        transform.position += (Vector3) moveDirection * moveSpeed * Time.deltaTime;
    }
    
    private void MoveRandomly()
    {
        moveSpeed = speed;
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }
    
    private IEnumerator RestForAWhile()
    {
        moveSpeed = 0;  // 停止移動
        yield return new WaitForSeconds(2.0f);  // 停下2秒
    }
    
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // Faint();
            Debug.Log("Faint");
        }
    }
}
