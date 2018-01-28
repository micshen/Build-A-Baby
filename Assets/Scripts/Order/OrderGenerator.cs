using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Baby.Interfaces;
using Baby;

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

    public List<string> BodyStrings = new List<string>();
    public List<string> SkinStrings = new List<string>();
    public List<string> MentalStrings = new List<string>();
    public List<string> HairStrings = new List<string>();
    public List<string> EyeStrings = new List<string>();
    public List<string> TeethStrings = new List<string>();
    public List<string> AttributeStrings = new List<string>();

    private List<List<string>> allAttributes = new List<List<string>>(); 

    // Use this for initialization
    void Start()
    {
        PopulateBabyData(); 
        PopulateOptions();
       // GetRoundOptions(); 
        SetOrders();
        StartCoroutine(OrderTimer());
       // StartCoroutine(RoundTimer()); 

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
        if (PropertiesPerLevel < allAttributes.Count)
            PropertiesPerLevel++;
        //GetRoundOptions();
        SetOrders();

        StartCoroutine(OrderTimer());
    }

    //private IEnumerator RoundTimer()
    //{


    //    StartCoroutine(RoundTimer());
    //}


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
            //foreach (var property in )
            //{
            //    order.gameObject.transform.SetParent(transform, false);
            //    order.BabyProperties.Add(option.GetRandomProperty());
            //}

            for (int j = 0; j < PropertiesPerLevel; j++) {
                order.gameObject.transform.SetParent(transform, false);
                var babyProperty = order.gameObject.AddComponent<BabyProperty>();
                babyProperty.PropertyName = GetProperty(j); 
                order.BabyProperties.Add(babyProperty); 
            }
            
            order.Hide();
            Orders.Add(order);
        }

    }

    private string GetProperty(int index )
    {
        int random = Random.RandomRange(0, allAttributes[index].Count);
        return allAttributes[index][random]; 
    }

    public void PopulateBabyData()
    {
        BodyStrings.Add("Deformed Body");
        BodyStrings.Add("Skinny Body");
        BodyStrings.Add("Fat Body");
        BodyStrings.Add("Normal Body");
        BodyStrings.Add("Buff Body");

        allAttributes.Add(BodyStrings); 

        SkinStrings.Add("White Skin");
        SkinStrings.Add("Green Skin");
        SkinStrings.Add("Purple Skin");
        SkinStrings.Add("Blue Skin");
        SkinStrings.Add("Golden Skin");

        allAttributes.Add(SkinStrings);


        MentalStrings.Add("Psychopath");
        MentalStrings.Add("Kinda Dumb");
        MentalStrings.Add("Way Too Nice");
        MentalStrings.Add("Normal");
        MentalStrings.Add("Genius");

        allAttributes.Add(MentalStrings);


        HairStrings.Add("Blue Hair");
        HairStrings.Add("Gray Hair");
        HairStrings.Add("Black Hair");
        HairStrings.Add("Brown Hair");
        HairStrings.Add("Blonde Hair");

        allAttributes.Add(HairStrings);

        EyeStrings.Add("Black Eyes");
        EyeStrings.Add("Red Eyes");
        EyeStrings.Add("Brown Eyes");
        EyeStrings.Add("Green Eyes");
        EyeStrings.Add("Blue Eyes");

        allAttributes.Add(EyeStrings); 

        TeethStrings.Add("Wooden Vampire Teeth");
        TeethStrings.Add("White Vampire Teeth");
        TeethStrings.Add("Normal Black Teeth");
        TeethStrings.Add("Normal White Teeth");
        TeethStrings.Add("Full Golden Teeth");

        allAttributes.Add(TeethStrings); 

        AttributeStrings.Add("Baby Alzheimers");
        AttributeStrings.Add("Strength");
        AttributeStrings.Add("Dexterity");
        AttributeStrings.Add("Charisma");
        AttributeStrings.Add("Intelligence");

        allAttributes.Add(AttributeStrings); 
    }

}
