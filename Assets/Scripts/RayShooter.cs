using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private float interactableRayDistance = 3.0f;
    [SerializeField] private GameObject _takingHandIcon;

    [SerializeField] private Fireball _fireBall;


    [SerializeField] private Inventory _inventory;

    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            //создание огненного шара
            // ѕолучаем позицию камеры и добавл€ем смещение по оси Z
            Vector3 fbPos = _camera.transform.position + _camera.transform.forward * 3;
            Instantiate<Fireball>(_fireBall, fbPos, _camera.transform.rotation);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    //StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }

        #region дл€ взаимодействи€ с интерактивными объектами
        if (Physics.Raycast(ray, out hit, interactableRayDistance))
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable != null)
            {
                _takingHandIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.GetComponent<Pickable>())
                    {
                        var pickable = hit.collider.GetComponent<Pickable>();
                        pickable.PickableName = pickable.transform.name;
                        _inventory.AddItem(pickable);
                        pickable.DestroyWhenInteracted();
                    }


                    interactable.Interraction();                    
                }
            }
            else
            {
                _takingHandIcon.SetActive(false);
            }
        }
        else
        {
            _takingHandIcon.SetActive(false);
        }
        #endregion
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}



