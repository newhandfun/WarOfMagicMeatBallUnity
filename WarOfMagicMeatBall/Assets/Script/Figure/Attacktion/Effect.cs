using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : Photon.MonoBehaviour {

    #region Collider
    [SerializeField]
    ColliderEnable colliderEnable;
    Coroutine enableColliderCoroutine;
    [SerializeField]
    Collider myCollider;

    IEnumerator ColliderEnableTask()
    {
        float runTimes = 0f;
        yield return new WaitForSeconds(colliderEnable.speedTimes * colliderEnable.startTime);
        runTimes += colliderEnable.speedTimes * colliderEnable.startTime;
        myCollider.enabled = true;
        yield return new WaitForSeconds(colliderEnable.speedTimes * colliderEnable.endTime);
        runTimes += colliderEnable.speedTimes * colliderEnable.endTime;
        myCollider.enabled = false;
    }
    #endregion

    [SerializeField]
    int damage = 0;
    [SerializeField]
    bool isBroken = true;
    [SerializeField]
    bool isInterrupt = true;
    public float speed = 1f;

    #region UnityProperty
    private ParticleSystem myParticle;
    #endregion

    void Start() {

        myCollider = GetComponent<Collider>();
        myParticle = GetComponent<ParticleSystem>();

        damage = colliderEnable.damage;
        isBroken = colliderEnable.isBroken;
        enableColliderCoroutine = StartCoroutine(ColliderEnableTask());
    }

    void Stop() {
        StopCoroutine(enableColliderCoroutine);
    }


}
