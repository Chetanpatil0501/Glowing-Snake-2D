using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimelineController : MonoBehaviour
{
    public enum PowerAnim {TwoX, SpeedBoost, Sheild}



    private static TimelineController _instance = null;

    public static TimelineController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (TimelineController)FindObjectOfType(typeof(TimelineController));
            }
            return null;
        }
    }

    public PowerAnimations[] powerAnimationsArr;

    [System.Serializable]
    public class PowerAnimations
    {
        public PowerAnim Power;
        public GameObject gameObject;
        public AnimationClip animation;
    }

   private static AnimationClip setClip(PowerAnim anim)
    {
        foreach (PowerAnimations _Animation in Instance.powerAnimationsArr)
        {
            if (_Animation.Power == anim)
            {
         
                _Animation.gameObject.GetComponent<Animation>().clip = _Animation.animation;
                _Animation.gameObject.GetComponent<Animation>().Play();
                return _Animation.animation;
            }
        }
        return null;
    }
   
    public AnimationClip GetClip(PowerAnim anim)
    {
        return setClip(anim);

    }
}
