# Factory Method
```
// Abstract Product
public interface IDocument
{
    void Open();
    void Save();
    void Close();
}

// Concrete Products
public class PDFDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF document");
    }

    public void Save()
    {
        Console.WriteLine("Saving PDF document");
    }

    public void Close()
    {
        Console.WriteLine("Closing PDF document");
    }
}

public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Word document");
    }

    public void Save()
    {
        Console.WriteLine("Saving Word document");
    }

    public void Close()
    {
        Console.WriteLine("Closing Word document");
    }
}

// Abstract Creator
public abstract class DocumentFactory
{
    // Factory Method
    public abstract IDocument CreateDocument();
}

// Concrete Creators
public class PDFDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PDFDocument();
    }
}

public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}
```

The Factory Method pattern is a creational pattern that provides an interface for creating objects but allows subclasses to alter the type of objects that will be created. Here's when and why you should use it:

1. **When to Use:**
   - When you don't know ahead of time what exact types of objects you need to create
   - When you want to delegate the responsibility of object creation to subclasses
   - When you want to provide a way to extend the application's code with new types without modifying existing code
   - When you have a class that needs to create different types of objects based on some condition

2. **Problems it Solves:**
   - Decouples object creation from the code that uses the objects
   - Makes the code more flexible and extensible
   - Follows the Open/Closed Principle (open for extension, closed for modification)
   - Eliminates the need for complex conditional logic in object creation
   - Provides a way to encapsulate object creation logic

In the example above:
1. `IDocument` is the product interface that defines what a document can do
2. `PDFDocument` and `WordDocument` are concrete products
3. `DocumentFactory` is the abstract creator with the factory method
4. `PDFDocumentFactory` and `WordDocumentFactory` are concrete creators

Real-world examples where Factory Method is useful:
1. **UI Framework Components:**
```
public abstract class ButtonFactory
{
    public abstract IButton CreateButton();
}

// Different factories for Windows, Mac, Web buttons
```

2. **Database Connections:**
```
public abstract class DbConnectionFactory
{
    public abstract IDbConnection CreateConnection();
}

// Separate factories for SQL Server, Oracle, MySQL
```

3. **Payment Processing:**
```
public abstract class PaymentProcessorFactory
{
    public abstract IPaymentProcessor CreateProcessor();
}

// Different factories for PayPal, Stripe, Square
```

Benefits of using Factory Method:
1. Easy to add new product types without changing existing code
2. Single Responsibility Principle - separates product creation code from the product usage code
3. Helps manage complexity in applications with multiple product variants
4. Makes the code more testable by allowing mock object creation

