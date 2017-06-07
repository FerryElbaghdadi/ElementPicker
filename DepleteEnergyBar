using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script takes care of adjusting the energy bar.
 * It changes upon whenever the player uses an attack.
 */

[RequireComponent((typeof(ProjectileSpawner)), (typeof(TriggerSwitch)))]
public class AdjustEnergyBar : MonoBehaviour
{
    [SerializeField] private Image _energyBar;
    [SerializeField] private ProjectileSpawner[] _projectileSpawnerScript;
    [SerializeField] private TriggerSwitch[] _triggerSwitchScript;

    private float _fireEnergy = 0.4f;
    private float _grassEnergy = 0.2f;
    private float _waterEnergy = 0.5f;
    private float _earthEnergy = 0.9f; // The energy of each attack.

    private float _switchOneEnergy = .2f;
    private float _switchTwoEnergy = .3f;

    private void Start()
    {
        foreach (ProjectileSpawner script in _projectileSpawnerScript)
        {
            script.OnFireShoot += () => _energyBar.fillAmount -= _fireEnergy;
            script.OnGrassShoot += () => _energyBar.fillAmount -= _grassEnergy;
            script.OnWaterShoot += () => _energyBar.fillAmount -= _waterEnergy;
            script.OnEarthShoot += () => _energyBar.fillAmount -= _earthEnergy;
        }


        foreach (TriggerSwitch trigger in _triggerSwitchScript)
        {
            trigger.OnPlayerLeftSwitch += () => _energyBar.fillAmount -= _switchOneEnergy;
            trigger.OnPlayerRightSwitch += () => _energyBar.fillAmount -= _switchTwoEnergy;
        }
       

        // The line of code runs after the player has shot his projectile.
        // We use lambda's to shorten our code.
    }
}
