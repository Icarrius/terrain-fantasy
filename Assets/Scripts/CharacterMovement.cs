using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    // Создали переменную с CharacterController который висит на персонаже
    private CharacterController characterController;

    float turnSmooth;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Самые частые типа в C#: 
           - int - целое число (1, 5, -1)
           - float - число с запятой (1.2f, 2.0f, 1.3333333f)
           - bool - true/false
           - string - строки ("Ывфывфыгр", "111111")
        */

        // Нажатия кнопок вправо/влево
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Вверх/вниз
        float vertical = Input.GetAxisRaw("Vertical");

        // Создали переменную типа Vector3, кладем в неё значения горизонтальной и вертикальной оси 
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Двигаем персонажа на основе нашего вектора Movement
        characterController.Move(movement * Time.deltaTime * speed);

        // Здесь мы считаем угол, на который будем поворачивать персонажа
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmooth, 0.2f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
