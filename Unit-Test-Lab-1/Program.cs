class Program
{
    static void Main(string[] args)
    {
        VehicleTracker vt = new VehicleTracker(100, "123 Fake st");

        Vehicle customerOne = new Vehicle("A01 T22", true);
        Vehicle customerTwo = new Vehicle("A01 T24", true);
        Vehicle customer3 = new Vehicle("A01 T23", false);

        vt.AddVehicle(customerOne);
        vt.AddVehicle(customerTwo);
        vt.AddVehicle(customer3);

        //vt.RemoveVehicle("A01 T22");

        Console.WriteLine(vt.SlotsAvailable);
        Console.WriteLine(vt.VehicleList.Count);
        Console.WriteLine(vt.ParkedPassholders().Count);
        Console.WriteLine(vt.PassholderPercentage());
    }
}

public class Vehicle
{
    public string Licence { get; set; }
    public bool Pass { get; set; }
    public Vehicle(string licence, bool pass)
    {
        this.Licence = licence;
        this.Pass = pass;
    }
}

public class VehicleTracker
{
    //PROPERTIES
    public string Address { get; set; }
    public int Capacity { get; set; }
    public int SlotsAvailable { get; set; } //SlotsTaken would be a better property name
    public Dictionary<int, Vehicle> VehicleList { get; set; }

    public VehicleTracker(int capacity, string address)
    {
        this.Capacity = capacity;
        this.Address = address;
        this.VehicleList = new Dictionary<int, Vehicle>();

        this.GenerateSlots();
    }

    // STATIC PROPERTIES
    public static string BadSearchMessage = "Error: Search did not yield any result.";
    public static string BadSlotNumberMessage = "Error: No slot with number ";
    public static string SlotsFullMessage = "Error: no slots available.";

    // METHODS
    //Altered this to make the count even with the capacity - Since zero counts towards the total, if the capacity was 100 the total spots would equal 101. 
    public void GenerateSlots()
    {
        for (int i = 0; i < this.Capacity; i++)
        {
            this.VehicleList.Add(i, null);
            this.SlotsAvailable = VehicleList.Count;
        }
    }

    public void AddVehicle(Vehicle vehicle)
    {
        foreach (KeyValuePair<int, Vehicle> slot in this.VehicleList)
        {
            if (slot.Value == null)
            {
                this.VehicleList[slot.Key] = vehicle;
                this.SlotsAvailable--;
                return;
            }
        }
        throw new IndexOutOfRangeException(SlotsFullMessage);
    }

    public void RemoveVehicle(string licence)
    {
        try
        {
            int slot = this.VehicleList.First(v => v.Value.Licence == licence).Key;
            this.SlotsAvailable++;
            this.VehicleList[slot] = null;
        }
        catch
        {
            throw new NullReferenceException(BadSearchMessage);
        }
    }

    public bool RemoveVehicle(int slotNumber)
    {
        if (slotNumber > this.Capacity)
        {
            return false;
        }
        this.VehicleList[slotNumber] = null;
        this.SlotsAvailable--;
        return true;
    }

    public List<Vehicle> ParkedPassholders()
    {
        List<Vehicle> passHolders = new List<Vehicle>();
        foreach(KeyValuePair<int, Vehicle> vehicle in this.VehicleList)
        {
            if(vehicle.Value != null)
            {
                if(vehicle.Value.Pass == true)
                {
                    passHolders.Add(vehicle.Value);
                }
            }
        }
        return passHolders;
    }

    public double PassholderPercentage()
    {
        double passHolders = ParkedPassholders().Count();
        double percentage = (passHolders / this.Capacity) * 100;
        return percentage;
    }
}

