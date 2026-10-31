using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    public void Lock()
    {
        enabled = false;
        if (_canvas != null)
        {
            _canvas.SetActive(false);
        }
    } 

    public void Unlock()
    {
        enabled = true;
        if (_canvas != null)
        {
            _canvas.SetActive(true);
        }
    }
}
