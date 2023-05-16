using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Terrain
{
    [SerializeField] Car carPrefab;
    [SerializeField] float minCarSpawnInterval;
    [SerializeField] float maxCarSpawnInterval;

    float timer;

    Vector3 carSpawnPosition;
    Quaternion carRotation;

    private void Start()
    {
        if(Random.value > 0.5f)
        {
            carSpawnPosition = new Vector3(
                x: horizontalSize/2 + 3,
                y: 0,
                z: this.transform.position.z); 

            carRotation = Quaternion.Euler(x: 0,y: -90,z: 0);    
        }
        else
        {
            carSpawnPosition = new Vector3(
                x: -(horizontalSize/2 + 3),
                y: 0,
                z: this.transform.position.z);

                carRotation = Quaternion.Euler(x: 0,y: 90,z: 0);    
        } 
    }
    private void Update()
    {
        if (timer < 0)
        {
            timer = Random.Range(
                minInclusive: minCarSpawnInterval,
                maxInclusive: maxCarSpawnInterval);

            var car = Instantiate(original: carPrefab,
            position: carSpawnPosition,
            rotation: carRotation);

            car.SetUpDistanceLimit(distance: horizontalSize+6);
            
            return;
        }
        timer -= Time.deltaTime;
    }
}