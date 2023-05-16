using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] Eagle eagle;
    [SerializeField] Duck duck;
    [SerializeField] float initialTimer = 10;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = initialTimer;
        eagle.gameObject.SetActive(value: false);
        duck.SetMoveable(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<=0 && eagle.gameObject.activeInHierarchy == false)
            {
                eagle.gameObject.SetActive(value: true);
                eagle.transform.position = duck.transform.position + new Vector3(x: 0,y: 0,z: 13);
            }
        timer -= Time.deltaTime;
    }
    public void ResetTimer()
    {
        timer = initialTimer;
    }
}

