using UnityEngine;
using UnityEngine.UI;

public class WindowExpander : MonoBehaviour
{
    public ScrollRect associatedScrollView;

    public void OpenObject()
    {
        // Весь внешний код удалили, остается только активировать связанный ScrollRect
        if (associatedScrollView != null)
        {
            associatedScrollView.gameObject.SetActive(true);
        }
    }

    public void CloseObject()
    {
        if (associatedScrollView != null)
        {
            associatedScrollView.gameObject.SetActive(false);
        }
    }
}
