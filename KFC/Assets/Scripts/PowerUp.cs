using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ePowers m_power;
    [SerializeField] float m_sleepTime = 2.0f;
    [SerializeField] float m_speed = 2.0f;

    private float sleep;
    Vector3 idle;
    void Start()
    {
        sleep = m_sleepTime;
        idle = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        m_power = ePowers.POWERS[(int)(Random.value * 5)];
    }

    private void Update()
    {
        if (sleep <= 0)
        {
            sleep = m_sleepTime;
            idle = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        }
        transform.position += idle.normalized * m_speed * Time.deltaTime;
    }

}

public class ePowers
{
    public static ePowers LINE = new ePowers(new Color(255, 126, 0));
    public static ePowers CONE = new ePowers(new Color(255, 0, 0));
    public static ePowers SHEILD = new ePowers(new Color(135, 206, 250));
    public static ePowers POPCORN = new ePowers(new Color(255, 255, 0));
    public static ePowers[] POWERS = new ePowers[] { LINE, CONE, SHEILD, POPCORN };

    public ePowers(Color c)
    {
        color = c;
    }

    public Color color;
}
