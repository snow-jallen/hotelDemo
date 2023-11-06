namespace Hotel.Data;

public enum RoomType { Single, Double, Suite, Deluxe };

public static class FileManager
{

    public static List<(string name, int cardNumber)> ReadInCustomers(out List<string> currentCustomers)
    {
        List<(string name, int cardNumber)> customers = new();
        currentCustomers = new();
        string[] linesInCustomerFile = File.ReadAllLines("Customers.txt");
        foreach (string Customer in linesInCustomerFile)
        {
            string[] CustomerParts = Customer.Split(",");
            (string name, int cardNumber) CustomerInfo = (CustomerParts[0], Convert.ToInt32(CustomerParts[1]));
            customers.Add(CustomerInfo);
            currentCustomers.Add(CustomerParts[0]);
        }
        return customers;
    }

    public static List<(string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm)> ReadInReservations()
    {
        List<(string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm)> reservations = new();
        string[] Reservations = File.ReadAllLines("Reservations.txt");
        foreach (string Reservation in Reservations)
        {
            string[] ReservationParts = Reservation.Split(",");
            (string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm) ReservationInfo = (ReservationParts[0], DateOnly.Parse(ReservationParts[1]), Convert.ToInt32(ReservationParts[2]), ReservationParts[3], ReservationParts[4]);
            reservations.Add(ReservationInfo);
        }
        return reservations;
    }

    public static List<(int roomNumber, RoomType)> ReadInRooms()
    {
        List<(int roomNumber, RoomType)> rooms = new();
        List<int> availableRooms = new List<int>();
        foreach (string Room in File.ReadAllLines("Rooms.txt"))
        {
            string[] RoomParts = Room.Split(",");
            (int roomNumber, RoomType) RoomInfo = (Convert.ToInt32(RoomParts[0]), getRoomType(RoomParts[1]));
            rooms.Add(RoomInfo);
            availableRooms.Add(Convert.ToInt32(RoomParts[0]));
        }
        return rooms;
    }

    //     List<(RoomType, int DailyRate)> RoomPricesList = new List<(RoomType, int DailyRate)>();
    //     string[] RoomPrices = File.ReadAllLines("RoomPrices.txt");
    // foreach (string Price in RoomPrices)
    // {
    //     string[] PriceParts = Price.Split(",");
    //     (RoomType, int DailyRate) PriceInfo = (getRoomType(PriceParts[0]), Convert.ToInt32(PriceParts[1]));
    //     RoomPricesList.Add(PriceInfo);
    // }

    // List<string> charList = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "_", "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "z", "x", "c", "v", "b", "n", "m", "?", ".", "!", "@", "#", "$", "%", "^", "&", "*", "+", "=", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", ":", "Z", "X", "C", "V", "B", "N", "M", "<", ">", "/" };


    // CustomerList.Add(getCustomer());

    // ReservationsList.Add(getReservation());


    // //Saving

    // string[] updatedCustomers = new string[CustomerList.Count];
    // int index = 0;
    // foreach (var Customer in CustomerList)
    // {
    //     updatedCustomers[index] = $"{Customer.name},{Customer.cardNumber}";
    //     index++;
    // }
    // File.WriteAllLines("Customers.txt", updatedCustomers);

    // string[] updatedRoomPrices = new string[RoomPricesList.Count];
    // index = 0;
    // foreach (var Price in RoomPricesList)
    // {
    //     updatedRoomPrices[index] = $"{Price.Item1},{Price.DailyRate}";
    //     index++;
    // }
    // File.WriteAllLines("RoomPrices.txt", updatedRoomPrices);

    // string[] updatedReservations = new string[ReservationsList.Count];
    // index = 0;
    // foreach (var Reservation in ReservationsList)
    // {
    //     updatedReservations[index] = $"{Reservation.RsvNumber},{Reservation.date},{Reservation.roomNumber},{Reservation.name},{Reservation.payConfirm}";
    //     index++;
    // }
    // File.WriteAllLines("Reservations.txt", updatedReservations);

    // string[] updatedRooms = new string[RoomList.Count];
    // index = 0;
    // foreach (var Room in RoomList)
    // {
    //     updatedRooms[index] = $"{Room.roomNumber},{Room.Item2}";
    //     index++;
    // }
    // File.WriteAllLines("Rooms.txt", updatedRooms);



    // //Methods and Enums

    // (string name, int card) getCustomer()
    // {
    //     Console.Write("Please enter your name: ");
    //     string name = Console.ReadLine();
    //     Console.WriteLine($"Thank you {name}! Please enter your card number which will be used for purchases.");
    //     int card = getNumber();
    //     CurrentCustomers.Add(name);
    //     return (name, card);
    // }

    // (string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm) getReservation()
    // {
    //     string rsvNumber = Guid.NewGuid().ToString();
    //     Console.WriteLine("Please enter the date you are wanting to reserve.");
    //     DateOnly date = getDate();
    //     Console.WriteLine("Please enter the room number you are wanting to reserve.");
    //     int roomNumber = getNumber();
    //     while (!availableRooms.Contains(roomNumber))
    //     {
    //         Console.WriteLine("Enter an available room number!");
    //         roomNumber = getNumber();
    //     }
    //     Console.WriteLine("Please enter the customer name that this reservation will be placed under.");
    //     string name = Console.ReadLine();
    //     while (!CurrentCustomers.Contains(name))
    //     {
    //         Console.WriteLine("Enter an existing customer name for payment!");
    //         name = Console.ReadLine();
    //     }
    //     string randomChars = "";
    //     Random randomChar = Random.Shared;
    //     for (int index = 0; index < 30; index++)
    //     {
    //         randomChars = randomChars + charList[randomChar.Next(charList.Count)];
    //     }
    //     string payConfirm = randomChars;
    //     return (rsvNumber, date, roomNumber, name, payConfirm);
    // }

    // int getNumber()
    // {
    //     while (true)
    //     {
    //         try
    //         {
    //             int number = int.Parse(Console.ReadLine());
    //             return number;
    //         }
    //         catch
    //         {
    //             Console.WriteLine("Enter a valid number!");
    //         }
    //     }
    // }

    // DateOnly getDate()
    // {
    //     while (true)
    //     {
    //         try
    //         {
    //             DateOnly Date = DateOnly.Parse(Console.ReadLine());
    //             return Date;
    //         }
    //         catch
    //         {
    //             Console.WriteLine("Enter a date with the format MM/DD/YEAR");
    //         }
    //     }
    // }

    static RoomType getRoomType(string input)
    {
        RoomType TheRoom = RoomType.Single;
        if (input == "Deluxe")
        {
            TheRoom = RoomType.Deluxe;
        }
        else if (input == "Double")
        {
            TheRoom = RoomType.Double;
        }
        else if (input == "Suite")
        {
            TheRoom = RoomType.Suite;
        }
        return TheRoom;
    }

}