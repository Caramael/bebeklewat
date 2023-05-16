using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    [SerializeField, Range(min: 0,max:5)] float speed = 3;
    
   Vector3 initialPosition;
   float distanceLimit = float.MaxValue;

   public void SetUpDistanceLimit(float distance)
   {
    this.distanceLimit = distance;
   }

    private void Start()
    {
        initialPosition = this.transform.position;
    }
    private void Update()
    {
        transform.Translate(
            translation: Vector3.forward *speed *Time.deltaTime);
        if(Vector3.Distance(a: initialPosition,b: this.transform.position) > this.distanceLimit)
        {
            Destroy(obj: this.gameObject);
        }
    }
}