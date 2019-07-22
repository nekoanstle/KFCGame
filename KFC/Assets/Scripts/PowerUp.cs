using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ePowers m_power;
    void Start()
    {
        m_power = ePowers.POWERS[(int)(Random.value * 5)];
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
