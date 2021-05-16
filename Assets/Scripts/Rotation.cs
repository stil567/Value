using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject fluid;
    public GameObject flow;
    public int Rotationoffset = 10;//скорость поворота
    public float rotz;

    private float heightFluid = 0.1f;

    private Vector3 mousePosition;

    void Update()
    {
        if (transform.rotation.y > 0)
        {
            heightFluid += 0.0001f;
            fluid.transform.localScale = new Vector3(1f, heightFluid, 1f);
            flow.SetActive(true);
        }
        else
        {
            flow.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButton(0))
                ValveRotaton();
        }
    }

    private void ValveRotaton()
    {
        mousePosition = Input.mousePosition;

        // разница между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        //  угол поворота
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg * Rotationoffset;
        // Применяем поворот вокруг оси y
        transform.rotation = Quaternion.Euler(0f, rotz , 0f);
    }
}
