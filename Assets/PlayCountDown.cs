using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayCountDown : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text tmpText;
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

    private void Start()
    {
        OnStart.Invoke();
        var sequence = DOTween.Sequence();
        tmpText.transform.localScale = Vector3.zero;
        tmpText.text = "3";
        sequence.Append(t: tmpText.transform.DOScale(
            endValue: Vector3.one,
            duration: 1).OnComplete(action: () => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "2";
            }));

        sequence.Append(t: tmpText.transform.DOScale(
            endValue: Vector3.one,
            duration: 1).OnComplete(action: () => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "1";
            }));

        sequence.Append(t: tmpText.transform.DOScale(
            endValue: Vector3.one,
            duration: 1).OnComplete(action: () => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "GO!";
                OnEnd.Invoke();
            }));
        
        // sequence.Append(t: tmpText.transform.DOScale(
        //     endValue: Vector3.one,
        //     duration: 1).OnStart(action: () => 
        //     {
        //         tmpText.transform.localScale = Vector3.zero;
        //         tmpText.text = "GO";
        //     }));
        
        // sequence.Append(t: tmpText.transform.DOScale(
        //     endValue: Vector3.one,
        //     duration: 1).OnStart(action: () => 
        //     { 
        //         OnEnd.Invoke();
        //     }));
    }
}
