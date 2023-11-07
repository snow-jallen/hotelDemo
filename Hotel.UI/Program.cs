internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Hotel.Logic.HotelManager.LoadData();

        foreach (var item in Hotel.Logic.HotelManager.RoomList)
        {
            Console.WriteLine($"{item.roomNumber} {item.type}");
        }
    }
}