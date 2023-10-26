using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    // ������� ���������� � CharacterController ������� ����� �� ���������
    private CharacterController characterController;

    float turnSmooth;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /* ����� ������ ���� � C#: 
           - int - ����� ����� (1, 5, -1)
           - float - ����� � ������� (1.2f, 2.0f, 1.3333333f)
           - bool - true/false
           - string - ������ ("���������", "111111")
        */

        // ������� ������ ������/�����
        float horizontal = Input.GetAxisRaw("Horizontal");

        // �����/����
        float vertical = Input.GetAxisRaw("Vertical");

        // ������� ���������� ���� Vector3, ������ � �� �������� �������������� � ������������ ��� 
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // ������� ��������� �� ������ ������ ������� Movement
        characterController.Move(movement * Time.deltaTime * speed);

        // ����� �� ������� ����, �� ������� ����� ������������ ���������
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmooth, 0.2f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
