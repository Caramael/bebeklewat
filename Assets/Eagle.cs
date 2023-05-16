using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    
    [SerializeField, Range(min: 0,max: 50)] float speed = 20;
   
    private void Update()
    {   
        transform.Translate(translation: Vector3.forward*speed*Time.deltaTime);
        
    } 
}
