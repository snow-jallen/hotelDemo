using Hotel.Data;

namespace Hotel.Logic;


public static class HotelManager
{
    public static List<(string name, int cardNumber)> CustomerList = new();
    public static List<(string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm)> ReservationsList = new ();
    public static List<(int roomNumber, RoomType type)> RoomList = new ();
    public static List<(RoomType type, decimal dailyRate)> RoomPricesList = new();
    
    public static void LoadData()
    {
        CustomerList = DataManager.ReadInCustomers();
        ReservationsList = DataManager.ReadInReservations();
        RoomList = DataManager.ReadInRooms();
        RoomPricesList = DataManager.ReadInRoomPrices();
    }

    public static void AddCustomer(string name, int cardNumber)
    {
        if (DoesACustomerAlreadyExist(name))
        {
            throw new Exception("Customer already exists");
        }
        CustomerList.Add((name,cardNumber));
    }

    public static bool DoesACustomerAlreadyExist(string newCustomerName)
    {
        foreach (var existingCustomer in CustomerList)
        {
            if (existingCustomer.name == newCustomerName)
                return true;
        }
        return false;
    }
}
