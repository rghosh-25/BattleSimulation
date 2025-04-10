
# Battle Simulation Transformers Console Application
## Overview
This is a console application that allows users to manage a list of Transformers, simulate battles between them, and view their win/loss records. The application follows closely but not limited to MVC (Model-View-Controller) pattern and uses asynchronous methods for data operations.
## Features
- Add a new Transformer
- Remove an existing Transformer
- Simulate a battle between two Transformers
- Get the win/loss ratio of a Transformer
- Display the list of all Transformers
## Getting Started
### Prerequisites
- .NET SDK (version 5.0 or later)

## Usage
Follow the on-screen prompts to interact with the application. The main menu provides options to add, remove, battle, and view Transformers.
### Example
1. **Add a Transformer**:
    - Enter the name, faction (Autobot/Decepticon), and strength of the Transformer.
2. **Remove a Transformer**:
    - Enter the name of the Transformer to remove.
3. **Battle Transformers**:
    - Enter the names of two Transformers to simulate a battle.
4. **Get Win/Loss Ratio**:
    - Enter the name of a Transformer to view its win/loss ratio.
5. **Display Transformers**:
    - View the list of all Transformers.
## Code Structure
- `Program.cs`: Entry point of the application.
- `Transformer.cs`: Model representing a Transformer.
- `IRepository.cs`: Interface for data operations.
- `TransformerRepository.cs`: Implementation of the `IRepository` interface.
- `TransformerManager.cs`: Manages Transformer operations.
- `TransformerController.cs`: Handles user input and application logic.
## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.
## License
This project is licensed under the MIT License. See the LICENSE file for details.

