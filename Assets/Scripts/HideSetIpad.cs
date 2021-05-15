using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSetIpad : MonoBehaviour
{
    public GameObject ipad;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
            SetIpad();
    }

    private void HideIpad()
    {
        ipad.SetActive(false);
    }
    private void SetIpad()
    {
        ipad.SetActive(true);
    }
}
