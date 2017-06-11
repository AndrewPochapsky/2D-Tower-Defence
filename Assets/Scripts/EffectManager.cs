using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour{

    public enum EffectType { SLOW};
    private bool effectBeingCast = false;
    public void ApplyEffect(Enemy target, EffectType type)
    {
        switch (type)
        {
            case EffectType.SLOW:
                StartCoroutine(SlowEffect(target));      
                break;

        }
    }

    private IEnumerator SlowEffect(Enemy target)
    {
        target.AlterSpeed(-0.5f);
        yield return new WaitForSeconds(1);
        target.AlterSpeed(0.5f);
    }


}
