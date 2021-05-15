using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int Rotationoffset = 10;//скорость поворота
    public float rotz;

    private Vector3 mousePosition;

    void Update()
    {
        
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
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // Применяем поворот вокруг оси y
        transform.rotation = Quaternion.Euler(0f, rotz * Rotationoffset, 0f);
    }
}
