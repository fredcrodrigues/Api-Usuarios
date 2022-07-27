using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class UserService{

   // create collections mongo
   public readonly IMongoCollection<UserModel> _usercollection;


   // inicialize section of Conections with colections
   public UserService(IOptions<UserDatabaseSettings> clustersettings){
      var mongoClient = new MongoClient(
         clustersettings.Value.ConnectionsString
      );
      var mongoDatabase = mongoClient.GetDatabase(clustersettings.Value.DatabaseName);
      
      _usercollection = mongoDatabase.GetCollection<UserModel>(clustersettings.Value.TestColectionsName);
   }

   public async Task<List<UserModel>> GetTask() => await _usercollection.Find(_ => true).ToListAsync();

}