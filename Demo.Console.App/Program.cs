namespace Demo.Console.MongoDB
{
    using global::MongoDB.Bson;
    using global::MongoDB.Driver;
    using System.Threading.Tasks;

    internal class Program
    {
        private const string CONNECTION_STRING = "mongodb://root:password@localhost:27017";

        static async Task Main(string[] args)
        {
            var databaseName = "MyTempDb";
            MongoClient dbClient = new(CONNECTION_STRING);
            var myTempDb = dbClient.GetDatabase(databaseName);

            if (myTempDb != null)
            {
                var myCollectionName = "MyUserCollection";
                // await myTempDb.CreateCollectionAsync(myCollectionName);

                var myCollection = GetMongoCollection<BsonDocument>(myTempDb, myCollectionName);

                // var data = GetSampleData();
                // await myCollection?.InsertOneAsync(data);

                // var userDoc = await myCollection.FindAsync(new BsonDocument());
                // Console.WriteLine(userDoc.FirstOrDefault().ToString());

                var filter = Builders<BsonDocument>.Filter.Eq("user_id", 10);
                var userDoc = await myCollection.FindAsync(filter);
                Console.WriteLine(userDoc.FirstOrDefault().ToString());
            }
        }

        private static IMongoDatabase CreateDatabase(string databaseName)
        {
            /*
             * If a database does not exist, MongoDB creates the database when you first store data for that database
            */

            MongoClient dbClient = new(CONNECTION_STRING);
            IMongoDatabase database = dbClient.GetDatabase(databaseName);

            return database;
        }

        private static IMongoCollection<T>? GetMongoCollection<T>(IMongoDatabase database, string collectionName)
        {
            var command = $"{{ collStats: \"{collectionName}\", scale: 1 }}";
            try
            {
                database.RunCommand<BsonDocument>(command);
                return database.GetCollection<T>(collectionName);
            }
            catch (MongoCommandException e) when (e.ErrorMessage.EndsWith("not found."))
            {
                return null;
            }
        }

        private static BsonDocument GetSampleData()
        {
            var document = new BsonDocument
            {
                { "user_id", 10 },
                { "info", new BsonArray
                    {
                    new BsonDocument{ {"type", "name"}, {"value", "john doe" } },
                    new BsonDocument{ {"type", "email"}, {"value", "john.doe@email.com" } },
                    new BsonDocument{ {"type", "phone"}, { "value", 1234567890 } },
                    new BsonDocument{ {"type", "address"}, { "value", "123 Street, TX 75000" } }
                    }
                },
                { "group_id", 78}
            };

            return document;
        }

        private static void ListDatabases()
        {
            MongoClient dbClient = new(CONNECTION_STRING);
            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}