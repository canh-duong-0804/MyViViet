using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class gameControllerHue : MonoBehaviour
{
    public GameObject customer;

    public GameObject checkWaiter;

    public Waiter newWaiter;

    [SerializeField] SpriteRenderer FoodRendererKitchen;
    [SerializeField] SpriteRenderer FoodRendererSlot1;
    [SerializeField] SpriteRenderer FoodRendererSlot2;
    [SerializeField] SpriteRenderer FoodRendererSlot3;
    [SerializeField] SpriteRenderer FoodRendererSlot4;
    [SerializeField] GameObject enablePopupSlot1;
    [SerializeField] GameObject enablePopupSlot2;
    [SerializeField] GameObject enablePopupSlot3;
    [SerializeField] GameObject enablePopupSlot4;
    [SerializeField] GameObject enablePopupKitchen;


    [SerializeField] private Transform recieveOrderSlot1;
    [SerializeField] private Transform recieveOrderSlot2;
    [SerializeField] private Transform recieveOrderSlot3;
    [SerializeField] private Transform recieveOrderSlot4;
    [SerializeField] private Transform targetPositionKitchen;
    [SerializeField] private Transform targetObjectCustomer1;
    [SerializeField] private Transform targetObjectCustomer2;
    [SerializeField] private Transform targetObjectCustomer3;
    [SerializeField] private Transform targetObjectCustomer4;
    [SerializeField] private TMP_Text textCoins;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private SkeletonAnimation waterSkel;
    [SerializeField] private SkeletonAnimation customerWalkSkel;
    [SerializeField] private SkeletonAnimation customerSitSkel;

    [SerializeField] private Transform customerExit;
    [SerializeField] private List<Dishes> dishesListHue;


    [SerializeField] private GameObject upgradeScreen;

    public float coinsRestaurant { get; set; }
    private const string GameDataKey = "GameData1-6";


    private int randomFood;


    public List<Dishes> DishesListHue
    {
        get { return dishesListHue; }
        set { dishesListHue = value; }
    }



    [Range(0f, 5f)] public float speed11 = 2f;


    private bool statusSlotFreeOfSlot1 = true;
    private bool statusslotLoop = true;
    private bool statusSlotFreeOfSlot2 = true;
    private bool statusSlotFreeOfSlot3 = true;
    //private bool statusSlotFreeOfSlot4 = true;
    private string str = "";

    private int count = 0;

    private bool statusSlotReciveFreeOfSlot1 = true;
    private bool statusSlotReciveFreeOfSlot2 = false;
    private bool statusSlotReciveFreeOfSlot3 = false;
    //private bool statusSlotReciveFreeOfSlot4 = false;


    private Queue<Customer> customerList = new Queue<Customer>();
    private Queue<Customer> Listcus1 = new Queue<Customer>();





    int count1 = 0;



    [SerializeField]
    private SpriteRenderer sr;





    public static gameControllerHue instance;





    private void Start()
    {
        instance = this;
        LoadGameData();

    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGameData();
        }
    }

    void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void SaveGameData()
    {
        GameData data = new GameData
        {
            coinsRestaurant = coinsRestaurant,
            DishesListHue = dishesListHue
        };

        string json1_5 = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(GameDataKey, json1_5);
        PlayerPrefs.Save();
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey(GameDataKey))
        {
            string json1_5 = PlayerPrefs.GetString(GameDataKey);
            GameData data = JsonUtility.FromJson<GameData>(json1_5);
            coinsRestaurant = data.coinsRestaurant;
            dishesListHue = data.DishesListHue;
        }
        else
        {
            coinsRestaurant = 200f; // Default value if no data is found
            //dishesListHue = new List<Dishes>(); // Default value if no data is found
        }
    }

    private void Update()
    {
        Waiter newWaiter = checkWaiter.GetComponent<Waiter>();
        textCoins.text = " " + coinsRestaurant;

        if (statusSlotFreeOfSlot1 || statusSlotFreeOfSlot2 || statusSlotFreeOfSlot3)
        {

            GameObject newCustomerObject = Instantiate(customer, spawnPoint.position, Quaternion.identity);
            newCustomerObject.name = "cus " + count++;

            Customer customerObject = newCustomerObject.GetComponent<Customer>();
            CustomerManager customerManager = newCustomerObject.GetComponent<CustomerManager>();
            customerList.Enqueue(customerObject);
            Listcus1.Enqueue(customerObject);


            Customer cus = Listcus1.Dequeue();
            if (!statusslotLoop)
            {

                if (statusSlotFreeOfSlot3)
                {
                    cus.SetFreeSpot(targetObjectCustomer3.transform);
                    StartCoroutine(SetCustomerManagerStatus(customerManager));
                    StartCoroutine(CountDownAndSetFreeSpot2(newWaiter));
                    statusSlotFreeOfSlot3 = false;
                }
                else if (statusSlotFreeOfSlot1)
                {
                    cus.SetFreeSpot(targetObjectCustomer1.transform);
                    StartCoroutine(SetCustomerManagerStatus(customerManager));
                    statusSlotFreeOfSlot1 = false;
                }
                else if (statusSlotFreeOfSlot2)
                {
                    cus.SetFreeSpot(targetObjectCustomer2.transform);
                    StartCoroutine(SetCustomerManagerStatus(customerManager));
                    statusSlotFreeOfSlot2 = false;
                }
            }
            else
            {
                if (statusSlotFreeOfSlot1)
                {


                    cus.SetFreeSpot(targetObjectCustomer1.transform);
                    StartCoroutine(SetCustomerManagerStatus(customerManager));
                    StartCoroutine(CountDownAndSetFreeSpotSlot1(cus, newWaiter));

                    statusSlotFreeOfSlot1 = false;
                }

                else if (statusSlotFreeOfSlot2)
                {


                    cus.SetFreeSpot(targetObjectCustomer2.transform);

                    StartCoroutine(SetCustomerManagerStatus(customerManager));
                    statusSlotFreeOfSlot2 = false;

                }
                else if (statusSlotFreeOfSlot3)
                {


                    cus.SetFreeSpot(targetObjectCustomer3.transform);
                    StartCoroutine(SetCustomerManagerStatus(customerManager));
                    statusSlotFreeOfSlot3 = false;

                }
            }
        }


    }


    private IEnumerator SetCustomerManagerStatus(CustomerManager customerManager)
    {

        yield return new WaitForSeconds(2f);
        customerManager.SetActiveSit(true);
        customerManager.SetActiveFront(false);

    }
    private IEnumerator SetCustomerManagerStatus1(CustomerManager customerManager)
    {

        yield return new WaitForSeconds(0f);
        customerManager.SetActiveFront(true);
        customerManager.SetActiveSit(false);

    }
    IEnumerator CountDownAndSetFreeSpot2(Waiter newWaiter)
    {
        System.Random random = new System.Random();
        var unlockedDishes = DishesListHue.Where(d => d.isUnLock).ToList();


        if (statusSlotReciveFreeOfSlot1 && !statusSlotFreeOfSlot1)
        {
            randomFood = random.Next(unlockedDishes.Count);
            Waiter.instance.testWaiter = "MoveWaiterToTable";


            Customer customer1 = customerList.Dequeue();
            //
            CustomerManager customerManager = customer1.GetComponent<CustomerManager>();
            waterSkel.AnimationName = "Front_Walk";
            Sprite food = Resources.Load<Sprite>("FoodsDish/hue/" + randomFood);
            FoodRendererSlot1.sprite = food;
            FoodRendererKitchen.sprite = food;

            enablePopupSlot1.SetActive(true);
            enablePopupKitchen.SetActive(true);

            //

            yield return new WaitForSeconds(1f);
            waterSkel.AnimationName = "Front_Idle";


            newWaiter.SetFreeSpot1(targetPositionKitchen.transform);
            yield return new WaitForSeconds(1f);
            waterSkel.AnimationName = "Front_Idle";

            yield return new WaitForSeconds(dishesListHue[randomFood].processFood);

            enablePopupKitchen.SetActive(false);
            newWaiter.SetFreeSpot1(recieveOrderSlot1.transform);

            customerSitSkel.AnimationName = "sit_eat";

            enablePopupSlot1.SetActive(false);
            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1.5f);

            waterSkel.AnimationName = "Front_Serve";
            yield return new WaitForSeconds(1.7f);
            StartCoroutine(SetCustomerManagerStatus1(customerManager));

            customer1.SetFreeSpot(customerExit.transform);


            waterSkel.AnimationName = "Front_Walk";
            coinsRestaurant = dishesListHue[randomFood].price + coinsRestaurant;
            textCoins.text = " " + coinsRestaurant;


            StartCoroutine(CountDownToDestroy(customer1));
            statusSlotReciveFreeOfSlot1 = false;
            statusSlotReciveFreeOfSlot2 = false;
            statusSlotFreeOfSlot1 = true;

        }
        if (!statusSlotReciveFreeOfSlot2 && !statusSlotFreeOfSlot2)
        {
            randomFood = random.Next(unlockedDishes.Count);
            Customer customer2 = customerList.Dequeue();
            CustomerManager customerManager = customer2.GetComponent<CustomerManager>();
            waterSkel.AnimationName = "Front_Walk";
            waterSkel.AnimationName = "Front_Walk";
            //

            Sprite food = Resources.Load<Sprite>("FoodsDish/hue/" + randomFood);
            FoodRendererSlot2.sprite = food;
            FoodRendererKitchen.sprite = food;
            enablePopupSlot2.SetActive(true);
            enablePopupKitchen.SetActive(true);
            //
            yield return new WaitForSeconds(1f);

            newWaiter.SetFreeSpot1(targetPositionKitchen.transform);
            yield return new WaitForSeconds(1f);
            waterSkel.AnimationName = "Front_Idle";
            yield return new WaitForSeconds(dishesListHue[randomFood].processFood);
            enablePopupKitchen.SetActive(false);
            newWaiter.SetFreeSpot1(recieveOrderSlot2.transform);
            enablePopupSlot2.SetActive(false);
            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1.5f);

            waterSkel.AnimationName = "Front_Serve";
            yield return new WaitForSeconds(1.7f);

            statusSlotReciveFreeOfSlot3 = true;
            statusSlotFreeOfSlot2 = true;
            StartCoroutine(SetCustomerManagerStatus1(customerManager));
            customer2.SetFreeSpot(customerExit.transform);


            coinsRestaurant = dishesListHue[randomFood].price + coinsRestaurant;
            textCoins.text = " " + coinsRestaurant;

            waterSkel.AnimationName = "Front_Walk";

            StartCoroutine(CountDownToDestroy(customer2));

        }
        if (statusSlotReciveFreeOfSlot3 && !statusSlotFreeOfSlot3)
        {
            randomFood = random.Next(unlockedDishes.Count);
            Customer customer2 = customerList.Dequeue();
            CustomerManager customerManager = customer2.GetComponent<CustomerManager>();
            waterSkel.AnimationName = "Front_Walk";

            //
            Sprite food = Resources.Load<Sprite>("FoodsDish/hue/" + randomFood);
            FoodRendererSlot3.sprite = food;
            FoodRendererKitchen.sprite = food;
            enablePopupSlot3.SetActive(true);
            enablePopupKitchen.SetActive(true);
            //
            yield return new WaitForSeconds(1f);

            newWaiter.SetFreeSpot1(targetPositionKitchen.transform);
            waterSkel.AnimationName = "Front_Idle";
            yield return new WaitForSeconds(dishesListHue[randomFood].processFood);
            enablePopupSlot3.SetActive(false);
            newWaiter.SetFreeSpot1(recieveOrderSlot3.transform);
            enablePopupKitchen.SetActive(false);
            yield return new WaitForSeconds(2f);

            statusSlotFreeOfSlot3 = true;
            statusSlotReciveFreeOfSlot1 = true;
            StartCoroutine(SetCustomerManagerStatus1(customerManager));
            customer2.SetFreeSpot(customerExit.transform);


            waterSkel.AnimationName = "Front_Walk";
            coinsRestaurant = dishesListHue[randomFood].price + coinsRestaurant;
            textCoins.text = " " + coinsRestaurant;

            waterSkel.AnimationName = "Front_Walk";

            // statusslotLoop = true;
            StartCoroutine(CountDownToDestroy(customer2));


        }
    }






    IEnumerator CountDownAndSetFreeSpotSlot1(Customer newCustomer, Waiter newWaiter)
    {
        System.Random random = new System.Random();
        var unlockedDishes = DishesListHue.Where(d => d.isUnLock).ToList();




        statusSlotReciveFreeOfSlot2 = true;
        statusSlotReciveFreeOfSlot3 = true;

        if (statusSlotFreeOfSlot1 && statusSlotReciveFreeOfSlot1)
        {
            randomFood = random.Next(unlockedDishes.Count);
            Waiter.instance.testWaiter = "MoveWaiterToTable";
            Customer customer1 = customerList.Dequeue();
            CustomerManager customerManager = customer1.GetComponent<CustomerManager>();
            waterSkel.AnimationName = "Front_Walk";
            //

            Sprite food = Resources.Load<Sprite>("FoodsDish/hue/" + randomFood);
            FoodRendererSlot1.sprite = food;
            FoodRendererKitchen.sprite = food;



            //
            newWaiter.SetFreeSpot1(targetPositionKitchen.transform);
            yield return new WaitForSeconds(2f);

            yield return new WaitForSeconds(1f);
            enablePopupSlot1.SetActive(true);
            enablePopupKitchen.SetActive(true);
            waterSkel.AnimationName = "Front_Idle";
            Debug.Log("adsda " + dishesListHue[randomFood].processFood);
            yield return new WaitForSeconds(dishesListHue[randomFood].processFood);
            enablePopupKitchen.SetActive(false);

            newWaiter.SetFreeSpot1(recieveOrderSlot1.transform);
            enablePopupSlot1.SetActive(false);
            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1.5f);

            waterSkel.AnimationName = "Front_Serve";
            yield return new WaitForSeconds(1.7f);
            StartCoroutine(SetCustomerManagerStatus1(customerManager));
            customer1.SetFreeSpot(customerExit.transform);

            waterSkel.AnimationName = "Front_Walk";
            coinsRestaurant = dishesListHue[randomFood].price + coinsRestaurant;
            textCoins.text = " " + coinsRestaurant;

            statusSlotFreeOfSlot1 = true;
            StartCoroutine(CountDownToDestroy(customer1));

            waterSkel.AnimationName = "Front_Walk";


            statusSlotReciveFreeOfSlot2 = false;
            statusSlotReciveFreeOfSlot1 = false;

        }



        if (!statusSlotFreeOfSlot2 && !statusSlotReciveFreeOfSlot2)
        {
            randomFood = random.Next(unlockedDishes.Count);

            Customer customer2 = customerList.Dequeue();
            CustomerManager customerManager = customer2.GetComponent<CustomerManager>();
            waterSkel.AnimationName = "Front_Walk";
            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1f);
            //

            Sprite food = Resources.Load<Sprite>("FoodsDish/hue/" + randomFood);
            FoodRendererSlot2.sprite = food;
            FoodRendererKitchen.sprite = food;
            //
            newWaiter.SetFreeSpot1(targetPositionKitchen.transform);
            yield return new WaitForSeconds(1f);
            enablePopupSlot2.SetActive(true);
            enablePopupKitchen.SetActive(true);
            waterSkel.AnimationName = "Front_Idle";

            yield return new WaitForSeconds(dishesListHue[randomFood].processFood);

            //yield return new WaitForSeconds(1f);


            newWaiter.SetFreeSpot1(recieveOrderSlot2.transform);
            enablePopupSlot2.SetActive(false);
            enablePopupKitchen.SetActive(false);

            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1.5f);

            waterSkel.AnimationName = "Front_Serve";
            yield return new WaitForSeconds(1.7f);

            StartCoroutine(SetCustomerManagerStatus1(customerManager));
            statusSlotReciveFreeOfSlot3 = false;
            customer2.SetFreeSpot(customerExit.transform);

            waterSkel.AnimationName = "Front_Walk";

            coinsRestaurant = dishesListHue[randomFood].price + coinsRestaurant;
            textCoins.text = " " + coinsRestaurant;

            statusSlotFreeOfSlot2 = true;
            statusSlotReciveFreeOfSlot1 = false;
            StartCoroutine(CountDownToDestroy(customer2));


        }
        //yield return new WaitForSeconds(1f);

        if (!statusSlotFreeOfSlot3 && !statusSlotReciveFreeOfSlot3)
        {
            randomFood = random.Next(unlockedDishes.Count);

            Customer customer3 = customerList.Dequeue();
            CustomerManager customerManager = customer3.GetComponent<CustomerManager>();
            waterSkel.AnimationName = "Front_Walk";
            Waiter.instance.testWaiter = "MoveWaiterToTable";


            waterSkel.AnimationName = "Front_Walk";
            //
            Sprite food = Resources.Load<Sprite>("FoodsDish/hue/" + randomFood);
            FoodRendererSlot3.sprite = food;
            FoodRendererKitchen.sprite = food;
            //
            yield return new WaitForSeconds(1f);



            newWaiter.SetFreeSpot1(targetPositionKitchen.transform);
            enablePopupSlot3.SetActive(true);
            enablePopupKitchen.SetActive(true);
            //yield return new WaitForSeconds(1f);
            waterSkel.AnimationName = "Front_Idle";
            yield return new WaitForSeconds(dishesListHue[randomFood].processFood);

            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1f);
            newWaiter.SetFreeSpot1(recieveOrderSlot3.transform);
            enablePopupSlot3.SetActive(false);
            enablePopupKitchen.SetActive(false);
            waterSkel.AnimationName = "Front_Walk";
            yield return new WaitForSeconds(1.5f);

            waterSkel.AnimationName = "Front_Serve";
            yield return new WaitForSeconds(1.7f);
            StartCoroutine(SetCustomerManagerStatus1(customerManager));

            customer3.SetFreeSpot(customerExit.transform);
            waterSkel.AnimationName = "Front_Walk";
            coinsRestaurant = dishesListHue[randomFood].price + coinsRestaurant;
            textCoins.text = " " + coinsRestaurant;

            statusSlotFreeOfSlot3 = true;
            statusSlotReciveFreeOfSlot1 = true;

            StartCoroutine(CountDownToDestroy(customer3));
            statusslotLoop = false;
        }



    }

    IEnumerator CountDownToDestroy(Customer newCustomer)
    {
        yield return new WaitForSeconds(2.4f);
        Destroy(newCustomer.gameObject);
    }



}