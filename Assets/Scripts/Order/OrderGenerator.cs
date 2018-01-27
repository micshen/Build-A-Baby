using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OrderGenerator : MonoBehaviour
{
    private Timer timer;

    public float StartOrderDelay = 0f; 
    public float TimePerOrder = 60f;
    public float OrderInterval = 20f; 

    //put orders in child of OrderGenerator Canvas Object
    public IEnumerable<Order> Orders;

    private BodyOption bodyOption; 
    // Use this for initialization
    void Start()
    {
        Orders = GetComponentsInChildren<Order>();

        bodyOption = GetComponent<BodyOption>();

        foreach (var order in Orders)
        {
            order.BabyProperties.Add(bodyOption.GetRandomProperty());
            order.Hide(); 
            
        }

        StartCoroutine(ManageOrders()); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ManageOrders()
    {
        foreach (var order in Orders)
        {
            DisplayOrder(order);
            StartCoroutine(order.DoOrderTimer(TimePerOrder)); 
            yield return new WaitForSeconds(OrderInterval);
        }
    }

    private void DisplayOrder(Order order)
    {
        order.Show(); 
    }


}
