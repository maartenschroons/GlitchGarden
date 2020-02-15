using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    GameObject projParent;
    const string PROJ_PARENT_NAME = "Projectiles";
    private void Start()
    {
        setLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjParent();
    }

    private void CreateProjParent()
    {
        projParent = GameObject.Find(PROJ_PARENT_NAME);
        if (!projParent)
        {
            projParent = new GameObject(PROJ_PARENT_NAME);
        }
    }
    private void Update()
    {
        {
            if (isAttackerInLane())
            {
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }

    private void setLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var item in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(item.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = item;
            }
        }
    }

    private bool isAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Shoot(float damage)
    {
        GameObject proj = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        proj.transform.parent = projParent.transform;
    }
}
