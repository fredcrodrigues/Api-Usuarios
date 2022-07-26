
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.Models;

namespace Users.Service;
public class UserService{

   // create collections mongo
   public readonly IMongoCollection<UserModel> _usercollection;


   // inicialize section of Conections with colections
   public UserService(IOptions<UserDatabaseSettings> clustersettings){
   
      var mongoClient = new MongoClient(
        
         clustersettings.Value.ConnectionString

      );
    
      var mongoDatabase = mongoClient.GetDatabase(clustersettings.Value.DatabaseName);
      
      _usercollection = mongoDatabase.GetCollection<UserModel>(clustersettings.Value.TestColectionsName);
   }

   public async Task<List<UserModel>> GetTask() => await _usercollection.Find(_ => true).ToListAsync();
   public async Task<UserModel>? GestTaskAsycId(string id) => await _usercollection.Find( x => id == x.Id).FirstOrDefaultAsync();
   
   public async Task Create(UserModel date){
      await _usercollection.InsertOneAsync(date);
   }  
   public async Task Update(string id, UserModel users){
         await _usercollection.ReplaceOneAsync( x => x.Id == id, users);
   }

   public async Task Delete(string id){
      await _usercollection.DeleteOneAsync(x => x.Id == id);
   }
}