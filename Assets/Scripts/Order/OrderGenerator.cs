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

    public IList<Order> Orders;

    public IList<IOption> OptionsForRound;

    private IList<IOption> totalOptions; 
    // Use this for initialization
    void Start()
    {
        PopulateOptions();
        GetRoundOptions(); 
        SetOrders();
        StartCoroutine(OrderTimer());
        StartCoroutine(RoundTimer()); 

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator OrderTimer()
    {
        foreach (var order in Orders)
        {
            DisplayOrder(order);
            StartCoroutine(order.DoOrderTimer(TimePerOrder)); 
            yield return new WaitForSeconds(OrderInterval);
        }

    }

    private IEnumerator RoundTimer()
    {
        yield return new WaitForSeconds((Orders.Count * TimePerOrder) - (Orders.Count * OrderInterval));

        if (PropertiesPerLevel < totalOptions.Count)
            PropertiesPerLevel++;
        GetRoundOptions();
        SetOrders();

        StartCoroutine(OrderTimer());
        StartCoroutine(RoundTimer());
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
        OptionsForRound = new List<IOption>();

        for (int i = 0; i < PropertiesPerLevel; i++)
        {
            OptionsForRound.Add(totalOptions[i]);
        }
    }

    private void SetOrders()
    {
        Orders = new List<Order>();

        for (int i = 0; i < OrdersPerRound; i++)
        {
            var order = Instantiate(Resources.Load<Order>("UI/OrderPanel"));
            order.name = "Order " + i; 
            foreach (var option in OptionsForRound)
            {
                order.gameObject.transform.SetParent(transform, false);
                order.BabyProperties.Add(option.GetRandomProperty());
            }

            order.Hide();
            Orders.Add(order);
        }

    }

}
