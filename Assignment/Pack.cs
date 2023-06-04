namespace Assignment;

public class Pack
{
    private readonly InventoryItem[] _items; // You can use another data structure here if you prefer.
    // You may need another private member variable if you use an array data structure.

    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;
    private int _currentCount; // Defaults to 0
    private float _currentVolume;
    private float _currentWeight;
    // Default constructor sets the maxCount to 10 
    // maxVolume to 20 
    // maxWeight to 30
    public Pack() : this(10, 20, 30) { }

    // This constructor is not complete, but it is a good start.
    //Constructor for the Pack class
    //<param name= "maxCount">The maximum count of items that the pack can hold.</param>
    //<param name= "maxVolume">The maximum volume the pack can hold.</param>
    //<param name= "maxWeight">The maximum weight the pack can hold.</param>
    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        _items = new InventoryItem[maxCount];
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
    }

    // This is called a getter

//Gets the current maximum count of items that the pack can hold
//<returns>The maximum count of items.</returns>
    public int GetMaxCount()
    {
        return _maxCount;
    }
//Gets the current maximum volume that the pack can hold
//<returns>The maximum volume of the pack.</returns>
    public float GetVolume()
    {
        return _currentVolume;
    }
//Adds the inventory item to the pack
//<param name="item">The inventory item to add.</param>
//<returns>True if the item was added successfully,false otherwise.</returns>
    public bool Add(InventoryItem item)
    {
        // In the `Add` method, check if adding the item would exceed the pack's 
        // maximum count, weight, or volume. If it would not exceed these limits, 
        // add the item to the pack and return `true`. Otherwise, return `false`.

        // Does the current item cause _currentCount to be > _maxCount ... same for vol. and weight
        // if the new item will exceed these parameters, return false
        // else add it to the _items array and return true.

        // Do your logic to ensure the item can be added
        float weight = item.GetWeight();
        float volume = item.GetVolume();
        if (_currentCount < _maxCount && _currentWeight + weight <= _maxWeight && _currentVolume + volume <= _maxVolume)
        {
        _items[_currentCount++] = item;
        _currentCount++;
        _currentWeight += weight;
        _currentVolume += volume;
        return true;
        }
        return false;
    }

    //<summary>
    //A string representation of a pack is being returned
    //<summary>
    //<returns>A string reprsentation of the pack indicating the current item count, weight and volume <returns>
    public override string ToString()
    {
        string result = $"Pack is current at {_currentCount}/{_maxCount} items, {_currentWeight}/{_maxWeight} weight, and {_currentVolume}/{_maxVolume} volume.";
        return result;
    }
}

// Come back to this once we learn about abstract classes.
public abstract class InventoryItem
{
    private readonly float _volume;
    private readonly float _weight;
    //<param name="volume">The volume of the item.</param>
    //<param name="weight">The weight of the item.</param>
    //Thrown when the volume or weight is less than or equal to zero

    protected InventoryItem(float volume, float weight)
    {
        if (volume <= 0f || weight <= 0f)
        {
            throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
        }
        _volume = volume;
        _weight = weight;
    }

    // Returns a string representing the quantities of the item (volume & weight of the item)
    public abstract string Display();

    // Getters
    public float GetVolume()
    {
        return _volume;
    }

    public float GetWeight()
    {
        return _weight;
    }
}

// Represent an arrow
public class Arrow : InventoryItem
{
//Initializes a new instance of the <see cref="Arrow"/>class.
    public Arrow() : base(0.5f, 0.1f) { }
    //Displays information about the arrow

    public override string Display()
    {
        return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
    }
}
// Represent an bow
public class Bow : InventoryItem
{
//Initializes a new instance of the <see cref="bow"/>class.
    public Bow() : base(1f, 4f) { }
     //Displays information about the bow
    public override string Display()
    {
        return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
    }
}
// Represent an rope
public class Rope : InventoryItem
{
//Initializes a new instance of the <see cref="rope"/>class.
    public Rope() : base(1f, 1.5f) { }
 //Displays information about the Rope
    public override string Display()
    {
        return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
    }
}
// Represent an Water
public class Water : InventoryItem
{
//Initializes a new instance of the <see cref="water"/>class.
    public Water() : base(2f, 3f) { }
     //Displays information about the Water
    public override string Display()
    {
        return $"Water with weight {GetWeight()} and volume {GetVolume()}";
    }
}
// Represent an Food
public class Food : InventoryItem
{
//Initializes a new instance of the <see cref="food"/>class.
    public Food() : base(1f, 0.5f) { }
  //Displays information about the food
    public override string Display()
    {
        return $"Yummy food with weight {GetWeight()} and volume {GetVolume()}";
    }
}
// Represent an sword
public class Sword : InventoryItem
{
//Initializes a new instance of the <see cref="sword"/>class.
    public Sword() : base(5f, 3f) { }
 //Displays information about the Sword
    public override string Display()
    {
        return $"A sharp sword with weight {GetWeight()} and volume {GetVolume()}";
    }
}
