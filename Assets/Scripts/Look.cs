using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
      public enum RorationAxes //возможные варианты осей
    {
        XandY,
        X,
        Y
    }
    public RorationAxes _axes = RorationAxes.XandY; //доступная переменная поворота
    public float _rotationSpeedHor = 5.0f; //скорость вращения по горизонатали
    public float _rotationSpeedVer = 5.0f; //скорость вращения по вертикали

    public float maxVert = 45.0f; //ограничение по вертикали относительно разных углов
    public float minVert = -45.0f;

    private float _rotationX = 0;//угол поворота по вертикали

    public float speedMove = 10f;//скорость передвижения персонажа.
    private Vector3 moveVector;//направление персонажа
    private CharacterController ch_controller;//ссылка на компонент контролле

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();

        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true; 
    }

    private void Update()
    {
        PersonalMove();

        if (Input.GetMouseButton(1))
            LookMauseBotton();
    }
    //функция поворота головы
    private void LookMauseBotton()
    {
        //Проверим ось движения
        if (_axes == RorationAxes.XandY)
        {
            _rotationX -= Input.GetAxis("Mouse Y")* _rotationSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * _rotationSpeedHor; //угол поворота
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else if (_axes == RorationAxes.X)//поворот персонажа по x
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeedHor, 0);
        }
        else if (_axes == RorationAxes.Y)//поворот персонажа по y
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer; //угол по ворота по вертикали относительно мышки
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); //ограничение угла

            float _rotationY = transform.localEulerAngles.y; //одинаковый угол поворот по y

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }

    private void PersonalMove()
    {
        //перемещение
        moveVector = Vector3.zero;
        moveVector.z = -Input.GetAxis("Horizontal") * speedMove;
        moveVector.x = Input.GetAxis("Vertical") * speedMove;

        ch_controller.Move(moveVector * Time.deltaTime);//движение по направлению
    }
}
