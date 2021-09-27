using UnityEngine;

namespace FM{
    public class DeviceOrientation : MonoBehaviour {
        public enum Orientation { Horizontal, Vertical };

        Orientation orientation = Orientation.Vertical;
        System.Action<Orientation> OnOrientationChange;

        void Update(){
            if(Screen.height > Screen.width){
                if(orientation != Orientation.Vertical){
                    orientation = Orientation.Vertical;
                    if(OnOrientationChange != null) OnOrientationChange(orientation);
                }
            }else{
                if(orientation != Orientation.Horizontal){
                    orientation = Orientation.Horizontal;
                    if (OnOrientationChange != null) OnOrientationChange(orientation);
                }
            }
        }

        public void AddOnOrienationChange(System.Action<Orientation> _OnOrientationChange){
            OnOrientationChange += _OnOrientationChange;
        }

    }
}
