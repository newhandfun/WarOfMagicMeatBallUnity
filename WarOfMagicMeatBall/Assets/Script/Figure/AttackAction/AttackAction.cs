using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Attacktion")]
public class AttactionData : ScriptableObject {


    public virtual int GetAttactNumber() {
        return 3;
    }

    public virtual int GetSkillNumber() {
        return 4;
    }

}
