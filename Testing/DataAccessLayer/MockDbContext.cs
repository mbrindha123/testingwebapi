using PMS_API;
using Microsoft.EntityFrameworkCore;
using Moq;
using Testing.Mock;

namespace  Testing.DataAccessLayer
{

public static class MockDbContext
{
    public static Context GetDbContext(){

        var Options= new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "PMS_InMemoryDatabase").Options;
        return new Context(Options);
    

    }
      
    public static void SeedPMSMockData(Context dbContext)
    {
        dbContext.users.AddRange(UserMock.GetValidateAllUsers());
        //dbContext.users.AddRange(UserMock.UpdateValidUser());
        dbContext.SaveChanges();
    }
}
}

