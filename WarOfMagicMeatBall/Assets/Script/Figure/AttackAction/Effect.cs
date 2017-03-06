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

    #region Property

    int myTeamNumber = 0;

    [SerializeField]
    int damage = 0;
    [SerializeField]
    bool isBroken = true;
    [SerializeField]
    bool isInterrupt = true;
    public float speed = 1f;
    public bool isNetworkObject = false;
    #endregion

    #region UnityProperty
    private ParticleSystem myParticle;
    #endregion

    void Initial(int _teamNumber) {
        myTeamNumber = _teamNumber;
    }

    void Start() {

        myCollider = GetComponent<Collider>();
        myParticle = GetComponent<ParticleSystem>();

        damage = colliderEnable.damage;
        isBroken = colliderEnable.isBroken;
        enableColliderCoroutine = StartCoroutine(ColliderEnableTask());

        myParticle.Play();
    }

    void Stop() {
        StopCoroutine(enableColliderCoroutine);
    }

    IEnumerator DestoryAfterPlayed() {
        yield return new WaitForSeconds(speed*myParticle.time);
        if (isNetworkObject)
            PhotonNetwork.Destroy(this.gameObject);
        else
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider _other) {

        int otherTN = 0;

        if (otherTN != myTeamNumber) {

        }
    }
}
