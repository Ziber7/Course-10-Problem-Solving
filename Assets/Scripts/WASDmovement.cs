using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDmovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(
            Input.GetAxis("Horizontal") * 5f * Time.deltaTime,
            Input.GetAxis("Vertical") * 5f * Time.deltaTime, 0f);
    }
}
