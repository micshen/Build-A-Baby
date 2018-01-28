using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Baby.Interfaces;

public class OrderGenerator : MonoBehaviour
{
    private Timer timer;

    public float StartOrderDelay = 0f; 
    public float TimePerOrder = 60f;
    public float OrderInterval = 20f;

    public int OrdersPerRound = 5;
    public int PropertiesPerLevel = 2;
    public int MaxNumberOfProperties = 5; 

    public IList<Order> Orders;

    private IList<IOption> optionsForRound;

    private IList<IOption> totalOptions; 
    // Use this for initialization
    void Start()
    {
        PopulateOptions(); 
        GetRoundOptions();
        SetOrders(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ManageOrdersPerRound()
    {
        var totalOrderTime = 0f;
        foreach (var order in Orders)
        {
            DisplayOrder(order);
            totalOrderTime += TimePerOrder - OrderInterval; 
            StartCoroutine(order.DoOrderTimer(TimePerOrder)); 
            yield return new WaitForSeconds(OrderInterval);

        }

        yield return new WaitForSeconds(totalOrderTime); 
        GetRoundOptions();
        SetOrders();
        StartCoroutine(ManageOrdersPerRound()); 
    }

    private void DisplayOrder(Order order)
    {
        order.Show(); 
    }

    private IOption GetRandomOption()
    {
        if (totalOptions.Count > 1)
            return totalOptions[Random.Range(0, totalOptions.Count)];
        else
            return totalOptions[0];
    }

    private void PopulateOptions()
    {
        totalOptions = GetComponentsInChildren<IOption>();
    }

    private void GetRoundOptions()
    {
        optionsForRound = new List<IOption>();

        for (int i = 0; i < PropertiesPerLevel; i++)
        {
            var randomOption = GetRandomOption();
            if (!optionsForRound.Contains(randomOption))
                optionsForRound.Add(randomOption);
        }

        if(PropertiesPerLevel <= MaxNumberOfProperties)
            PropertiesPerLevel++;
    }

    private void SetOrders()
    {
        Orders = new List<Order>();

        for (int i = 0; i < OrdersPerRound; i++)
        {
            var order = Instantiate(Resources.Load<Order>("UI/OrderPanel"));
            foreach (var option in optionsForRound)
            {
                order.gameObject.transform.SetParent(transform, false);
                order.BabyProperties.Add(option.GetRandomProperty());
            }

            order.Hide();
            Orders.Add(order);
        }

        StartCoroutine(ManageOrdersPerRound());
    }

}
