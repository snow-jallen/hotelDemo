namespace Hotel.Data;

public enum RoomType { Single, Double, Suite, Deluxe };

public static class DataManager
{   
    /// <summary>
    /// Look in the current directory and all parent directories for the given file.
    /// </summary>
    /// <param name="fileName">The name of the file you want</param>
    /// <returns>The full path to that file</returns>
    /// <example>
    /// string[] linesInCustomerFile = File.ReadAllLines(FindFile("Customers.txt"));
    /// </example>
    public static string FindFile(string fileName)
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (true)
        {
            var testPath = Path.Combine(directory.FullName, fileName);
            if (File.Exists(testPath))
            {
                return testPath;
            }

            if (directory.FullName == directory.Root.FullName)
            {
                throw new FileNotFoundException($"I looked for {fileName} in every folder from {Directory.GetCurrentDirectory()} to {directory.Root.FullName} and couldn't find it.");
            }
            directory = directory.Parent;
        }
    }

//READ FILE SECTION
    public static List<(string name, int cardNumber)> ReadInCustomers()
    {
        List<(string name, int cardNumber)> customers = new();

        foreach (var line in File.ReadAllLines(FindFile("Customers.txt")))
        {
            /* TODO: 
            1) parse the line into a customer tuple
            2) add that tuple to the customers list
            */
        }

        return customers;
    }

    public static List<(string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm)> ReadInReservations()
    {
        //TODO: Don't throw this exception, implement the method like you did in ReadInCustomers()
        throw new NotImplementedException();
    }

    public static List<(int roomNumber, RoomType roomType)> ReadInRooms()
    {
        //TODO: Don't throw this exception, implement the method like you did in ReadInCustomers()
        throw new NotImplementedException();
    }

    public static List<(RoomType roomType, decimal dailyRate)> ReadInRoomPrices()
    {
        //TODO: Don't throw this exception, implement the method like you did in ReadInCustomers()
        throw new NotImplementedException();
    }



//WRITE FILE SECTION
    public static void WriteCustomers(List<(string name, int cardNumber)> customers)
    {
        string newFileContents = "";
        foreach (var customer in customers)
        {
            //TODO: add a line to the file for the current customer            
        }

        File.WriteAllText(FindFile("Customers.txt"), newFileContents);
    }

    public static void WriteReservations(List<(string RsvNumber, DateOnly date, int roomNumber, string name, string payConfirm)> reservations)
    {
        //TODO: Don't throw this exception, implement the method like you did in WriteCustomers()
        throw new NotImplementedException();
    }

    public static  void WriteRooms(List<(int roomNumber, RoomType roomType)> rooms)
    {
        //TODO: Don't throw this exception, implement the method like you did in WriteCustomers()
        throw new NotImplementedException();
    }

    public static  void WriteRoomPrices(List<(RoomType roomType, decimal dailyRate)> roomPrices)
    {
        //TODO: Don't throw this exception, implement the method like you did in WriteCustomers()
        throw new NotImplementedException();
    }
    
    public static RoomType ParseRoomType(string input)
    {
        if(Enum.TryParse<RoomType>(input, out RoomType roomType))
        {
            return roomType;    
        }
        throw new Exception("Unrecognized room type");
    }
}