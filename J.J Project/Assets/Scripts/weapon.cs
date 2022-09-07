using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weapon : MonoBehaviour
{
    public Gun[] loadout;
    public Transform weaponPranet;

    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) equip(0);
    }
    
    void equip(int p_ind)
    {
        if(currentWeapon != null) Destroy(currentWeapon);

        GameObject t_newWeapon = Instantiate(loadout[p_ind].prefabs, weaponPranet.position, weaponPranet.rotation, weaponPranet) as GameObject;
        t_newWeapon.transform.localPosition = Vector3.zero;
        t_newWeapon.transform.localEulerAngles = Vector3.zero;

        currentWeapon = t_newWeapon;
    }
}
