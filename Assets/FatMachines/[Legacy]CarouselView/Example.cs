using UnityEngine;
using FM.Legacy;

public class Example : MonoBehaviour {

	[SerializeField] private Scroller scroller;

	public void SelectItem(){
		Debug.Log("Selected Index: " + scroller.GetCurrentItem());
	}

	public void SelectItem(int index){
		if(scroller.IsScrolling()){
			return;
		}
		Debug.Log("Selected Index: " + index);
	}

}
