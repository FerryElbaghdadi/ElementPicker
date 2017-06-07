using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script takes care of the enemy's projectile shooting.
 * It chooses which element is best to counter the player's projectile with.
 */

[RequireComponent(typeof(ElementReminder), (typeof(EnemyAttack)))]
public class ProjectileEnemySpawner : MonoBehaviour, IProjectileSpawner
{
    [SerializeField] private ElementReminder _elementReminderScript;
    [SerializeField] private EnemyAttack _enemyAttack;

    [SerializeField] private GameObject _fireProjectile;
    [SerializeField] private GameObject _grassProjectile;
    [SerializeField] private GameObject _waterProjectile;
    [SerializeField] private GameObject _earthProjectile;

    private int _randomAttack;

    enum ElementChooser
    {
        Fire, Grass, Water, Earth
    }

    ElementChooser ElementChosen;


    private void Start()
    {
        _elementReminderScript.OnFireAttack += () => ElementChosen = ElementChooser.Fire;
        _elementReminderScript.OnGrassAttack += () => ElementChosen = ElementChooser.Grass;
        _elementReminderScript.OnWaterAttack += () => ElementChosen = ElementChooser.Water;
        _elementReminderScript.OnEarthAttack += () => ElementChosen = ElementChooser.Earth;

        _enemyAttack.OnEnemyAttack += Spawn;    
    }

    public void Spawn()
    {
        switch (ElementChosen)
        {
            case ElementChooser.Fire:
                Instantiate(_waterProjectile, transform.position, Quaternion.identity);
                break;
            case ElementChooser.Grass:
                Instantiate(_fireProjectile, transform.position, Quaternion.identity);
                break;
            case ElementChooser.Water:
                Instantiate(_grassProjectile, transform.position, Quaternion.identity);
                break;
            case ElementChooser.Earth:
                Instantiate(_earthProjectile, transform.position, Quaternion.identity);
                break;

            default:

                _randomAttack = Random.Range(1, 4);

                switch (_randomAttack)
                {
                    case 1:
                        Instantiate(_waterProjectile, transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(_fireProjectile, transform.position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(_grassProjectile, transform.position, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(_earthProjectile, transform.position, Quaternion.identity);
                        break;
                }
                break;
        }
    }
}
