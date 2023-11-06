internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Hotel.Logic.CurrentData.LoadData();

        foreach (var item in Hotel.Logic.CurrentData.RoomList)
        {
            Console.WriteLine($"{item.roomNumber} {item.type}");
        }
    }
}