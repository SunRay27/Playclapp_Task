using System;
using System.Collections;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    public void BeginMove(float speed, float maxDistance)
    {
        StartCoroutine(MoveCoroutine(speed, maxDistance));
    }

    private IEnumerator MoveCoroutine(float speed, float maxDistance)
    {
        Vector3 moveDirection = Vector3.right;

        float currentDistance = 0;

        while (currentDistance < maxDistance)
        {
            float moveDelta = speed * Time.deltaTime;
            currentDistance += moveDelta;
            transform.position += moveDirection * moveDelta;
            yield return null;
        }

        Destroy(gameObject);
    }
}