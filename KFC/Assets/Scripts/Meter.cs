using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    public List<GameObject> m_Images = null;

    // Start is called before the first frame update
    void Start()
    {
        m_Images[m_Images.Count - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            Refill();
        }

        if(Input.GetMouseButtonDown(0))
        {
            DecreaseMeter();
        }
    }

    void Refill()
    {
        foreach (GameObject go in m_Images)
        {
            go.SetActive(false);
        }
        m_Images[0].SetActive(true);
    }

    void DecreaseMeter()
    {
        for (int i = 0; i < m_Images.Count; i++)
        {
            if(m_Images[i].activeSelf == true && i + 1 != m_Images.Count)
            {
                m_Images[i].SetActive(false);
                m_Images[i + 1].SetActive(true);
                break;
            }
        }
    }

}
