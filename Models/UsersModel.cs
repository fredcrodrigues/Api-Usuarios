namespace Users.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class UserModel{
  
    [BsonElement("login")] 
    public string Login{get;set;} = null!;
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id{get;set;}

    [BsonElement("avatar_url")] 
    public string Avatar_url{get;set;} = null!;
    [BsonElement("followers_url")]
    public string Followers_url{get;set;} = null!;
    [BsonElement("follower_url")]
    public string Following_url{get;set;}= null!;
    [BsonElement("url")]
    public string Url{get;set;} = null!;
}