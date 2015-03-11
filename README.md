# balloon-game

Change the call to the BalloonGame Update method to use an event rather than directly calling the Update method. In other words, add an Update event to the BalloonGame which then calls the private Update method.

Rather than call the BalloonGame Select method directly, create an event in the BalloonGame for Select, and have the code in the Form publish to this event. 

Add the ability to move the selected balloon. You'll need to: 

    Add MoveLeft and MoveRight methods to the Balloon class. 
    Add a MoveEventHandler to the BalloonGame class with a method definition of public void MoveEventHandler(object sender, System.Windows.Forms.KeyEventArgs).
    Dynamically add an event handler for the Form KeyDown event (this.KeyDown) in the Form Shown event handler, using the _game.MoveEventHandler as the method parameter.
    Save your project and test it to make sure it works. Your source code should have no errors or warnings.

