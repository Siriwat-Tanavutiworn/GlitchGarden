using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range (0f, 5f)]
    [SerializeField] float currentMoveSpeed = 1f;
    GameObject currentTarget;
    
    void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            FindObjectOfType<LevelController>().AttackerDestroyed();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentMoveSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    // Use in animation
    public void SetMovementSpeed(float speed)
    {
        currentMoveSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }


    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DamageDealer(damage);
        }
    }

    private void UpdateDifficulty()
    {
        if (PlayerPrefController.GetDifficulty() >= 0.5f)
        {
            currentMoveSpeed++;
        }
    }

}
