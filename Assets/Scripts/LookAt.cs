using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Camera cameraMain;

    private Vector3 direction;
    void Start()
    {
        direction = cameraMain.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(-direction); // �������� �����������
        transform.rotation = lookRotation;
    }
    void Update()
    {
        // ���� ����� ��������� ��������� ����������� � ������ �����
        Vector3 direction = cameraMain.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(-direction); // �������� �����������
        transform.rotation = lookRotation;
    }
}
