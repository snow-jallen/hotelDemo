using Hotel.Data;

namespace Hotel.Logic;


public static class CurrentData
{
    public static List<(string name, int cardNumber)> CustomerList = new();
    public static List<string> CurrentCustomers = new List<string>();
    public static List<(string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm)> ReservationsList = new ();
    public static List<(int roomNumber, RoomType type)> RoomList = new ();
    
    public static void LoadData()
    {
        CustomerList = FileManager.ReadInCustomers(out CurrentCustomers);
        ReservationsList = FileManager.ReadInReservations();
        RoomList = FileManager.ReadInRooms();
    }
}
