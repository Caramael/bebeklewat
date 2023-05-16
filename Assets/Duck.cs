using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Duck : MonoBehaviour
{
    [SerializeField] [Range(min: 0,max: 1)] float moveDuration = 0.1f;
    [SerializeField] [Range(min: 0,max: 1)] float jumpHeight = 0.5f;

    [SerializeField] int leftMoveLimit;
    [SerializeField] int rightMoveLimit;
    [SerializeField] int backMoveLimit;
    
    public UnityEvent<Vector3> onJumpEnd;
    public UnityEvent<int> OnGetCoin;
    public UnityEvent OnDie;    
    private bool isMoveable = false;
    void Update()
    {
        if(isMoveable)
            return;

        if(DOTween.IsTweening(targetOrId: transform))
            return;

        Vector3 direction = Vector3.zero;

        if(Input.GetKeyDown(key: KeyCode.W) 
        || Input.GetKeyDown(key: KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        else if(Input.GetKeyDown(key: KeyCode.S) 
        || Input.GetKeyDown(key: KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }
        else if(Input.GetKeyDown(key: KeyCode.D) 
        || Input.GetKeyDown(key: KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }
        else if(Input.GetKeyDown(key: KeyCode.A) 
        || Input.GetKeyDown(key: KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }

            if(direction == Vector3.zero)
                return;

            Move(direction: direction);
    }
    public void Move(Vector3 direction)
    {
        var targetPosition = transform.position + direction;

        if(targetPosition.x < leftMoveLimit || 
        targetPosition.x > rightMoveLimit || 
        targetPosition.z < backMoveLimit ||
        Tree.AllPositions.Contains(item: targetPosition))
        {
                targetPosition = transform.position;
        }

        transform
        .DOJump(
        endValue: targetPosition,
        jumpPower: jumpHeight,
        numJumps: 1 ,
        duration: moveDuration)
        .onComplete = BroadCastPositionOnJumpEnd;
        
        transform.forward = direction;
    }

    public void SetMoveable(bool value)
    {
        isMoveable = value;
    }

    public void UpdateMoveLimit(int horizontalSize, int backLimit)
    {
        leftMoveLimit = -horizontalSize / 2;
        rightMoveLimit = horizontalSize / 2;
        backMoveLimit = backLimit;
    }

    private void BroadCastPositionOnJumpEnd()
    {
        onJumpEnd.Invoke(arg0: transform.position);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag: "Car"))
        {
            if(isMoveable == true)
            return;
            transform.DOScale(endValue: new Vector3(x: 3,y: 0.1f,z: 1),duration: 0.2f);

            isMoveable = true;
            Invoke(methodName: "Die",time: 3);
        }

        else if (other.CompareTag(tag: "Coin"))
        {
            var coin = other.GetComponent<Coin>();
            OnGetCoin.Invoke(arg0: coin.Value);
            coin.Collected();
        }

        else if (other.CompareTag(tag: "Eagle"))
        {
            if (this.transform != other.transform)
            {
                this.transform.SetParent(p: other.transform); 
                Invoke(methodName: "Die",time: 3);
            }
        }
    }
    private void Die()
    {
        OnDie.Invoke();
    }
}
