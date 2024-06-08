using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawn : MonoBehaviour
{
    
    [SerializeField] GameObject m_spawnPrefab = default;
    public int rote;
    public float wait;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("spawning");
    }

    IEnumerator spawning()
    {
        Instantiate(m_spawnPrefab, Vector3.zero, Quaternion.identity);
        for (int i = 0; i < 100; i++)
        {

            //transform.position = Vector3.zero;
            rote = UnityEngine.Random.Range(0, 359);
            wait = 0.2f;
            float x = UnityEngine.Random.Range(-5.0f, 5.0f);
            float y = UnityEngine.Random.Range(-5.0f, 5.0f);
            Vector3 spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            Debug.Log(rote);

            yield return new WaitForSeconds(0.4f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
