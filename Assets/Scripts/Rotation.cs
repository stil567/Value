using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public GameObject GM;
    public int Rotationoffset = 10;
    public float rotz;

    private Vector3 mousePosition;


    void Update()
    {

        mousePosition = Input.mousePosition;

        // разница между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        //  угол поворота
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // Применяем поворот вокруг оси y
        GM.transform.rotation  = Quaternion.Euler(0f, rotz * Rotationoffset, 0f);
    }

 }
