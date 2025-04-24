# Factory Method
Let's say we need to create two types of documents in your application.

1. PDF
2. Word

So we can simply write the following codes.
First we create a document creator class that creates required document
type based on the parameter passed.
```
public class DocumentCreator
{
    public IDocument CreateDocument(string type)
    {
        IDocument doc = null!;
        if (type == "pdf")
        {
            doc = new Pdf();
        }
        else if (type == "word")
        {
            doc = new Word();
        }
        return doc;
    }
}
```
Here as we can see `CreateDocument` return a `IDocument` object. because
we are dealing with different return type here. 
So, this is how we will have to define our concrete classes.
```
public interface IDocument
{
    void Open();
    void Close();
    void Save();
}

public class Pdf : IDocument
{
    public void Open()
    {
        //logic
    }

    public void Close()
    {
        //logic
    }
    public void Save()
    {
        //logic
    }
}

public class Word : IDocument
{
    public void Open()
    {
        //logic
    }

    public void Close()
    {
        //logic
    }
    public void Save()
    {
        //logic
    }
}
```
And finally we have our client code.
```
public class Client
{
    public static void ClientMain()
    {
        DocumentCreator creator = new DocumentCreator();
        Document pdf = creator.CreateDocument("pdf");
        Document word = creator.CreateDocument("word");
    }
}
```
This looks good. But what if our client wants to add a new document type. Let's say 
Excel. We will have to add a new class `Excel` and modify `CreateDocument` function in the `DocumentCreator` class like following
```
public class DocumentCreator
    {
        public IDocument CreateDocument(string type)
        {
            IDocument doc = null!;
            if (type == "pdf")
            {
                doc = new Pdf();
            }
            else if (type == "word")
            {
                doc = new Word();
            }
            else if (type == "excel") 
            {
                doc = new Excel();
            }
            return doc;
        }
    }
```
But this breaks the `Open Closed` principle. The class DocumentCreator is not
closed for modification. 

This is where `Factory Method` pattern comes in to save the day!
First, let's see how we implement this pattern for two types of documents. 

We will define the `Document` interface, `Pdf` and `Word` class just like previous example. No 
change here. 

But this time along with concrete classes we will define some concrete factory classes and a common `abstract` factory class like below.
```
public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

public class PdfFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

public class WordFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}
```

And this is how the client code will use the factories
```
public class Client
{
    public static void ClientMain()
    {
        DocumentFactory pdfFactory = new PdfFactory();
        DocumentFactory wordFactory = new WordFactory();

        IDocument pdf = pdfFactory.CreateDocument();
        IDocument word = wordFactory.CreateDocument();

        pdf.Open();
        word.Open();

        pdf.Close();
        word.Close();
    }
}
```
As we can see now we have such a setup that if we need to add a new document type we don't 
need to modify any classes. We just create a new class and factory like following.
```
public class Excel : IDocument
{
    public void Open()
    {
        //logic
    }

    public void Close()
    {
        //logic
    }
    public void Save()
    {
        //logic
    }
}

public class ExcelFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new Excel();
    }
}

```

That makes our code closed for modification but open for extension. Below are some more details about this desing pattern.


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
2. `Pdf` and `Word` are concrete products
3. `DocumentFactory` is the abstract creator with the factory method
4. `PdfFactory` and `WordFactory` are concrete creators

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

