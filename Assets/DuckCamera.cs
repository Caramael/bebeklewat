using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DuckCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField, Range(min: 0,max: 1)] float moveDuration = 0.2f;
    private void Start()
    {
        offset = this.transform.position;   
    }

    public void UpdatePosition(Vector3 targetPosition)
    {
        DOTween.Kill(targetOrId: this.transform);
        transform.DOMove(endValue: offset + targetPosition,duration: moveDuration);
    }
}
