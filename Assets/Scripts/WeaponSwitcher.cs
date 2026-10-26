using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class WeaponKeyBinding
{
    public Key key;
    public GameObject weapon;
}

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private WeaponKeyBinding[] _weapons;

    [SerializeField] private int _defaultIndex = 0;

    private int _selectedIndex;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set => SelectWeapon(value);
    }

    public int WeaponCount => _weapons.Length;

    private void Start() => SelectedIndex = _defaultIndex;

    private void Update()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (Keyboard.current[_weapons[i].key].wasPressedThisFrame)
            {
                SelectedIndex = i;
            }
        }
    }

    private void SelectWeapon(int index)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].weapon.SetActive(i == index);
        }
        _selectedIndex = index;
    }
}
