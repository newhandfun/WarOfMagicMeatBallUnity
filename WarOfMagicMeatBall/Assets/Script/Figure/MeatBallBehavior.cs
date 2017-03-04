using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBallBehavior : FigureBehavior {

    public override void Awake()
    {
        base.Awake();

        standByAnimator = Resources.Load("Animator/Login") as RuntimeAnimatorController;
    }

    #region Suit
    [SerializeField]
    protected GameObject body;

    [SerializeField]
    protected GameObject[] partsParent = null;
    protected GameObject[] partsObject = null;

    static string[] partsParentName = {
        "weapon_IK_R",
        "weapon_IK_L",
        "hand_L",
        "hand_R",
        "feet_L",
        "feet_R",
        "cloak",
        "hat",
        "body"
    };


    
    public void DressUp(GameObject[] _parts) {
        if (_parts.Length != partsParentName.Length) {
            Debug.Log("可佩帶部位與相對應骨頭數量不符!請再三確認!");
        }
        if (partsParent == null || partsParent.Length<2)
        {
            FindWearBone();
        }
        partsObject = new GameObject[partsParent.Length];
        for (int i=0;i<partsParent.Length ;i++) {
            if (_parts[i] != null)
            {
                partsObject[i] = _parts[i];
                partsObject[i].transform.SetParent(partsParent[i].transform);
                partsObject[i].transform.localRotation = Quaternion.Euler(Vector3.zero);
                partsObject[i].transform.localPosition = Vector3.zero;
                partsObject[i].transform.localScale = new Vector3(1f,1f,1f);
            }
        }
    }

    [ContextMenu("設定套裝骨頭")]
    public void FindWearBone() {
        partsParent = new GameObject[partsParentName.Length];
        for (int i = 0; i < partsParentName.Length; i++)
        {
            try
            {
                var parent = FindObjectInChild(GetTrans(),partsParentName[i]);
                partsParent[i] = parent.gameObject;
            }
            catch (Exception e) { Debug.Log("取得套裝骨架有問題!\n:" + e); }
        }
    }

    #endregion

    #region UV
    public override Vector2[] GetUV()
    {
        return body.GetComponent<SkinnedMeshRenderer>().sharedMesh.uv;
    }

    public override void SetUV(List<Vector2> _nuvs)
    {
        body.GetComponent<SkinnedMeshRenderer>().sharedMesh.SetUVs(0, _nuvs);
    }

    #endregion

    #region Animation
    RuntimeAnimatorController standByAnimator;

    public void StandByAnimator() {
        GetAnimator().runtimeAnimatorController = standByAnimator;
    }

    public void NormalAnimator() {
        GetAnimator().runtimeAnimatorController = normalAnimator;
    }
    #endregion
    #region OnUnity
    [ContextMenu("設定零件")]
    public void SetComponent() {
        if (GetComponent<Rigidbody>() == null)
        {
             this.gameObject.AddComponent<Rigidbody>();
        }
        selfRigid = GetComponent<Rigidbody>();
        selfRigid.freezeRotation = true;
        if (GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
        selfColider = GetComponent<BoxCollider>();
        selfColider.size = new Vector3(1,2,1);
        selfColider.center = new Vector3(0,1,0);
        if (GetComponent<Animator>() == null) {
            gameObject.AddComponent<Animator>();
        }
        GetAnimator().runtimeAnimatorController = Resources.Load("/Animator/Figure") as RuntimeAnimatorController;
        SetAnimator(GetComponent<Animator>());
        
    }
    #endregion
}
