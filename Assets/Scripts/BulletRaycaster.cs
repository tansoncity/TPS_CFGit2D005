using UnityEngine;
using Unity.Cinemachine;

public class BulletRaycaster : MonoBehaviour
{
    [SerializeField] CinemachineThirdPersonAim _tpsAim;
    public void Shoot()
    {
        print("Shoot" + _tpsAim.AimTarget);
    }
}
