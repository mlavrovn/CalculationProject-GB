### Feedback

Hello team, here is my feedback and the highlights related to the completed task.

## Implementation Highlights

### 1. **DTOs Validation.**
- **Description:** 
  - Used **FluentValidation** for incoming DTO validation.
- **Reasoning:** 
  - Validation logic is kept separate from business logic, making the code easier to maintain and understand.
---
### 2. **DTOs mapping**
- **Description:** 
  - Used **Automapper** for mapping DTOs.
- **Reasoning:** 
  - Ensure that all mappings are done consistently across the application.
---
### 3. **Error Handler Middleware.**
- **Description:** 
  - Used custom ErrorHandlerMiddleware middleware for exception handling during HTTP request processing, logging errors, and generating appropriate JSONresponses based on encountered exceptions.
- **Reasoning:** 
  - Ensure that all api requests exceptions handling are done consistently across the application.
---

### 4. **Unit tests using NUnit, NSubstitute, FluentAssertions.**
- **Description:** 
  - Used NUnit, NSubstitute, FluentAssertions for writting unit test. 
- **Reasoning:** 
  - FluentAssertions provides a fluent API for assertions that reads more naturally, making tests easier to understand.
---

### 5. **Stategy pattern.**
- **Description:** 
  - The Strategy Pattern is applied to dynamically select and execute the calculation algorithm based on the type of input provided (Gross, Net, or VAT). 
- **Reasoning:** 
  - This approach ensures that the logic for calculating is modular and can be easily extended or modified without changing the core logic of the service.
