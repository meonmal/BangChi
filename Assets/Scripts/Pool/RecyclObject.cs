using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclObject : MonoBehaviour
{

    public Action onDisable = null;


    protected virtual void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        StopAllCoroutines();

        OnReset();
    }

    protected virtual void OnDisable()
    {
        onDisable?.Invoke();
    }

    protected virtual void OnReset()
    {

    }

    protected void DisableTimer(float time = 0.0f)
    {
        StartCoroutine(LifeOver(time));
    }

    IEnumerator LifeOver(float time = 0.0f)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}
