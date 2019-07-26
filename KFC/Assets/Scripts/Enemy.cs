using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform m_player = null;
    [SerializeField] float m_speed = 3.0f;
    [SerializeField] float m_sleepTime = 2.0f;
    [SerializeField] float m_range = 10.0f;
    private float sleep;

    Vector3 idle;
    void Start()
    {
        sleep = m_sleepTime;
        idle = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
    }

    void Update()
    {
        Vector3 target = m_player.transform.position - transform.position;

        sleep -= Time.deltaTime;

        Debug.Log(idle);

        if (target.magnitude >= 1 && target.magnitude <= m_range)
        {
            transform.position += target.normalized * m_speed * Time.deltaTime;
        }
        if (target.magnitude < 1)
        {
            //Attack();
        }
        if (target.magnitude > m_range)
        {
            if (sleep <= 0)
            {
                sleep = m_sleepTime;
                idle = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
            }
            transform.position += idle.normalized * m_speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!m_player.gameObject.GetComponent<PlayerController>().m_powerMeter.DecreaseMeter())
            {
                m_player.gameObject.GetComponent<PlayerController>().Die();
            }
        }
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(gameObject, 1.25f);
        }
    }
}
