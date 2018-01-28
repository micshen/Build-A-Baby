using Baby;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Order : MonoBehaviour {

    public List<BabyProperty> BabyProperties = new List<BabyProperty>();

    public bool IsActive; 

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Hide()
    {
        IsActive = false; 
        gameObject.SetActive(false);       
    }

    public void DestroyOrder()
    {
        try
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
        catch (Exception ex)
        {

        }
    
    }

    public void Show()
    {
        gameObject.SetActive(true);
        IsActive = true; 

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
        if(gameObject != null)
            DestroyOrder(); 
    }
}
