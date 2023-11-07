namespace Hotel.Logic.Tests;

public class CustomerTests
{
    [Fact]
    public void AddCustomer()
    {
        HotelManager.CustomerList = new(); //ERASING everything so we can have a predictable test
        try
        {
            HotelManager.AddCustomer("bob", 987654321);
        }
        catch
        {
            Assert.Fail("Should not have thrown an error.");
        }
        
        Assert.Single(HotelManager.CustomerList);
    }

    [Fact]
    public void AddCustomerTwice()
    {
        HotelManager.CustomerList = new(); //ERASING everything so we can have a predictable test

        //Add BOB the first time
        try
        {
            HotelManager.AddCustomer("bob", 987654321);
        }
        catch
        {
            Assert.Fail("Should not have thrown an error.");
        }

        //Add BOB a second time
        try
        {
            HotelManager.AddCustomer("bob", 987654321);
        }
        catch
        {
            Assert.True(true);//Because "bob" was being added a second time, 
            //catching this exception proves the duplicate was detected
            return;
        }

        //Shouldn't get here
        //Only gets here if it failed to detect the duplicate exception
        Assert.Fail("Should have caught an Exception.  Didn't.  Is Failure.");
    }
}