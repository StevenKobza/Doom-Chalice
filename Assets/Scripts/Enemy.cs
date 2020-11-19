using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string _tag; //Give a name to the enemy
    public Boolean dead;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private System.Timers.Timer aTimer;
    private bool respawn = false;
    private Vector3 respawnPos;
    private NavMeshAgent nma;
    private CapsuleCollider cc;
    public int maxHealth = 3;
    private int health;
    private MeshRenderer[] meshRenderers;
    private SkinnedMeshRenderer[] smr;
    public GameObject ammoBox;
    private bool dropAmmo;

    // Start is called before the first frame update
    void Start()
    {
        if (_tag == "skeleton")
        {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
            smr = GetComponentsInChildren<SkinnedMeshRenderer>();
        }
        health = maxHealth;
        nma = GetComponent<NavMeshAgent>();
        cc = GetComponent<CapsuleCollider>();
        respawnPos = transform.position;
        meshRenderer = this.GetComponent<MeshRenderer>();
        meshCollider = this.GetComponent<MeshCollider>();
        EnemyController.AddEnemy(_tag, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            if (dropAmmo)
            {
                Instantiate(ammoBox, this.transform.position, this.transform.rotation);
                dropAmmo = false;
            }

            if (_tag == "skeleton")
            {
                for (int i = 0; i < meshRenderers.Length; i++)
                {
                    meshRenderers[i].forceRenderingOff = true; 
                    //meshRenderers[i].enabled = false;
                }
                for (int i = 0; i < smr.Length; i++)
                {
                    smr[i].enabled = false;
                }
            }
            else
            {
                meshRenderer.enabled = false;
            }
            meshCollider.enabled = false;
            cc.enabled = false;
            nma.enabled = false;
            //SetTimer(10000);
            if (respawn == true)
            {
                transform.position = respawnPos;
                if (_tag == "skeleton")
                {
                    for (int i = 0; i < meshRenderers.Length; i++)
                    {
                        meshRenderers[i].forceRenderingOff = false;
                    }
                    for (int i = 0; i < smr.Length; i++)
                    {
                        smr[i].enabled = true;
                    }
                }
                else
                {
                    meshRenderer.enabled = true;
                }
                meshCollider.enabled = true;
                dead = false;
                respawn = false;
                cc.enabled = true;
                nma.enabled = true;
                aTimer.Stop();
                aTimer.Close();
                //Instantiate(this, new Vector3(-0.5f, 0, -3), this.transform.rotation);
            }
        } else
        {
        }
    }

    public void Shot()
    {
        if (health > 1)
        {
            health--;
        } else
        {
            dead = true;
            EnemyController.killed();
            if (EnemyController.drop() == true)
            {
                dropAmmo = true;
            }
        }
    }
    private void SetTimer(int ms)
    {
        aTimer = new System.Timers.Timer(ms);
        aTimer.Elapsed += ATimer_Elapsed;
        aTimer.AutoReset = false;
        aTimer.Enabled = true;
    }

    private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        respawn = true;

    }
}
