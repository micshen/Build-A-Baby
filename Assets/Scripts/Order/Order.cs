using Baby;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Order : MonoBehaviour {

    public List<BabyProperty> BabyProperties = new List<BabyProperty>();

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Hide()
    {
        gameObject.SetActive(false);       
    }

    public void DestroyOrder()
    {
        Destroy(gameObject); 
    }

    public void Show()
    {
        gameObject.SetActive(true);

        foreach (var babyProperty in BabyProperties)
        {
            var displayTextObject = Instantiate(Resources.Load<TextMeshProUGUI>("UI/OrderText"));
            displayTextObject.transform.SetParent(transform, false);
            displayTextObject.SetText(babyProperty.PropertyName);
        }
    }

    public IEnumerator DoOrderTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DestroyOrder(); 
    }
}
