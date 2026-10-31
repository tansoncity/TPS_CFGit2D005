using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher _weaponSwitcher;
    public void OnDead()
    {
        _weaponSwitcher.LockAllWeapons();
    }
}
