# Use of MongoDB with .NET

## What is a MongoDB?
>MongoDB is a source-available cross-platform document-oriented database program. Classified as a NoSQL database program, MongoDB uses JSON-like documents with optional schemas.

## Basic concepts
- **id**: This is a field required in every MongoDB document. The _id field represents a unique value in the MongoDB document. The _id field is like the document’s primary key. If you create a new document without an _id field, MongoDB will automatically create the field.  
- **Collection**: his is a grouping of MongoDB documents. A collection is the equivalent of a table which is created in any other RDMS.
- **Cursor**: This is a pointer to the result set of a query. Clients can iterate through a cursor to retrieve results. 
- **Database**: This is a container for collections like in RDMS wherein it is a container for tables. Each database gets its own set of files on the file system. A MongoDB server can store multiple databases.
- **Document**: A record in a MongoDB collection is basically called a document. The document, in turn, will consist of field name and values.
- **Field**: A name-value pair in a document. A document has zero or more fields. Fields are analogous to columns in relational databases.
- **BSON**: BSON stands for Binary Javascript Object Notation. It is a binary-encoded serialization of JSON documents. BSON has been extended to add some optional non-JSON-native data types, like dates and binary data. BSON can be compared to other binary formats, like Protocol Buffers.
- **BsonDocument**: The default type used for documents. It handles dynamic documents of any complexity.
## Compare with RDBMS
|**RDBMS**|**MongoDB**|
| :--- | :--- |
|Table|Collection|
|Row|Document|
|Column|Field|
|Joins|Embedded documents|

---
## Links:
- [Create a web API with ASP.NET Core and MongoDB](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio)

