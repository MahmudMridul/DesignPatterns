# Adapter

### General Structure:

**Target (IJsonAdapter):** The interface that clients expect to use

**Adaptee (LegacyXmlSystem):** The existing class that needs to be adapted

**Adapter (XmlToJsonAdapter):** The class that bridges between Target and Adaptee

**Client:** The code that works with the Target interface


### When to Use:

- Integrating legacy code with new systems
- Making incompatible interfaces work together
- Reusing existing classes with incompatible interfaces
- Converting data formats between systems
- Maintaining backward compatibility

### Benefits:

- Promotes reusability of existing code
- Provides clean separation of concerns
- Makes incompatible code work together without modifying source
- Follows Single Responsibility Principle
- Enhances maintainability

### Limitations:

- Can add complexity to the codebase
- May require creating multiple adapters for different interfaces
- Could impact performance due to additional layer
- Might make debugging more challenging
- Not suitable when extensive interface modifications are needed

The real-world example in the code shows adapting XML data to JSON format. The pattern is particularly useful in scenarios like:

- Database interface adaptations
- Third-party library integration
- API versioning
- File format conversions
- Payment gateway integrations