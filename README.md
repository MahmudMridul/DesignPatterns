# Learn_DesignPatterns
## 1. Creational Patterns
### A. Singleton (Thread Safe)
```
private static readonly Lazy<DbConnectionThreadSafe> _instance = null!;
```
#### Using `Lazy<T>` Because
- Thread safe by default
- Provides lazy initialization

```
static DbConnectionThreadSafe()
{
    _instance = new Lazy<DbConnectionThreadSafe>(
        () => new DbConnectionThreadSafe(_connectionString),
        LazyThreadSafetyMode.ExecutionAndPublication
    );
}
```
Let's break down this static constructor and the Lazy<T> initialization:

```csharp
static DbConnection()  // This is a static constructor
{
    _lazyInstance = new Lazy<DbConnection>(
        () => new DbConnection(_connectionString),  // Lambda expression
        LazyThreadSafetyMode.ExecutionAndPublication  // Thread safety mode
    );
}
```
Let's examine each part:

1. **Static Constructor** (`static DbConnection()`)
   - A static constructor is called automatically before any static members are referenced
   - It runs only once per app domain
   - It's thread-safe by default (CLR guarantees this)
   - Used to initialize static fields

2. **Lazy<T>**
   - `Lazy<T>` is a class that provides lazy initialization
   - The actual object isn't created until it's first accessed
   - When you access `Lazy<T>.Value` for the first time, it creates the instance

3. **Lambda Expression** (`() => new DbConnection(_connectionString)`)
   - This is a factory function that creates the DbConnection instance
   - It's only executed when the Lazy<T>.Value is first accessed
   - The `=>` syntax defines a lambda expression (anonymous function)

4. **LazyThreadSafetyMode.ExecutionAndPublication**
   - This enum value specifies how the Lazy<T> instance handles thread safety
   - Three possible modes:
```
// No thread safety
LazyThreadSafetyMode.None
     
// Locks initialization
LazyThreadSafetyMode.ExecutionAndPublication
     
// Multiple threads can attempt initialization
LazyThreadSafetyMode.PublicationOnly
```
The execution flow:
1. When the class is first referenced, the static constructor runs
2. The `_lazyInstance` is created, but the DbConnection instance is not yet created
3. When `Instance` is first accessed:
   - The lambda expression runs
   - Creates new DbConnection with the connection string
   - Stores it in the Lazy<T> instance
4. Subsequent accesses to `Instance` return the same stored instance
