using UnityEngine;
using FM;

public class ExampleScript : MonoBehaviour {

    [SerializeField] private CarouselView carouselView;

    void Start(){
        carouselView.AddOnItemSelectedListener((int index) => {
            Debug.Log("Selected: " + index);
        });
    }

    public void SelectItem(){
		Debug.Log("Selected Index: " + carouselView.GetCurrentItem());
	}

    public void ScrollNext(){
        carouselView.Next();
    }

    public void ScrollPrevious(){
        carouselView.Previous();
    }

    public void Select(int index){
        carouselView.SelectIndex(index, true);
    }

}
